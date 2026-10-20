using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TGMTcs
{
    public class TGMTshape
    {
        
        public static bool IsInsideRect(Point point, Rectangle rect)
        {
            return point.X >= rect.X &&
                point.Y >= rect.Y &&
                point.X <= rect.X + rect.Width &&
                point.Y <= rect.Y + rect.Height;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsInside(Rectangle rect1, Rectangle rect2)
        {
            return rect1.X >= rect2.X &&
                rect1.Y >= rect2.Y &&
                rect1.X + rect1.Width <= rect2.X + rect2.Width &&
                rect1.Y + rect1.Height <= rect1.Y + rect2.Height;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsOverlap(Rectangle smallRect, Rectangle bigRect, int padding=0)
        {
            if(smallRect.Width <= 0 || smallRect.Height <= 0 ||
                bigRect.Width <= 0 || bigRect.Height <= 0)
            {
                return true;
            }

            int left = bigRect.Left - padding;
            int top = bigRect.Top - padding;
            int right = bigRect.Right + padding;
            int bottom = bigRect.Bottom + padding;

            // Padded region is invalid
            if(left > right || top > bottom)
                return true;

            return smallRect.Left <= left ||
                   smallRect.Top <= top ||
                   smallRect.Right >= right ||
                   smallRect.Bottom >= bottom;
        }
    }
}

    

