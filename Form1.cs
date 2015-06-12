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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.AddEvent(rnd.Next(cn.Sectors), rnd.Next(cn.RingsCount), GetRandomColor());        
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            // The error is here
        }  
    }
}
