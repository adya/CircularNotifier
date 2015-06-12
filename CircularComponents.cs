using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularNotifierControl
{

    interface IRenderable
    {
        void Render(Graphics g);
    }

    /// <summary>
    /// Represents the line which divides sectors.
    /// </summary>
    class SectorLine : IRenderable
    {
        /// <summary>
        /// Gets or Sets center point of the sector's parent circle.
        /// </summary>
        public PointF Center { get; set; }

        /// <summary>
        /// Gets or Sets point on the circle to which the line is heading.
        /// </summary>
        public PointF CirclePoint { get; set; }

        /// <summary>
        /// Gets or Sets index of the sector which is divided by the line.
        /// </summary>
        public int SectorIndex { get; set; }

        /// <summary>
        /// Gets or Sets flag which indicates whether the line should be thick.
        /// </summary>
        public bool IsThick { get; set; }

        /// <summary>
        /// Gets or Sets color of thin line.
        /// </summary>
        public Color LineColor { get; set; }

        /// <summary>
        /// Gets or Sets color of thick line.
        /// </summary>
        public Color LineThickColor { get; set; }

        /// <summary>
        /// Gets or Sets thickness of thin line.
        /// </summary>
        public float Thickness { get; set; }

        /// <summary>
        /// Gets or Sets thickness of thick line.
        /// </summary>
        public float ThickFactor { get; set; }

        public SectorLine(PointF center, PointF circlePoint, Color lineColor, float thickness)
            : this(center, circlePoint, lineColor, thickness, lineColor, 1.5f)
        {
        }
        public SectorLine(PointF center, PointF circlePoint, Color lineColor, float thickness, Color thickLineColor, float thicknessFactor)
        {
            Center = center;
            CirclePoint = circlePoint;
            LineColor = lineColor;
            Thickness = thickness;
            LineThickColor = thickLineColor;
            ThickFactor = thicknessFactor;
            IsThick = false;
        }

        public void Render(Graphics g)
        {
            using (Pen p = (IsThick ? new Pen(LineThickColor, Thickness * ThickFactor) :
                                     new Pen(LineColor, Thickness)))
            {
                g.DrawLine(p, CirclePoint, Center);
            }
        }
    }

    #region Rings and SliceRings

    /// <summary>
    /// Class that represents a ring which is calculated using center point, inner and outer ring's radius.<para/>
    /// </summary>
    class Ring : IRenderable
    {

        /// <summary>
        /// Gets center point of the ring.
        /// </summary>
        public PointF Center { get; private set; }
        /// <summary>
        /// Gets outer radius of the ring.
        /// </summary>
        public int OuterRadius { get; private set; }
        /// <summary>
        /// Gets inner radius of the ring.
        /// </summary>
        public int InnerRadius { get; private set; }
        /// <summary>
        /// Gets height of the ring.
        /// </summary>
        public int Height { get { return OuterRadius - InnerRadius; } }

        /// <summary>
        /// Gets index of the ring in <see cref="CircularNotifier"/>.
        /// </summary>
        public int RingIndex { get; private set; }

        /// <summary>
        /// Gets or Sets number of sectors of the ring in which it can be sliced.
        /// </summary>
        public int Sectors { get; set; }

        /// <summary>
        /// Gets or Sets base angle of the rotation.
        /// </summary>
        public float RotationAngle { get; set; }

        /// <summary>
        /// Gets or Sets drawing pen.
        /// </summary>
        public Pen DrawingPen { get; set; }

        /// <summary>
        /// Gets or Sets fill color.
        /// </summary>
        public virtual Color FillColor { get; set; }

        /// <summary>
        /// Enumeration of drawing methods used by ring to determine how the ring should be rendered. This used for drawing optimization (avoid of drawing extra circles)
        /// INNER - ring will render only inner circle
        /// OUTER - ring will render only outer circle
        /// FULL - ring will render both inner and outer circles
        /// </summary>
        public enum DrawingMethod { FULL, OUTER, INNER }
        public DrawingMethod RingDrawingMethod { get; set; }

        public Ring(PointF center, int outerRadius, int innerRadius, int sectors, float rotationAngle, Pen pen, Color fillColor, int ringIndex, DrawingMethod method = DrawingMethod.FULL)
            : this(center, outerRadius, innerRadius, sectors, rotationAngle, pen, ringIndex, method)
        {
            FillColor = fillColor;
        }

        public Ring(PointF center, int outerRadius, int innerRadius, int sectors, float rotationAngle, Pen pen, int ringIndex, DrawingMethod method = DrawingMethod.FULL)
        {
            if (outerRadius <= 0 || innerRadius <= 0) throw new ArgumentException("Neither inner radius nor outer radius can't be less than 0.");
            Center = center;
            OuterRadius = Math.Max(outerRadius, innerRadius);
            InnerRadius = Math.Min(outerRadius, innerRadius);
            DrawingPen = pen;
            FillColor = Color.Transparent;
            RingDrawingMethod = method;
            RingIndex = ringIndex;
            Sectors = sectors;
            RotationAngle = rotationAngle;
        }

        /// <summary>
        /// Slices the ring specified sector.
        /// </summary>
        /// <param name="sector">Sector of the pring that should be sliced.</param>
        /// <returns>Returns a <see cref="RingSlice"/> object that will represent slice of current ring in specific sector.</returns>
        public RingSlice GetSlice(int sector)
        {
            return GetSlice(sector, FillColor);
        }

        /// <summary>
        /// Slices the ring specified sector.
        /// </summary>
        /// <param name="sector">Sector of the pring that should be sliced.</param>
        /// <param name="sliceColor">Fill color of the sliced piece.</param>
        /// <returns>Returns a <see cref="RingSlice"/> object that will represent slice of current ring in specific sector.</returns>
        public RingSlice GetSlice(int sector, Color sliceColor)
        {
            float sectorAngle = 360 / Sectors;
            float angle = sector * sectorAngle - 90 + RotationAngle; // -90 because Graphics.DrawArc method measures angles clockwise from the x-axis to the starting point of the arc. 
            return new RingSlice(Center, OuterRadius, InnerRadius, angle, sectorAngle, RingIndex, sector, sliceColor);
        }

        public virtual void Render(Graphics g)
        {
            if (!FillColor.Equals(Color.Transparent))
            {
                Pen fillPen = new Pen(FillColor, Height - 1);
                float radius = (float)OuterRadius - ((float)(Height)) / 2;
                g.DrawArc(fillPen, Center.X - radius, Center.Y - radius, radius * 2, radius * 2, 0, 360);
            }

            if (RingDrawingMethod == DrawingMethod.FULL || RingDrawingMethod == DrawingMethod.OUTER)
                g.DrawEllipse(DrawingPen, Center.X - OuterRadius, Center.Y - OuterRadius, OuterRadius * 2, OuterRadius * 2);
            if (RingDrawingMethod == DrawingMethod.FULL || RingDrawingMethod == DrawingMethod.INNER)
                g.DrawEllipse(DrawingPen, Center.X - InnerRadius, Center.Y - InnerRadius, InnerRadius * 2, InnerRadius * 2);


        }
    }

    /// <summary>
    /// Class that represents a ring slice which is calculated using center point, inner and outer ring's radius, starting angle and sweep angle.<para/>
    /// Note: Starting angle measured clockwise from the x-axis to the starting point of the slice. 
    /// </summary>
    class RingSlice : Ring
    {

        /// <summary>
        /// Gets staring angle of the slice.
        /// </summary>
        public float StartAngle { get; private set; }
        /// <summary>
        /// Gets sweep angle of the slice.
        /// </summary>
        public float SweepAngle { get; private set; }

        /// <summary>
        /// Gets index of sliced ring.
        /// </summary>
        public int SlicedRing { get; private set; }
        /// <summary>
        /// Gets index of sliced sector.
        /// </summary>
        public int SlicedSector { get; private set; }

        /// <summary>
        /// Fill color of the slice is the same as <see cref="DrawingPen.Color"/>.
        /// </summary>
        public override Color FillColor { get { return DrawingPen.Color; } set { DrawingPen.Color = FillColor; } }

        public RingSlice(PointF center, int outerRadius, int innerRadius, float startAngle, float endAngle, int slicedRing, int slicedSector, Color sliceColor)
            : base(center, outerRadius, innerRadius, 0, 0, new Pen(sliceColor), slicedRing)
        {
            StartAngle = startAngle;
            SweepAngle = endAngle;
            SlicedRing = slicedRing;
            SlicedSector = slicedSector;
        }

        public override void Render(Graphics g)
        {
            float radius = (float)OuterRadius - ((float)(Height)) / 2;
            DrawingPen.Width = Height - 1;
            g.DrawArc(DrawingPen, Center.X - radius, Center.Y - radius, radius * 2, radius * 2, StartAngle, SweepAngle);
        }
    }
    #endregion


}
