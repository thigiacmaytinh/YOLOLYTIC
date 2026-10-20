using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace YoloSegment
{
    static class Program
    {
        public static bool inited = false;

        public static bool minScoreEnabled = false;
        public static float minScore = 0.2f;

        public static bool drawText = true;
        public static bool drawContour = true;
        public static bool drawRect = false;
        public static bool drawRotatedRectangle = false;

#if HAVE_CUDA
        public static int limitVRAM = 1024;
#endif

        public static string weightPath = "";
        public static string classesPath = "";
        public static int inputWidth = 640;
        public static int inputHeight = 640;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TGMTregistry.GetInstance().Init("Yolosegment");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormMain.GetInstance());
        }
    }
}
