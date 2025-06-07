// Form1.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HammingSECDED
{
    public partial class Form1 : Form
    {
        List<string> memory = new List<string>();
        List<string> parityBits = new List<string>();
        List<int> parityPositions = new List<int>();
        List<int> dataOneBitPositions = new List<int>();

        public Form1()
        {
            InitializeComponent();
            encodeButton.Click += encodeButton_Click;
            errorButton.Click += errorButton_Click;
            checkButton.Click += checkButton_Click;
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            string data = inputTextBox.Text.Trim();
            if (!IsBinary(data))
            {
                MessageBox.Show("Lütfen yalnızca 0 ve 1 içeren bir veri giriniz.");
                return;
            }
            if (!IsValidLength(data))
            {
                MessageBox.Show("Veri uzunluğu yalnızca 8, 16 veya 32 bit olabilir.");
                return;
            }
            memory.Add(data);
            string hammingCode = GenerateHammingCode(data);
            string parityString = string.Join("", GetParityBitValues(hammingCode));
            string generalParity = CalculateGeneralParity(hammingCode);
            generalParityTextBox.Text = generalParity;
            parityBits.Add(parityString);
            parityPositions = GetParityBitPositions(hammingCode);
            dataOneBitPositions = GetDataOneBitPositions(hammingCode);

            memoryListBox.Items.Add(hammingCode);
            outputLabel.Text = "Veri listeye eklendi: " + data +
                               "\nHamming kodu: " + hammingCode +
                               "\nParity string: " + parityString +
                               "\nGenel Parity: " + generalParity +
                               "\nParity pozisyonları: " + string.Join(", ", parityPositions) +
                               "\nData '1' bit pozisyonları: " + string.Join(", ", dataOneBitPositions);
        }

        private void errorButton_Click(object sender, EventArgs e)
        {
            int index = memoryListBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Lütfen bir veri seçiniz.");
                return;
            }
            if (string.IsNullOrWhiteSpace(errorPosTextBox.Text))
            {
                // Kullanıcı boş bıraktıysa, hata uygulanmaz
                MessageBox.Show("Hata uygulanmadı. Pozisyon belirtilmedi.");
                return;
            }

            if (!int.TryParse(errorPosTextBox.Text, out int pos) || pos < 1)
            {
                MessageBox.Show("Geçerli bir bit pozisyonu giriniz.");
                return;
            }

            string selectedCode = memoryListBox.Items[index].ToString();
            if (pos > selectedCode.Length)
            {
                MessageBox.Show("Girilen pozisyon veri uzunluğunu aşıyor.");
                return;
            }
            char[] chars = selectedCode.ToCharArray();
            chars[pos - 1] = chars[pos - 1] == '0' ? '1' : '0';
            string erroredCode = new string(chars);
            memoryListBox.Items[index] = erroredCode;
            memory[index] = erroredCode;
            outputLabel.Text = $"Hata uygulandı. Yeni veri: {erroredCode}";
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            int index = memoryListBox.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Lütfen bir veri seçiniz.");
                return;
            }
            string selectedCode = memoryListBox.Items[index].ToString();
            List<int> ones = new List<int>();
            for (int i = 0; i < selectedCode.Length; i++)
            {
                if (!IsPowerOfTwo(i + 1) && selectedCode[i] == '1')
                {
                    ones.Add(i + 1);
                }
            }
            int result = 0;
            foreach (int pos in ones)
            {
                result ^= pos;
            }
            List<char> extractedParity = GetParityBitValues(selectedCode);
            string parityString = string.Join("", extractedParity);
            int parityVal = 0;
            for (int i = 0; i < parityString.Length; i++)
            {
                if (parityString[i] == '1')
                {
                    parityVal ^= (int)Math.Pow(2, i);
                }
            }
            int finalCheck = result ^ parityVal;
            int oneCount = Convert.ToString(finalCheck, 2).Count(c => c == '1');

            string genelParityYeni = CalculateGeneralParity(selectedCode);
            string genelParityEski = generalParityTextBox.Text.Trim();

            outputLabel.Text = $"Sendrom (finalCheck): {finalCheck}\n";
            outputLabel.Text += $"Genel Parity (önceki): {genelParityEski}, (şimdiki): {genelParityYeni}\n";

            if (finalCheck != 0 && genelParityEski == genelParityYeni)
            {
                outputLabel.Text += "Çift hata tespit edildi!\nSistem tek hata zannedip yanlış düzeltme yapabilir.\nBu durumda düzeltme yapılmaz.\n";
                return;
            }

            if (finalCheck == 0)
            {
                outputLabel.Text += "Veride hata yok.";
            }
            else if (oneCount == 1)
            {
                outputLabel.Text += "Veri doğru, ancak parity bitinde hata olabilir.";
            }
            else if (oneCount >= 2)
            {
                outputLabel.Text += $"Data hatalı. Hatalı bit pozisyonu: {finalCheck}. DÜZELTİLİYOR...\n";
                char[] corrected = selectedCode.ToCharArray();
                int pos = finalCheck - 1;
                if (pos >= 0 && pos < corrected.Length)
                    corrected[pos] = corrected[pos] == '0' ? '1' : '0';
                string correctedString = new string(corrected);
                memoryListBox.Items[index] = correctedString;
                memory[index] = correctedString;
                outputLabel.Text += $"Düzeltilmiş veri: {correctedString}";
            }
        }

        private string GenerateHammingCode(string data)
        {
            int m = data.Length;
            int r = 0;
            while (Math.Pow(2, r) < m + r + 1) r++;
            int totalLength = m + r;
            char[] hamming = new char[totalLength + 1];
            int j = 0;
            for (int i = 1; i <= totalLength; i++)
            {
                if (IsPowerOfTwo(i))
                    hamming[i] = '0';
                else
                    hamming[i] = data[j++];
            }
            for (int i = 0; i < r; i++)
            {
                int parity = 0;
                int pos = (int)Math.Pow(2, i);
                for (int k = 1; k <= totalLength; k++)
                {
                    if (((k >> i) & 1) == 1 && hamming[k] == '1')
                        parity++;
                }
                hamming[pos] = (parity % 2 == 0) ? '0' : '1';
            }
            return new string(hamming.Skip(1).ToArray());
        }

        private List<char> GetParityBitValues(string hammingCode)
        {
            List<char> values = new List<char>();
            for (int i = 1; i <= hammingCode.Length; i++)
            {
                if (IsPowerOfTwo(i))
                    values.Add(hammingCode[i - 1]);
            }
            return values;
        }

        private List<int> GetParityBitPositions(string hammingCode)
        {
            List<int> positions = new List<int>();
            for (int i = 1; i <= hammingCode.Length; i++)
            {
                if (IsPowerOfTwo(i))
                    positions.Add(i);
            }
            return positions;
        }

        private List<int> GetDataOneBitPositions(string hammingCode)
        {
            List<int> positions = new List<int>();
            for (int i = 1; i <= hammingCode.Length; i++)
            {
                if (!IsPowerOfTwo(i) && hammingCode[i - 1] == '1')
                    positions.Add(i);
            }
            return positions;
        }

        private string CalculateGeneralParity(string hammingCode)
        {
            int ones = hammingCode.Count(c => c == '1');
            return (ones % 2 == 0) ? "0" : "1";
        }

        private bool IsPowerOfTwo(int x) => (x & (x - 1)) == 0 && x != 0;
        private bool IsBinary(string s) => s.All(c => c == '0' || c == '1');
        private bool IsValidLength(string s) => s.Length == 8 || s.Length == 16 || s.Length == 32;

       
    }

}
