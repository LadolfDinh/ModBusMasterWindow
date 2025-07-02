namespace WinFormsApp4
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
            components = new System.ComponentModel.Container();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            progressBar1 = new ProgressBar();
            groupBox1 = new GroupBox();
            textBox10 = new TextBox();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            groupBox2 = new GroupBox();
            button2 = new Button();
            textBox2 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            groupBox3 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            label3 = new Label();
            bindingSource1 = new BindingSource(components);
            label4 = new Label();
            groupBox4 = new GroupBox();
            textBox4 = new TextBox();
            button11 = new Button();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox8 = new TextBox();
            label11 = new Label();
            textBox9 = new TextBox();
            label12 = new Label();
            textBox11 = new TextBox();
            comboBox3 = new ComboBox();
            bindingSource2 = new BindingSource(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(37, 53);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(107, 28);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "9600", "115200" });
            comboBox2.Location = new Point(176, 53);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(102, 28);
            comboBox2.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(331, 30);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(94, 40);
            progressBar1.TabIndex = 2;
            progressBar1.Click += progressBar1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox10);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(28, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 201);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "send";
            // 
            // textBox10
            // 
            textBox10.Enabled = false;
            textBox10.Location = new Point(6, 82);
            textBox10.Multiline = true;
            textBox10.Name = "textBox10";
            textBox10.ReadOnly = true;
            textBox10.Size = new Size(238, 78);
            textBox10.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(150, 166);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 26);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 70);
            textBox1.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(6, 82);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(238, 78);
            textBox3.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(301, 106);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 201);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "recieved";
            // 
            // button2
            // 
            button2.Location = new Point(150, 166);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "read";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(6, 26);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(238, 97);
            textBox2.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new Point(451, 26);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "open";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(451, 61);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 6;
            button4.Text = "close";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 30);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 7;
            label1.Text = "port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 30);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 8;
            label2.Text = "baud rate";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(button10);
            groupBox3.Controls.Add(button9);
            groupBox3.Controls.Add(button8);
            groupBox3.Controls.Add(button7);
            groupBox3.Controls.Add(button6);
            groupBox3.Controls.Add(button5);
            groupBox3.Location = new Point(28, 344);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(632, 94);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "controler";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(427, 23);
            label7.Name = "label7";
            label7.Size = new Size(26, 20);
            label7.TabIndex = 8;
            label7.Text = "K3";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(217, 23);
            label6.Name = "label6";
            label6.Size = new Size(26, 20);
            label6.TabIndex = 7;
            label6.Text = "K2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 23);
            label5.Name = "label5";
            label5.Size = new Size(26, 20);
            label5.TabIndex = 6;
            label5.Text = "K1";
            // 
            // button10
            // 
            button10.Location = new Point(527, 53);
            button10.Name = "button10";
            button10.Size = new Size(94, 29);
            button10.TabIndex = 5;
            button10.Text = "on";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Location = new Point(427, 53);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 4;
            button9.Text = "off";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.Location = new Point(317, 53);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 3;
            button8.Text = "on";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new Point(217, 53);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 2;
            button7.Text = "off";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(109, 53);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 1;
            button6.Text = "on";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(9, 53);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 0;
            button5.Text = "off";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.Location = new Point(666, 367);
            label3.Name = "label3";
            label3.Size = new Size(96, 52);
            label3.TabIndex = 12;
            label3.Text = "RUN";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Location = new Point(768, 367);
            label4.Name = "label4";
            label4.Size = new Size(96, 52);
            label4.TabIndex = 13;
            label4.Text = "STOP";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox4);
            groupBox4.Controls.Add(button11);
            groupBox4.Controls.Add(textBox5);
            groupBox4.Location = new Point(741, 30);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(147, 25);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "CRC-16";
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Location = new Point(6, 57);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(187, 24);
            textBox4.TabIndex = 2;
            // 
            // button11
            // 
            button11.Location = new Point(53, 87);
            button11.Name = "button11";
            button11.Size = new Size(94, 29);
            button11.TabIndex = 1;
            button11.Text = "caculate";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 26);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(187, 25);
            textBox5.TabIndex = 0;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(574, 45);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(61, 27);
            textBox6.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(574, 22);
            label8.Name = "label8";
            label8.Size = new Size(97, 20);
            label8.TabIndex = 16;
            label8.Text = "slave address";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(574, 83);
            label9.Name = "label9";
            label9.Size = new Size(56, 20);
            label9.TabIndex = 18;
            label9.Text = "funtion";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(574, 136);
            label10.Name = "label10";
            label10.Size = new Size(102, 20);
            label10.TabIndex = 20;
            label10.Text = "start adddress";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(574, 159);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(61, 27);
            textBox8.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(574, 193);
            label11.Name = "label11";
            label11.Size = new Size(132, 20);
            label11.TabIndex = 22;
            label11.Text = "number of register";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(574, 218);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(61, 27);
            textBox9.TabIndex = 21;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(574, 255);
            label12.Name = "label12";
            label12.Size = new Size(76, 20);
            label12.TabIndex = 24;
            label12.Text = "data write";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(574, 280);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(231, 27);
            textBox11.TabIndex = 23;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "16", "3" });
            comboBox3.Location = new Point(574, 106);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(102, 28);
            comboBox3.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 450);
            Controls.Add(comboBox3);
            Controls.Add(label12);
            Controls.Add(textBox11);
            Controls.Add(label11);
            Controls.Add(textBox9);
            Controls.Add(label10);
            Controls.Add(textBox8);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(textBox6);
            Controls.Add(groupBox4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(progressBar1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Absolute Serial Comunicating Exercuter";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ProgressBar progressBar1;
        private GroupBox groupBox1;
        private Button button1;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private Button button2;
        private TextBox textBox2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private GroupBox groupBox3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private BindingSource bindingSource1;
        public Label label3;
        public Label label4;
        private TextBox textBox3;
        private GroupBox groupBox4;
        private TextBox textBox4;
        private Button button11;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox8;
        private Label label11;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label12;
        private TextBox textBox11;
        private ComboBox comboBox3;
        private BindingSource bindingSource2;
    }
}
