namespace CalculatorDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            number1TextBox = new TextBox();
            number2TextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            computeButton = new Button();
            resultTextBox = new TextBox();
            label4 = new Label();
            operatorList = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 64);
            label1.Name = "label1";
            label1.Size = new Size(136, 37);
            label1.TabIndex = 0;
            label1.Text = "Number &1";
            // 
            // number1TextBox
            // 
            number1TextBox.Location = new Point(278, 58);
            number1TextBox.Name = "number1TextBox";
            number1TextBox.Size = new Size(450, 43);
            number1TextBox.TabIndex = 1;
            // 
            // number2TextBox
            // 
            number2TextBox.Location = new Point(278, 149);
            number2TextBox.Name = "number2TextBox";
            number2TextBox.Size = new Size(450, 43);
            number2TextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 155);
            label2.Name = "label2";
            label2.Size = new Size(136, 37);
            label2.TabIndex = 2;
            label2.Text = "Number &2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(131, 247);
            label3.Name = "label3";
            label3.Size = new Size(124, 37);
            label3.TabIndex = 4;
            label3.Text = "&Operator";
            // 
            // computeButton
            // 
            computeButton.Location = new Point(278, 334);
            computeButton.Name = "computeButton";
            computeButton.Size = new Size(450, 52);
            computeButton.TabIndex = 6;
            computeButton.Text = "&Compute";
            computeButton.UseVisualStyleBackColor = true;
            computeButton.Click += computeButton_Click;
            // 
            // resultTextBox
            // 
            resultTextBox.Enabled = false;
            resultTextBox.Font = new Font("Segoe UI", 20F);
            resultTextBox.Location = new Point(278, 442);
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(450, 87);
            resultTextBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(131, 480);
            label4.Name = "label4";
            label4.Size = new Size(88, 37);
            label4.TabIndex = 7;
            label4.Text = "Result";
            // 
            // operatorList
            // 
            operatorList.FormattingEnabled = true;
            operatorList.Location = new Point(278, 244);
            operatorList.Name = "operatorList";
            operatorList.Size = new Size(450, 45);
            operatorList.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 621);
            Controls.Add(operatorList);
            Controls.Add(resultTextBox);
            Controls.Add(label4);
            Controls.Add(computeButton);
            Controls.Add(label3);
            Controls.Add(number2TextBox);
            Controls.Add(label2);
            Controls.Add(number1TextBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Caclulator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox number1TextBox;
        private TextBox number2TextBox;
        private Label label2;
        private Label label3;
        private Button computeButton;
        private TextBox resultTextBox;
        private Label label4;
        private ComboBox operatorList;
    }
}
