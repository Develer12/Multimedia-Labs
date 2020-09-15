using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> imgG = new Image<Bgr, byte>("D:/Subject/MultiMedia/Lab/Lab4/Lab1/1.jpg");
        Image<Gray, byte> imgGray = new Image<Gray, byte>("D:/Subject/MultiMedia/Lab/Lab4/Lab1/1.jpg").ThresholdBinary(new Gray(128), new Gray(255));
        Image<Bgr, byte> money = new Image<Bgr, byte>(@"D:\Subject\MultiMedia\Lab\Lab4\Lab1\money.jpg");
        public Form1()
        {
            InitializeComponent();

            this.imageBox1.Image = imgG;


            // Task 1
            var image = money.Copy();
            var hierarchy = money.Convert<Gray, byte>().ThresholdBinary(new Gray(250), new Gray(255));
            CvInvoke.MedianBlur(image, image, 3);

            var img1 = image.Convert<Gray, byte>().ThresholdBinary(new Gray(250), new Gray(255));
            var listPoints = new VectorOfVectorOfPoint();
            CvInvoke.Dilate(img1, img1, new Mat(), new Point() { X = -1, Y = -1 }, 3, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1));

            CvInvoke.FindContours(img1, listPoints, hierarchy, Emgu.CV.CvEnum.RetrType.List,
                Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            CvInvoke.DrawContours(image, listPoints, -1, new MCvScalar(0, 0, 255));
            var q = listPoints.Size;
            MessageBox.Show(Convert.ToString(q));
            this.imageBox2.Image = image;



            // Task 2
            var img2 = imgG.Copy();
            var img2G = imgGray.Copy();
            LineSegment2D[] lines = null;
            UMat umat = new UMat();
            CvInvoke.MedianBlur(img2G, img2G, 99);

            VectorOfPointF vectorOfPointF = new VectorOfPointF();
            lines = CvInvoke.HoughLinesP(img2G,
               1, 
               1,
               20,
               20, 
               10);
            var q1 = vectorOfPointF.Size;
            foreach (var line in lines)
            {
                img2.Draw(line, new Bgr(0, 0, 255), 1);
            }

            this.imageBox3.Image = img2;


            // Task 3
            Image<Bgr, byte> img3 = new Image<Bgr, byte>(@"D:\Subject\MultiMedia\Lab\Lab4\Lab1\money.jpg");
            Image<Gray, byte> img3G = new Image<Gray, byte>(@"D:\Subject\MultiMedia\Lab\Lab4\Lab1\money.jpg");
            CircleF[][] circlesAll = img3G.HoughCircles(new Gray(255), new Gray(50), 1, img3.Height / 8, 10, 80);

            foreach (var circles in circlesAll)
            {
                foreach (CircleF circle in circles)
                {
                    img3.Draw(circle, new Bgr(Color.Red), 2);
                }
            }
            this.imageBox4.Image = img3;
        }
    }
}
