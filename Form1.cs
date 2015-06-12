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
            nudSectors.Value = cn.Sectors;
            nudRings.Value = cn.RingsCount;
            nudRotation.Value = cn.Rotation;
                        
            nudPeriod.Value = cn.Period;
            cbAutoStart.Checked = cn.AutoStart;
            cbAutoStop.Checked = cn.AutoStop;

            nudLineThickness.Value = (decimal)cn.LinesThickness;
            nudLineThickFactor.Value = (decimal)cn.LinesThickFactor;
            nudRingThickness.Value = (decimal)cn.RingsThickness;

            nudRingsWidth.Value = cn.RingsWidth;
            nudMinInner.Value = cn.RingsMinInnerDiameter;
            nudOffset.Value = cn.Offset;
            cbAutoRingWidth.Checked = cn.RingsWidthAuto;


            cn.PropertyChanged += cn_PropertyChanged;
        }

        private void cn_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            object value = cn.GetType().GetProperty(e.PropertyName).GetValue(cn);
            string name = e.PropertyName;
            if (name == null) return;

            if (name.Equals("IsRunning"))
            {
                bTimer.Text = (cn.IsRunning ? "Stop" : "Start");
                bTimer.BackColor = (cn.IsRunning ? Color.IndianRed : Color.LimeGreen);
            }
        }

        private string[] CreateLinesArray(){
            string[] lines = new string[cn.Sectors];
            for (int i = 0; i < cn.Sectors; i++)
            {
                lines[i] = "Line " + i;
            }
            return lines;
        }

        private void UpdateLinesList()
        {
            clbThickLines.Items.Clear();
            clbThickLines.Items.AddRange(CreateLinesArray());
            foreach (var i in cn.ThickLines)
            {
                clbThickLines.SetItemChecked(i, true);
            }
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }
        private void AddEvent()
        {
            if (cbOuterOnly.Checked)
                cn.AddEvent(rnd.Next(cn.Sectors), 0, GetRandomColor());
            else
                cn.AddEvent(rnd.Next(cn.Sectors), rnd.Next(cn.RingsCount), GetRandomColor());
        }

        private void bAddEvent_Click(object sender, EventArgs e)
        {
            AddEvent();
        }

        private void bAdd10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                AddEvent();
        }

        private void bAddSectorsEvents_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cn.Sectors; i++)
                if (cbOuterOnly.Checked)
                    cn.AddEvent(i, 0, GetRandomColor());
                else
                    cn.AddEvent(i, rnd.Next(cn.RingsCount), GetRandomColor());
        }
        

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
             cn.Size = new Size(this.Width - 260, this.Height - 60);
             nudRings.Value = cn.RingsCount;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudRings_ValueChanged(object sender, EventArgs e)
        {
            cn.RingsCount = (int)nudRings.Value;
            if (cn.RingsWidthAuto) nudRingsWidth.Value = cn.RingsWidth;
        }

        private void nudSectors_ValueChanged(object sender, EventArgs e)
        {
            cn.Sectors = (int)nudSectors.Value;
            UpdateLinesList();
        }

        private void nudLineThickness_ValueChanged(object sender, EventArgs e)
        {
            cn.LinesThickness = (float)nudLineThickness.Value;
        }

        private void nudLineThickFactor_ValueChanged(object sender, EventArgs e)
        {
            cn.LinesThickFactor = (float)nudLineThickFactor.Value;
        }

        private void nudRingThickness_ValueChanged(object sender, EventArgs e)
        {
            cn.RingsThickness = (float)nudRingThickness.Value;
        }

        private void nudRotation_ValueChanged(object sender, EventArgs e)
        {
            cn.Rotation = (int)nudRotation.Value;
            nudRotation.Value = cn.Rotation;
        }

        private void cbAutoRingWidth_CheckedChanged(object sender, EventArgs e)
        {
            nudRingsWidth.Enabled = !cbAutoRingWidth.Checked;
            cn.RingsWidthAuto = cbAutoRingWidth.Checked;
            nudRingsWidth.Value = cn.RingsWidth;
        }

        private void nudOffset_ValueChanged(object sender, EventArgs e)
        {
            cn.Offset = (int)nudOffset.Value;
        }

        private void nudMinInner_ValueChanged(object sender, EventArgs e)
        {
            cn.RingsMinInnerDiameter = (int)nudMinInner.Value;
            if (cn.RingsWidthAuto) nudRingsWidth.Value = cn.RingsWidth;
        }

        private void nudRingsWidth_ValueChanged(object sender, EventArgs e)
        {
            cn.RingsWidth = (int)nudRingsWidth.Value;
            nudRings.Value = cn.RingsCount;
        }

        private void nudPeriod_ValueChanged(object sender, EventArgs e)
        {
            cn.Period = (int)nudPeriod.Value;
        }

        private void clbThickLines_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                cn.SetThickLines(e.Index);
            else
                cn.SetThinLines(e.Index);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            cn.RemoveAllEvents();
        }

        private void bTimer_Click(object sender, EventArgs e)
        {
            bTimer.Text = (cn.IsRunning ? "Stop" : "Start");
            bTimer.BackColor = (cn.IsRunning ? Color.IndianRed : Color.LimeGreen);
            if (cn.IsRunning)
                cn.Stop();
            else
                cn.Start();
        }

        private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            cn.AutoStart = cbAutoStart.Checked;
        }

        private void cbAutoStop_CheckedChanged(object sender, EventArgs e)
        {
            cn.AutoStop = cbAutoStop.Checked;
        }

       

       

        
    }
}
