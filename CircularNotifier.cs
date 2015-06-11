using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Drawing.Drawing2D;


///TODO: Set Control ratio to 1:1

namespace CircularNotifier
{
    public partial class CircularNotifier : UserControl, INotifyPropertyChanged
    {

        // For fields description see properties below.

        private int period;
        private int sectors;
        private int rings;
        private int rotation;


        /// <summary>
        /// Inner array which stores flags for each line, which when set to true indicates that the line will be thick otherwise it will be thin.
        /// </summary>
        private bool[] linesType;


        private Rectangle drawingArea;
        Point center;

        private int offset;
        private int ringsGap;
        private int ringsMinWidth;
        
        private Color ringsColor;
        private float ringsThickness;
        private Pen ringsPen; // pen to draw rings


        private Color linesColor;
        private float linesThickness;
        private float linesThickFactor; // thickness factor to make lines thicker
        private Pen linesPen; // pen to draw sector lines

        public CircularNotifier()
        {
            InitializeComponent();
            Sectors = 12;
            Rings = 10;
            Period = 500;
            Rotation = 0;
            linesType = new bool[Sectors];

            Offset = 10;
            RingsGap = 25;
            RingsMinWidth = 100;

            RingsColor = Color.Black;
            RingsThickness = 1;
            ringsPen = new Pen(RingsColor, RingsThickness);

            LinesColor = Color.Black;
            LinesThickness = 1;
            linesThickFactor = 1.75f;
            linesPen = new Pen(LinesColor, LinesThickness);

            CalculateDrawingArea();
            
            PropertyChanged += CircularNotifier_PropertyChanged;

            
            
        }

        /// <summary>
        /// Returns Array of indexes of lines that should be drawn thick. <para/>
        /// Note: Use methods <see cref="CircularNotifier.SetThickLines(int[])"/> and <see cref="CircularNotifier.SetThinLines(int[])"/> to easy set up different lines.
        /// </summary>
        public int[] ThickLines
        {
            get
            {
                List<int> indexes = new List<int>();
                for (int i = 0; i < Sectors; i++) // no ways to insert LINQ because we need to get indexes.
                {
                    if (linesType[i])
                        indexes.Add(i);
                }
                return indexes.ToArray();
            }
        }


        /// <summary>
        /// The period of time measured in ms between shifting sectors inside the circle.
        /// </summary>
        public int Period
        {
            get { return period; }
            set { SetField(ref period, value); }
        }
        
        /// <summary>
        /// Total number of sectors in circles.
        /// </summary>
        public int Sectors
        {
            get { return sectors; }
            set { SetField(ref sectors, value); }
        }
        
        /// <summary>
        /// Number of rings in circle.
        /// </summary>
        public int Rings
        {
            get { return rings; }
            set { SetField(ref rings, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Rotation
        {
            get { return rotation; }
            set { SetField(ref rotation, value); }
        }

        /// <summary>
        /// Offset of the drawing area.
        /// </summary>
        public int Offset
        {
            get { return offset; }
            set { SetField(ref offset, value); }
        }

        public int RingsMinWidth
        {
            get { return ringsMinWidth; }
            set { SetField(ref ringsMinWidth, value); }
        }

        #region Drawing properties

        public Color RingsColor
        {
            get { return ringsColor; }
            set { SetField(ref ringsColor, value); }
        }

        public float RingsThickness
        {
            get { return ringsThickness; }
            set { SetField(ref ringsThickness, value); }
        }

        public int RingsGap
        {
            get { return ringsGap; }
            set { SetField(ref ringsGap, value); }
        }

        public Color LinesColor
        {
            get { return linesColor; }
            set { SetField(ref linesColor, value); }
        }

        public float LinesThickness
        {
            get { return linesThickness; }
            set { SetField(ref linesThickness, value); }
        }

        #endregion

        /// <summary>
        /// Generic property setter. Used to notify subscribers about changed properties.
        /// </summary>
        /// <param name="field">Field managed by calling property.</param>
        /// <param name="value">Value given to the property.</param>
        /// <param name="propertyName">Name of the property. (Requires .Net 4.5 in order to be able to use [CallerMemberName])</param>
        /// <returns> Returns true if new value was set to the property otherwise (the same value) false.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        /// <summary>
        /// Sets line type to Thin at given indexes
        /// </summary>
        /// <param name="indexes"></param>
        public void SetThinLines(params int[] indexes)
        {
            foreach (int index in indexes)
            {
                if (index >= 0 && index < Sectors)
                    linesType[index] = false;
                
            }
            Invalidate();
        }

        /// <summary>
        /// Sets line type to Thick at given indexes
        /// </summary>
        /// <param name="indexes"></param>
        public void SetThickLines(params int[] indexes)
        {
            foreach (int index in indexes)
            {
                if (index >= 0 && index < Sectors)
                {
                    linesType[index] = true;
                }
            }
            Invalidate();
        }

        #region Drawing methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawRings(e.Graphics);
            DrawSectorLines(e.Graphics);
            //DrawSectors(e.Graphics);
        }

        private void DrawRings(Graphics g)
        {
            int ringX, ringY, ringWidth, ringHeight;
            for (int i = 0; i < Rings+1; i++)
            {
                ringX = drawingArea.X + RingsGap * i;
                ringY = drawingArea.Y + RingsGap * i;
                ringWidth = drawingArea.Width - 2 * RingsGap * i;
                ringHeight = drawingArea.Height - 2 * RingsGap * i;
                if (ringWidth < RingsMinWidth || ringHeight < RingsMinWidth) // Not enough space to fit all rings 
                    return;
                g.DrawEllipse(ringsPen, ringX, ringY, ringWidth, ringHeight);    
            }
        }

        private void DrawSectorLines(Graphics g)
        {
            Point lineStart = new Point(drawingArea.X + drawingArea.Width/2, drawingArea.Y);
            lineStart = RotatePoint(lineStart, Rotation);
            int lineLength = drawingArea.Width;
            int angle = 360 / Sectors;
            for (int i = 0; i < Sectors; i++)
            {
                
                if (linesType[i] || linesType[(i + Sectors/2)%Sectors]) ///TODO: Here's the place where thick lines are determined.
                    linesPen.Width = LinesThickness * linesThickFactor;
                else linesPen.Width = LinesThickness;
                g.DrawLine(linesPen, lineStart, center);
                lineStart = RotatePoint(lineStart, angle);
            }
    
        }

        //private void DrawSectors(Graphics g)
        //{
        //    Pen p = new Pen(Color.Red);
        //    Rectangle OuterRect = new Rectangle(100, 100, 200, 200);
        //    float StartAngle = 
        //    g.DrawRectangle(p, OuterRect);
        //    g.DrawArc(p, OuterRect, 90, 60);
        //}

        private Point RotatePoint(Point point, double angle)
        {
            double angleRad = angle * Math.PI / 180;
            /* p'x = cos(theta) * (px-ox) - sin(theta) * (py-oy) + ox
             * p'y = sin(theta) * (px-ox) + cos(theta) * (py-oy) + oy  */
            double x = Math.Cos(angleRad) * (point.X - center.X) - Math.Sin(angleRad) * (point.Y - center.Y) + center.X;
            double y = Math.Sin(angleRad) * (point.X - center.X) + Math.Cos(angleRad) * (point.Y - center.Y) + center.Y;
            return new Point((int)Math.Round(x),(int)Math.Round(y));
        }

        #endregion

        private void UpdateLinesType()
        {
            bool[] oldLinesType = (bool[])linesType.Clone();
            linesType = new bool[Sectors];
            Array.Copy(oldLinesType, linesType, Math.Min(linesType.Length, oldLinesType.Length));
        }

        private void CalculateDrawingArea()
        {
            drawingArea = new Rectangle(Offset, Offset, Width - 2 * Offset, Height - 2 * Offset);
            center = new Point(drawingArea.Left + drawingArea.Width / 2, drawingArea.Top + drawingArea.Height / 2);
        }

        private void CalculateRings()
        {

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            CalculateDrawingArea();
        }

        #region INotifyPropertyChanged Implementation


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CircularNotifier_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            object value = this.GetType().GetProperty(e.PropertyName).GetValue(this);
            string name = e.PropertyName;
            if (name == null) return;
            Console.WriteLine(name + " changed to " + value);
            /*
             * Update ringsPen if changed property either ringsThickness or ringsColor;
             * Recreate linesType when Sectors changed;
             * Redraw when Sectors changed;
             * Redraw when Rings changed;
             * Redraw when RingsGap changed;
             * Redraw when Rotation changed;
             */

            if (name.Equals("Sectors"))
            {
                UpdateLinesType();
            }

            Invalidate();
        }

        #endregion
    }

    private class Ring
    {

        public Point Center { get; set; }
        public int OuterRadius { get; set; }
        public int InnerRadius { get; set; }

        public Pen RingPen { get; set; }

        public int Height { get { return OuterRadius - InnerRadius; } }

        public void Render(Graphics g) {
            g.DrawEllipse(RingPen, Center.X - OuterRadius, Center.Y - OuterRadius, OuterRadius * 2, OuterRadius * 2);
            g.DrawEllipse(RingPen, Center.X - InnerRadius, Center.Y - InnerRadius, InnerRadius * 2, OuterRadius * 2);
        }
    }

}
