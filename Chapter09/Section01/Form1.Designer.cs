namespace Section01 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            Button = new Button();
            label1 = new Label();
            tbOutput = new TextBox();
            nudNum1 = new NumericUpDown();
            nudNum2 = new NumericUpDown();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)nudNum1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNum2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Button
            // 
            Button.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Button.Location = new Point(35, 135);
            Button.Name = "Button";
            Button.Size = new Size(120, 53);
            Button.TabIndex = 0;
            Button.Text = "ボタン";
            Button.UseVisualStyleBackColor = true;
            Button.Click += Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(21, 19);
            label1.Name = "label1";
            label1.Size = new Size(166, 45);
            label1.TabIndex = 1;
            label1.Text = "Chapter09";
            // 
            // tbOutput
            // 
            tbOutput.Location = new Point(35, 232);
            tbOutput.Name = "tbOutput";
            tbOutput.Size = new Size(232, 23);
            tbOutput.TabIndex = 2;
            // 
            // nudNum1
            // 
            nudNum1.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudNum1.Location = new Point(35, 67);
            nudNum1.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudNum1.Name = "nudNum1";
            nudNum1.Size = new Size(120, 43);
            nudNum1.TabIndex = 3;
            // 
            // nudNum2
            // 
            nudNum2.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudNum2.Location = new Point(193, 67);
            nudNum2.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudNum2.Name = "nudNum2";
            nudNum2.Size = new Size(120, 43);
            nudNum2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(307, 161);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(616, 474);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(190, 378);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 647);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(nudNum2);
            Controls.Add(nudNum1);
            Controls.Add(tbOutput);
            Controls.Add(label1);
            Controls.Add(Button);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudNum1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNum2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button;
        private Label label1;
        private TextBox tbOutput;
        private NumericUpDown nudNum1;
        private NumericUpDown nudNum2;
        private PictureBox pictureBox1;
        private Button button1;
        private OpenFileDialog openFileDialog1;
    }
}
