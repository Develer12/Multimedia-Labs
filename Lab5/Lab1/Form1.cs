using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        Image<Gray, byte> imgGray = new Image<Gray, byte>("D:/Subject/MultiMedia/Lab/Lab5/Lab1/money.jpg").ThresholdBinary(new Gray(128), new Gray(255));

        public Form1()
        {
            InitializeComponent();

            this.imageBox1.Image = imgGray;


            // Task 1
            var img1 = new Image<Gray, float>(imgGray.Size);
            CvInvoke.CornerHarris(imgGray, img1, 2);
            var img1c = img1.Convert<Gray, byte>().ThresholdBinary(new Gray(47), new Gray(255));
            this.imageBox1.Image = imgGray;
            this.imageBox2.Image = img1c;



            // Task 2
            var img2 = imgGray.Copy();
            var img2c = img2.Convert<Gray, byte>().ThresholdBinary(new Gray(87), new Gray(255));
            foreach (var mKeyPoint in new GFTTDetector(1000).Detect(img2c))
            {
                img2.Draw(new CircleF(mKeyPoint.Point, 1), new Gray(250), 1);
            }

            this.imageBox3.Image = img2;


            // Task 3
            var img3 = imgGray.Copy();
            var img3c = imgGray.Copy();
            PointF[] srcs = new PointF[4];
            srcs[0] = new PointF(100, 300);
            srcs[1] = new PointF(410, 163);
            srcs[2] = new PointF(311, 35);
            srcs[3] = new PointF(46, 129);


            PointF[] dsts = new PointF[4];
            dsts[0] = new PointF(0, 300);
            dsts[1] = new PointF(400, 300);
            dsts[2] = new PointF(400, 0);
            dsts[3] = new PointF(0, 0);
            Mat mywarpmat = CvInvoke.GetPerspectiveTransform(srcs, dsts);
            CvInvoke.WarpPerspective(img3, img3c, mywarpmat, img3.Size);
            this.imageBox4.Image = img3c;
        }
    }
}
