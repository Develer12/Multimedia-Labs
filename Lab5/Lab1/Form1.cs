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

            this.imageBox1.Image = new Image<Bgr, byte>("D:/Subject/MultiMedia/Lab/Lab5/Lab1/money.jpg");


            // Task 1
            var img1 = new Image<Gray, float>(imgGray.Size);
            CvInvoke.MedianBlur(img1, img1, 3);
            CvInvoke.CornerHarris(imgGray, img1, 3, 7);
            var img1c = img1.Convert<Gray, byte>().ThresholdBinary(new Gray(50), new Gray(255));
            this.imageBox2.Image = img1c;



            // Task 2
            var img2 = new Image<Bgr, byte>("D:/Subject/MultiMedia/Lab/Lab5/Lab1/money.jpg");
            var img2c = img2.Convert<Gray, byte>().ThresholdBinary(new Gray(9), new Gray(255));
            foreach (var mKeyPoint in new GFTTDetector(1000, 0.1, 1, 5, true).Detect(img2))
            {

                img2.Draw(new CircleF(mKeyPoint.Point, mKeyPoint.Size), new Bgr(0, 255, 0), 1);
            }

            this.imageBox3.Image = img2;


            // Task 3
            var img3 = new Image<Bgr, byte>("D:/Subject/MultiMedia/Lab/Lab5/Lab1/money1.jpg");
            var img3c = img3.Copy();
            PointF[] srcs = new PointF[4];
            srcs[0] = new PointF(100, 300);
            srcs[1] = new PointF(410, 150);
            srcs[2] = new PointF(300, 50);
            srcs[3] = new PointF(50, 150);


            PointF[] dsts = new PointF[4];
            dsts[0] = new PointF(10, 300);
            dsts[1] = new PointF(410, 150);
            dsts[2] = new PointF(300, 50);
            dsts[3] = new PointF(50, 150);
            Mat mywarpmat = CvInvoke.GetPerspectiveTransform(srcs, dsts);

            //fix

            srcs[0] = new PointF(10, 300);
            srcs[1] = new PointF(410, 150);
            srcs[2] = new PointF(300, 50);
            srcs[3] = new PointF(50, 150);

            dsts[0] = new PointF(10, 300);
            dsts[1] = new PointF(410, 150);
            dsts[2] = new PointF(300, 50);
            dsts[3] = new PointF(50, 150);
            mywarpmat = CvInvoke.GetPerspectiveTransform(srcs, dsts);
            

            CvInvoke.WarpPerspective(img3, img3c, mywarpmat, img3.Size);
            this.imageBox4.Image = img3c;
        }
    }
}
