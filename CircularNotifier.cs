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

namespace CircularNotifierControl
{
    public partial class CircularNotifier : UserControl, INotifyPropertyChanged
    {
        
        #region Fields
        
        // For fields description see properties below.

        private int period;
        private int sectors;
        private int ringsCount;
        private int rotation;


        private Ring[] rings;
        private List<RingSlice> slices;
        private SectorLine[] sectorLines;

        private Rectangle drawingArea;
        private Point center;

        private int width; // these width and height used to store prev size when resizing control.
        private int height;
        private int offset;
        private bool isMeasured;

        private bool ringsWidthAuto;
        private int ringsWidth;
        private int ringsMinInnerDiameter;
        
        private Color ringsColor;
        private float ringsThickness;
        private Pen ringsPen; // pen to draw rings


        private Color linesColor;
        private Color linesThickColor;
        private float linesThickness;
        private float linesThickFactor; // thickness factor to make lines thicker

        #endregion

        public CircularNotifier()
        {
            Sectors = 12;
            RingsCount = 8;
            Period = 500;
            Rotation = 0;

            sectorLines = null;
            rings = null;
            slices = new List<RingSlice>();

            Offset = 10;
            RingsWidth = 25;
            RingsWidthAuto = true;
            RingsMinInnerDiamter = 100;

            RingsColor = Color.Black;
            RingsThickness = 1;
            ringsPen = new Pen(RingsColor, RingsThickness);

            LinesColor = Color.Black;
            LinesThickColor = LinesColor;
            LinesThickness = 1;
            LinesThickFactor = 2f;

            ResizeRedraw = true;
            InitializeComponent();

            PropertyChanged += ValidateProperties_PropertyCahnged;
            PropertyChanged += UpdateCircularNotifier_PropertyChanged;
        }

        #region Properties

        /// <summary>
        /// Returns array of indexes of lines that should be drawn thick. <para/>
        /// Note: Use methods <see cref="CircularNotifier.SetThickLines(int[])"/> and <see cref="CircularNotifier.SetThinLines(int[])"/> to easy set up different lines.
        /// </summary>
        public int[] ThickLines
        {
            get
            {
                List<int> indexes = new List<int>();
                for (int i = 0; i < Sectors; i++) // no ways to insert LINQ because we need to get indexes.
                {
                    if (sectorLines[i].IsThick)
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
        public int RingsCount
        {
            get { return ringsCount; }
            set { SetField(ref ringsCount, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Rotation
        {
            get { return rotation; }
            set { SetField(ref rotation, value); }
        }

        #region Measurement properties
        /// <summary>
        /// Offset of the drawing area.
        /// </summary>
        public int Offset
        {
            get { return offset; }
            set { SetField(ref offset, value); }
        }

        public int RingsWidth
        {
            get { return ringsWidth; }
            set { SetField(ref ringsWidth, value); }
        }

        public bool RingsWidthAuto
        {
            get { return ringsWidthAuto; }
            set { SetField(ref ringsWidthAuto, value); }
        }

        /// <summary>
        /// Gets or Sets minimum diamter of the most inner ring.
        /// </summary>
        public int RingsMinInnerDiamter
        {
            get { return ringsMinInnerDiameter; }
            set { SetField(ref ringsMinInnerDiameter, value); }
        }

        #endregion

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

        public Color LinesThickColor
        {
            get { return linesThickColor; }
            set { SetField(ref linesThickColor, value); }
        }

        public float LinesThickFactor
        {
            get { return linesThickFactor; }
            set { SetField(ref linesThickFactor, value); }
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
        /// Sets line type to Thin at given indexes.
        /// </summary>
        /// <param name="indexes"> Set of indexes of sectors in forst half the circle. </param>
        public void SetThinLines(params int[] indexes)
        {
            foreach (int index in indexes)
            {
                if (index >= 0 && index < Sectors/2)
                {
                    sectorLines[index].IsThick = false;
                    sectorLines[(index + Sectors / 2) % Sectors].IsThick = false;
                }
                
            }
            Invalidate();
        }

        /// <summary>
        /// Sets line type to Thick at given indexes.
        /// </summary>
        /// <param name="indexes">Set of indexes of sectors in forst half the circle. </param>
        public void SetThickLines(params int[] indexes)
        {
            foreach (int index in indexes)
            {
                if (index >= 0 && index < Sectors/2)
                {
                    sectorLines[index].IsThick = true;
                    sectorLines[(index + Sectors / 2) % Sectors].IsThick = true;
                }
            }
            Invalidate();
        }
        #endregion
     
        #region Drawing methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawRingSlices(e.Graphics);
            DrawRings(e.Graphics);
            DrawSectorLines(e.Graphics);
        }

        private void DrawRings(Graphics g)
        {
            foreach (Ring r in rings)
            {
                r.Render(g);
            }   
        }

        private void DrawSectorLines(Graphics g)
        {
            foreach (SectorLine line in sectorLines)
            {
                line.Render(g);
            }       
        }

        private void DrawRingSlices(Graphics g)
        {
            foreach (RingSlice slice in slices)
            {
                slice.Render(g);    
            }
        }
     
        #endregion

        #region Measure & Update methods

        private void Measure()
        {
            MeasureDrawingArea();
            MeasureSectorLines();
            MeasureRings();
            isMeasured = true;
        }

        private void UpdateSectorLines()
        {
            for (int i = 0; i < sectorLines.Length; i++)
            {
                sectorLines[i].LineColor = LinesColor;
                sectorLines[i].LineThickColor = LinesThickColor;
                sectorLines[i].Thickness = LinesThickness;
                sectorLines[i].ThickFactor = LinesThickFactor;
            }
        }

        private void UpdateRings()
        {
            for (int i = 0; i < rings.Length; i++)
            {
                rings[i].DrawingPen = ringsPen;
                rings[i].Sectors = Sectors;
                rings[i].RotationAngle = Rotation;
            }
        }

        private void MeasureSlices()
        {
            ///TODO: Update slices
            RingSlice[] newSlices = new RingSlice[slices.Count];
            for (int i = 0; i < slices.Count; i++)
            {
                RingSlice tmp = slices[i];
                int ringI = tmp.SlicedRingIndex;
                int sectorI = tmp.SlicedSectorIndex;

                newSlices[i] = rings[ringI].GetSlice(sectorI, tmp.FillColor);
            }
            slices.Clear();
            slices.AddRange(newSlices);
        }

        private void MeasureSectorLines()
        {
            bool[] prevLinesType = (sectorLines!= null ? sectorLines.Select(x=>x.IsThick).ToArray() : new bool[Sectors]);
            sectorLines = new SectorLine[Sectors];
            PointF lineStart = new PointF(drawingArea.X + drawingArea.Width / 2, drawingArea.Y);
            lineStart = RotatePoint(lineStart, Rotation);
            int lineLength = drawingArea.Width;
            float angle = 360.0f / Sectors;
            for (int i = 0; i < Sectors; i++)
            {
                sectorLines[i] = new SectorLine(center, lineStart, LinesColor, LinesThickness, LinesThickColor, LinesThickFactor);
                lineStart = RotatePoint(lineStart, angle);
            }

            int length = Math.Min(prevLinesType.Length, Sectors);
            for (int i = 0; i < length/2; i++)
                sectorLines[i].IsThick = prevLinesType[i];
            for (int i = 0; i < Sectors/2; i++)
			{
                sectorLines[(i + Sectors / 2) % Sectors].IsThick = sectorLines[i].IsThick;
			}
        }

        private PointF RotatePoint(PointF point, double angle)
        {
            double angleRad = angle * Math.PI / 180.0d;
            /* p'x = cos(theta) * (px-ox) - sin(theta) * (py-oy) + ox
             * p'y = sin(theta) * (px-ox) + cos(theta) * (py-oy) + oy  */
            double x = Math.Cos(angleRad) * (point.X - center.X) - Math.Sin(angleRad) * (point.Y - center.Y) + center.X;
            double y = Math.Sin(angleRad) * (point.X - center.X) + Math.Cos(angleRad) * (point.Y - center.Y) + center.Y;
            return new PointF((float)x, (float)y);
        }

        private void MeasureDrawingArea()
        {
            drawingArea = new Rectangle(Offset, Offset, Width - 2 * Offset, Height - 2 * Offset);
            center = new Point(drawingArea.Left + drawingArea.Width / 2, drawingArea.Top + drawingArea.Height / 2);
        }

        private void MeasureRings()
        {
            RingsWidth = (RingsWidthAuto ? ((drawingArea.Width - RingsMinInnerDiamter) / 2) / RingsCount : RingsWidth);
            int outerRadius = drawingArea.Width/2,
                innerRadius = drawingArea.Width/2 - RingsWidth;
            List<Ring> tmpRings = new List<Ring>();
            for (int i = 0; i < RingsCount; i++)
            {

                tmpRings.Add(new Ring(center, outerRadius, innerRadius, Sectors, Rotation, ringsPen, i, Ring.DrawingMethod.OUTER));
                outerRadius = innerRadius;
                innerRadius = innerRadius - RingsWidth;
                
                if (innerRadius < RingsMinInnerDiamter / 2) // Not enough space to fit all rings 
                    break;
            }
            rings = tmpRings.ToArray();
            
            rings[rings.Length - 1].RingDrawingMethod = Ring.DrawingMethod.FULL;
        }

        #endregion

        /// <summary>
        /// Main method of the CircularNotifier. Adds a slice to specified ring in specified sector.
        /// </summary>
        /// <param name="sector">Chosen sector where the event will be placed.</param>
        /// <param name="ring">Chosen ring where the event will be placed.</param>
        /// <param name="color">Color of the event's slice.</param>
        public void AddEvent(int sector, int ring, Color color)
        {
            if (ring < 0 || ring >= rings.Length) return;
            if (sector < 0 || sector >= Sectors) return;

            RingSlice slice = slices.SingleOrDefault((x) => x.SlicedSectorIndex == sector && x.SlicedRingIndex == ring);
            if (slice == null)
                slices.Add(rings[ring].GetSlice(sector, color));
            else
                slice.FillColor = color;
            Invalidate();
        }

        /// <summary>
        /// Main method of the CircularNotifier. Adds a slice to the most outer ring in specified sector.
        /// </summary>
        /// <param name="sector">Chosen sector where the event will be placed.</param>
        /// <param name="color">Color of the event's slice.</param>
        public void AddEvent(int sector, Color color)
        {
            AddEvent(sector, 0, color);
        }

        #region INotifyPropertyChanged Implementation


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateCircularNotifier_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            object value = this.GetType().GetProperty(e.PropertyName).GetValue(this);
            string name = e.PropertyName;
            if (name == null) return;
            Console.WriteLine(name + " changed to " + value);
            /*
             * Measure ALL if Offset changed;
             * Update ringsPen and all Rings when either RingsThickness or RingsColor changed;
             * Measure Lines, Update Rings and Slices when either Sectors or Rotation changed;
             * Measure Rings and Slices when RingsGap changed if RingsGapAuto is false;
             * Measure Rings and Slices when either RingsMinInnerDiameter or RingsCount changed;
             * Update Lines when any of the Lines drawing properties changed;
             */
            if (name.Equals("Offset"))
            {
                Measure();
            }
            else if (name.Equals("Sectors") || name.Equals("Rotation"))
            {
                MeasureSectorLines();
                UpdateRings();
                MeasureSlices();
            }
            else if (name.Equals("RingsWidth"))
            {
                if (!RingsWidthAuto)
                {
                    MeasureRings();
                    MeasureSlices();
                }

            }
            else if (name.Equals("RingsWidthAuto"))
            {
                MeasureRings();
                MeasureSlices();
            }
            else if (name.Equals("RingsMinInnerDiameter") || name.Equals("RingsCount"))
            {
                MeasureRings();
                MeasureSlices();
            }
            else if (name.Equals("LinesThickness") || name.Equals("LinesColor") || name.Equals("LinesThickColor") || name.Equals("LinesThickFactor"))
            {
                if (!isMeasured) return;
                UpdateSectorLines();
            }
            else if (name.Equals("RingsThickness") || name.Equals("RingsColor"))
            {
                ringsPen.Width = RingsThickness;
                ringsPen.Color = RingsColor;
                UpdateRings();
            }

            

            Invalidate();
        }

        private void ValidateProperties_PropertyCahnged(object sender, PropertyChangedEventArgs e)
        {
            object value = this.GetType().GetProperty(e.PropertyName).GetValue(this);
            string name = e.PropertyName;
            if (name == null) return;

            if (name.Equals("Offset"))
            {
                // probably it can be negative
            }
            else if (name.Equals("Sectors") || name.Equals("Rotation"))
            {
                if (Sectors < 0)
                {
                    throw new ArgumentException("Sectors number can't be negative.");
                }
                int prevSectors = rings[0].Sectors; // obtain old value of sectors through not yet updated rings.
                if (Sectors == 1) Sectors = (prevSectors > 1 ? 0 : 2); // jump over 1 because circle can't have only 1 sector.

                if (Rotation % 15 != 0)
                {
                    Rotation = (int)Math.Round(Rotation / 15.0) * 15;
                }
            }
            else if (name.Equals("RingsWidth"))
            {
                if (RingsWidth <= 3)
                {
                    throw new ArgumentException("Rings width must be greater than 0.");
                }
            }
            else if (name.Equals("RingsMinInnerDiameter") || name.Equals("RingsCount"))
            {
                if (RingsMinInnerDiamter <= 0)
                {
                    throw new ArgumentException("Rings minimum inner diameter  must be positive number.");
                }
                if (RingsCount <= 0)
                {
                    throw new ArgumentException("There must be at least one ring.");
                }
            }
            else if (name.Equals("LinesThickness") || name.Equals("LinesColor") || name.Equals("LinesThickColor") || name.Equals("LinesThickFactor"))
            {
                if (LinesThickness <= 0) throw new ArgumentException("Thickness of the lines  must be positive number.");
                if (LinesThickFactor <= 1) throw new ArgumentException("Thick factor must be greater than 1 in order to be able to make line thicker.");
            }
            else if (name.Equals("RingsThickness") || name.Equals("RingsColor"))
            {
                if (RingsThickness <= 0) throw new ArgumentException("Thickness of the rings must be positive number.");
            }
        }

        #endregion

        private void CircularNotifier_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width != this.Height)
            {
                this.Width = Math.Min(this.Width, this.Height);
                this.Height = Math.Min(this.Width, this.Height);
            }
            else
            {
                base.OnResize(e);
                Measure();
            }
        }
    }
}
