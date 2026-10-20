using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGMT;
using TGMTcs;

namespace Yololytic
{
    public class Util
    {
        private static Random random = new Random();
        static List<Color> m_colors = new List<Color> {
            Color.FromArgb(255, 1, 228),
            Color.FromArgb(214, 40, 40),            
            Color.FromArgb(247, 127, 0),
            Color.FromArgb(255, 169, 221),
            Color.FromArgb(28, 221, 218)};
        static List<Pen> m_pens = new List<Pen>();

        static List<Brush> m_brushes = new List<Brush>();

        //static SolidBrush redBrush = new SolidBrush(Color.FromArgb(255, 1, 228));
        static Font myFont = new Font("Arial", 14);
        static SolidBrush whiteBrush = new SolidBrush(Color.White);

        Pen pen_blue_thick = new Pen(Color.FromArgb(0, 48, 73), 2);
        Pen pen_red_thick = new Pen(Color.FromArgb(255,1, 228), 2);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GenAnnotationRow(double width, double height, Box box)
        {
            double x = box.rect.X / width;
            double y = box.rect.Y / height;
            double w = box.rect.Width / width;
            double h = box.rect.Height / height;
            double cx = x + w / 2;
            double cy = y + h / 2;

            return box.classID + " " + cx + " " + cy + " " + w + " " + h;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DrawObject(Bitmap bmp, List<Box> boxes, int selectedIndex = -1)
        {
            if(boxes == null || boxes.Count == 0)
                return;

            int thickness = Math.Max(1, bmp.Width / 300);
            myFont = new Font("Arial", Math.Max(12, bmp.Width / 80));

            using (Graphics g = Graphics.FromImage(bmp))
            {               

                for (int i = 0; i < boxes.Count; i++)
                {
                    Box box = boxes[i];
                    Rectangle rect = box.rect;

                    int classID = box.classID == -1 ? 0 : box.classID;
                    if (classID >= m_pens.Count)
                    {
                        for(int j = m_pens.Count; j <= classID; j++)
                        {
                            int colorIndex = j % m_colors.Count;
                            Color c = m_colors[colorIndex];
                            m_pens.Add(new Pen(c, 4));
                            m_brushes.Add(new SolidBrush(c));
                        }
                    }

                    if(i == selectedIndex)
                    {
                        Pen p = m_pens[classID];
                        g.DrawRectangle(p, rect);
                    }
                    else
                    {
                        Pen p = new Pen(Color.FromArgb(100, m_pens[classID].Color), thickness);
                        g.DrawRectangle(p, rect);
                    }

                    Brush brush = m_brushes[classID];
                    string className = box.className + " " + box.score.ToString("0.00");
                    SizeF textSize = g.MeasureString(className, myFont);                    
                    g.FillRectangle(brush, rect.X - 2, rect.Y - textSize.Height, textSize.Width + 4, textSize.Height);
                    g.DrawString(className, myFont, whiteBrush, rect.X, rect.Y - textSize.Height);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static Color GenerateRandomColor()
        {
            int r = random.Next(0, 255); // Generates a value between 0 and 255
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);

            return Color.FromArgb(r, g, b);
        }
    }
}
