using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;


namespace Yololytic
{
    static class Program
    {
        public static bool inited = false;

        public static bool minScoreEnabled = false;
        public static float minScore = 0.2f;
        public static List<string> classNames = new List<string>();

        public static bool selectClass = false;
        public static List<int> classSelecteds = new List<int>();

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
            TGMTregistry.GetInstance().Init("YOLOLYTIC");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormMain.GetInstance());
        }
    }
}
