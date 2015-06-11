using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularNotifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CircularNotifier cn = new CircularNotifier();
            cn.Size = this.Size;
            this.Controls.Add(cn);
            
            cn.SetThickLines(0,2,4,6);
            cn.Rotation = 0;
            cn.Sectors = 5;
            cn.Rings = 10;
            cn.RingsMinWidth = 50;
            
        }
    }
}
