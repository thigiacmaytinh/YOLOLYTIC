using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace YoloSegment
{
    public class Util
    {
        private static Random random = new Random();
        static List<Color> m_colors = new List<Color> {
            Color.Lime,
            Color.FromArgb(255, 1, 228),
            Color.FromArgb(214, 40, 40),            
            Color.FromArgb(247, 127, 0),
            Color.FromArgb(255, 169, 221),
            Color.FromArgb(28, 221, 218)};

        static List<Pen> m_pens = new List<Pen>();
        static SolidBrush redBrush = new SolidBrush(Color.FromArgb(255, 1, 228));
        static SolidBrush whiteBrush = new SolidBrush(Color.White);        
        static List<Brush> m_brushes = new List<Brush>();


        const int PADDING = 50;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DrawObject(Bitmap bmp, List<Polygon> polygons, Size displaySize, bool drawText = true, 
            bool drawSegment = true, bool drawRect = true, bool drawCorner = true, int selectedIndex = -1)
        {
            if(polygons.Count == 0)
                return;


            int thickness = Math.Max(1, displaySize.Width / 150);
            int fontSize = Math.Min(25, displaySize.Width / 30);
            Font drawFont = new Font("Arial", fontSize);
            Rectangle rectFrame = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Pen yellowPen = new Pen(Color.Yellow, thickness);

            using (Graphics g = Graphics.FromImage(bmp))
            {

                for (int i = 0; i < polygons.Count; i++)
                {
                    Polygon polygon = polygons[i];


                    Rectangle rect = polygon.rect;
                    bool overlapEdge = TGMTshape.IsOverlap(rect, rectFrame, PADDING);
                    int classID = polygon.classID;
                    if(classID < 0)
                    {
                        classID = 0;
                    }
                    if (classID >= m_pens.Count)
                    {
                        for (int j = m_pens.Count; j <= classID; j++)
                        {
                            int colorIndex = j % m_colors.Count;
                            Color c = m_colors[colorIndex];
                            //m_colors.Add(c);
                            m_pens.Add(new Pen(c, thickness));
                            m_brushes.Add(new SolidBrush(c));
                        }
                    }
                    Pen p = m_pens[classID];
                    if (overlapEdge)
                        p = yellowPen;

                    
                    if (drawSegment && polygon.contour != null && polygon.contour.Length > 2)
                    {
                        if(i == selectedIndex)
                        {
                            g.DrawPolygon(p, polygon.contour);
                        }                            
                        else
                        {
                            g.FillPolygon(new SolidBrush(Color.FromArgb(100, p.Color)), polygon.contour);
                            g.DrawPolygon(p, polygon.contour);
                        }
                    }

                    if (drawRect)
                    {
                        g.DrawRectangle(p, rect);
                    }

                    if (drawCorner && polygon.corners != null)
                    {
                        // Draw corner
                        PointF topLeft = polygon.corners[0];
                        PointF topRight = polygon.corners[1];
                        PointF bottomRight = polygon.corners[2];
                        PointF bottomLeft = polygon.corners[3];
                        g.DrawLine(p, topLeft, topRight);
                        g.DrawLine(p, topRight, bottomRight);
                        g.DrawLine(p, bottomRight, bottomLeft);
                        g.DrawLine(p, bottomLeft, topLeft);

                        for (int j = 0; j < polygon.corners.Length; j++)
                        {
                            PointF corner = polygon.corners[j];
                            g.FillEllipse(new SolidBrush(p.Color), corner.X - 5, corner.Y - 5, 10, 10);
                        }
                    }

                    if (drawText)
                    {
                        string text = polygon.className + " " + polygon.score.ToString("N2");
                        SizeF textSize = g.MeasureString(text, drawFont);
                        RectangleF rectf = new RectangleF(rect.X, rect.Y - (textSize.Height/2), textSize.Width, textSize.Height);

                        g.FillRectangle(redBrush, rect.X - 1, rect.Y - (textSize.Height / 2), textSize.Width + 2, textSize.Height);
                        g.DrawString(text, drawFont, whiteBrush, rectf);
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static Color GenerateRandomColor()
        {
            int r = random.Next(0, 255);
            int g = random.Next(0, 0);
            int b = random.Next(0, 0);

            return Color.FromArgb(r, g, b);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GenRow(double width, double height, Polygon obj)
        {
            //double x = obj.rect.X / width;
            //double y = obj.rect.Y / height;
            //double w = obj.rect.Width / width;
            //double h = obj.rect.Height / height;
            //double cx = x + w / 2;
            //double cy = y + h / 2;

            if(obj.classID == -1 || obj.corners == null || obj.corners.Length == 0)
                return "";

            string content = obj.classID.ToString();

            for(int i = 0; i < obj.contour.Length; i++)
            {
                Point p = obj.contour[i];
                double x = (double)p.X / width;
                double y = (double)p.Y / height;
                content += " " + x.ToString("0.000000") + " " + y.ToString("0.000000");
            }

            return content;
        }
    }
}
