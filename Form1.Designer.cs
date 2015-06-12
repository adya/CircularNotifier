namespace CircularNotifierControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.cn = new CircularNotifierControl.CircularNotifier();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Random Event";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cn
            // 
            this.cn.BackColor = System.Drawing.Color.White;
            this.cn.LinesColor = System.Drawing.Color.Black;
            this.cn.LinesThickColor = System.Drawing.Color.Black;
            this.cn.LinesThickFactor = 2F;
            this.cn.LinesThickness = 1F;
            this.cn.Location = new System.Drawing.Point(12, 53);
            this.cn.Name = "cn";
            this.cn.Offset = 10;
            this.cn.Period = 500;
            this.cn.RingsColor = System.Drawing.Color.Black;
            this.cn.RingsCount = 8;
            this.cn.RingsGap = 25;
            this.cn.RingsGapAuto = true;
            this.cn.RingsMinInnerDiamter = 100;
            this.cn.RingsThickness = 1F;
            this.cn.Rotation = 0;
            this.cn.Sectors = 12;
            this.cn.Size = new System.Drawing.Size(460, 460);
            this.cn.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(484, 531);
            this.Controls.Add(this.cn);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Circular Notifier Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private CircularNotifier cn;



    }
}

