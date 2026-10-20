using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "e-class.jpg";

            //khởi tạo detector bằng cách load model và class name
            YOLOv8Detector detector = new YOLOv8Detector(@"..\pretrain\yolov8n.onnx", @"..\pretrain\coco.names", 640, 640);

            //Detect ảnh hoặc đường dẫn ảnh
            bool drawRect = true;
            bool drawText = true;
            Predicted predicted = detector.Detect("e-class.jpg", drawRect, drawText);

            //hiển thị ảnh đã vẽ bouding box lên picture box
            pictureBox2.Image = predicted.bitmap;

            //in ra danh sách các object
            for (int i = 0; i<predicted.objects.Length; i++)
            {
                YOLOobject obj = predicted.objects[i];
                Console.WriteLine(String.Format("{0}: {1}", obj.className, obj.confident.ToString()));
            }

            this.Text = "Detected: " + predicted.objects.Length.ToString();

        }
    }
}
