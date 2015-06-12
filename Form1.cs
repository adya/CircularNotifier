using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularNotifierControl
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(cn);
            cn.SetThickLines(0,2,5);
            cn.Offset = 20;
            cn.Rotation = 18;
        }

        private void bAddEvent_Click(object sender, EventArgs e)
        {
            cn.AddEvent(rnd.Next(cn.Sectors), rnd.Next(cn.RingsCount), GetRandomColor());
        } 

        private Color GetRandomColor()
        {
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            // The error is here
        }

        private void bAddSector_Click(object sender, EventArgs e)
        {
            cn.Sectors++;   
        }

        private void bRemoveSector_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Sectors--;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
             cn.Size = new Size(this.Width - 40, this.Height - 90);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
