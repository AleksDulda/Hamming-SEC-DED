namespace HammingSECDED
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.ListBox memoryListBox;
        private System.Windows.Forms.TextBox errorPosTextBox;
        private System.Windows.Forms.Button errorButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox generalParityTextBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            inputTextBox = new TextBox();
            encodeButton = new Button();
            memoryListBox = new ListBox();
            errorPosTextBox = new TextBox();
            errorButton = new Button();
            checkButton = new Button();
            outputLabel = new Label();
            generalParityTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(73, 136);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(170, 23);
            inputTextBox.TabIndex = 0;
            // 
            // encodeButton
            // 
            encodeButton.Location = new Point(264, 111);
            encodeButton.Name = "encodeButton";
            encodeButton.Size = new Size(85, 25);
            encodeButton.TabIndex = 1;
            encodeButton.Text = "Kodla";
            // 
            // memoryListBox
            // 
            memoryListBox.ItemHeight = 15;
            memoryListBox.Location = new Point(376, 58);
            memoryListBox.Name = "memoryListBox";
            memoryListBox.Size = new Size(274, 154);
            memoryListBox.TabIndex = 2;
            // 
            // errorPosTextBox
            // 
            errorPosTextBox.Location = new Point(731, 119);
            errorPosTextBox.Name = "errorPosTextBox";
            errorPosTextBox.PlaceholderText = "Hata Pozisyonu";
            errorPosTextBox.Size = new Size(89, 23);
            errorPosTextBox.TabIndex = 3;
            // 
            // errorButton
            // 
            errorButton.Location = new Point(731, 148);
            errorButton.Name = "errorButton";
            errorButton.Size = new Size(89, 25);
            errorButton.TabIndex = 4;
            errorButton.Text = "Hata Ekle";
            // 
            // checkButton
            // 
            checkButton.Location = new Point(897, 120);
            checkButton.Name = "checkButton";
            checkButton.Size = new Size(85, 25);
            checkButton.TabIndex = 5;
            checkButton.Text = "Kontrol Et";
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(731, 223);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(40, 15);
            outputLabel.TabIndex = 6;
            outputLabel.Text = "Çıktı...";
            // 
            // generalParityTextBox
            // 
            generalParityTextBox.Location = new Point(627, 215);
            generalParityTextBox.Name = "generalParityTextBox";
            generalParityTextBox.PlaceholderText = "Genel Parity";
            generalParityTextBox.ReadOnly = true;
            generalParityTextBox.Size = new Size(23, 23);
            generalParityTextBox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 118);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 8;
            label1.Text = "Veri Girişi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(255, 139);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 9;
            label2.Text = "-------------------->";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(376, 40);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 10;
            label3.Text = "Memory";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(538, 218);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 11;
            label4.Text = "Genel Eşlik Biti";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(662, 122);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 12;
            label5.Text = "---------->";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(731, 101);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 13;
            label6.Text = "Hata Pozisyonu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(826, 125);
            label7.Name = "label7";
            label7.Size = new Size(65, 15);
            label7.TabIndex = 14;
            label7.Text = "---------->";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(731, 208);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 15;
            label8.Text = "Çıktılar....";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(73, 162);
            label9.Name = "label9";
            label9.Size = new Size(26, 15);
            label9.TabIndex = 16;
            label9.Text = "LSB";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(217, 162);
            label10.Name = "label10";
            label10.Size = new Size(31, 15);
            label10.TabIndex = 17;
            label10.Text = "MSB";
            // 
            // Form1
            // 
            ClientSize = new Size(1064, 365);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(inputTextBox);
            Controls.Add(encodeButton);
            Controls.Add(memoryListBox);
            Controls.Add(errorPosTextBox);
            Controls.Add(errorButton);
            Controls.Add(checkButton);
            Controls.Add(outputLabel);
            Controls.Add(generalParityTextBox);
            Name = "Form1";
            Text = "Hamming SEC-DED Simülatörü";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}