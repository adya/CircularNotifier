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
            this.bAddEvent = new System.Windows.Forms.Button();
            this.cn = new CircularNotifierControl.CircularNotifier();
            this.bAddSector = new System.Windows.Forms.Button();
            this.bRemoveSector = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAddEvent
            // 
            this.bAddEvent.Location = new System.Drawing.Point(12, 12);
            this.bAddEvent.Name = "bAddEvent";
            this.bAddEvent.Size = new System.Drawing.Size(136, 35);
            this.bAddEvent.TabIndex = 0;
            this.bAddEvent.Text = "Add Random Event";
            this.bAddEvent.UseVisualStyleBackColor = true;
            this.bAddEvent.Click += new System.EventHandler(this.bAddEvent_Click);
            // 
            // cn
            // 
            this.cn.BackColor = System.Drawing.Color.White;
            this.cn.LinesColor = System.Drawing.Color.Black;
            this.cn.LinesThickColor = System.Drawing.Color.Black;
            this.cn.LinesThickFactor = 1.75F;
            this.cn.Location = new System.Drawing.Point(12, 53);
            this.cn.Name = "cn";
            this.cn.Offset = 10;
            this.cn.Period = 500;
            this.cn.RingsColor = System.Drawing.Color.Black;
            this.cn.RingsMinInnerDiamter = 100;
            this.cn.Rotation = 0;
            this.cn.Sectors = 12;
            this.cn.Size = new System.Drawing.Size(460, 460);
            this.cn.TabIndex = 1;
            // 
            // bAddSector
            // 
            this.bAddSector.Location = new System.Drawing.Point(154, 12);
            this.bAddSector.Name = "bAddSector";
            this.bAddSector.Size = new System.Drawing.Size(60, 35);
            this.bAddSector.TabIndex = 2;
            this.bAddSector.Text = "+ Sector";
            this.bAddSector.UseVisualStyleBackColor = true;
            this.bAddSector.Click += new System.EventHandler(this.bAddSector_Click);
            // 
            // bRemoveSector
            // 
            this.bRemoveSector.Location = new System.Drawing.Point(220, 12);
            this.bRemoveSector.Name = "bRemoveSector";
            this.bRemoveSector.Size = new System.Drawing.Size(60, 35);
            this.bRemoveSector.TabIndex = 2;
            this.bRemoveSector.Text = "- Sector";
            this.bRemoveSector.UseVisualStyleBackColor = true;
            this.bRemoveSector.Click += new System.EventHandler(this.bRemoveSector_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(484, 531);
            this.Controls.Add(this.bRemoveSector);
            this.Controls.Add(this.bAddSector);
            this.Controls.Add(this.cn);
            this.Controls.Add(this.bAddEvent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Circular Notifier Demo";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAddEvent;
        private CircularNotifier cn;
        private System.Windows.Forms.Button bAddSector;
        private System.Windows.Forms.Button bRemoveSector;



    }
}

