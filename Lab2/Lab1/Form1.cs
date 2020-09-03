using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> imgG = new Image<Bgr, byte>("D:/Subject/MultiMedia/Lab/Lab1/Lab1/1.jpg");

        public Form1()
        {
            InitializeComponent();

            this.imageBox1.Image = imgG;
            

            // Task 1
            ConvolutionKernelF Kernel = new ConvolutionKernelF(
                new float[,] {
                                {-0.1f, 0.2f, -0.1f,
                                 0.2f, 3.0f, 0.2f,
                                -0.1f, 0.2f, -0.1f}
                }
             );
            var img1 = imgG.Copy().Convolution(Kernel);
            CvInvoke.Filter2D(imgG, img1, Kernel, new Point() { X = -1, Y = -1 });
            this.imageBox2.Image = img1;


            // Task 2
            var img2 = imgG.Copy();
            CvInvoke.Blur(imgG, img2, new Size { Height = 100, Width = 100 }, new Point() { X = 11, Y = 11 });
            this.imageBox3.Image = img2;

            var img3 = imgG.Copy();
            CvInvoke.BoxFilter(imgG, img3, Emgu.CV.CvEnum.DepthType.Default, new Size { Height = 1, Width = 1 }, new Point() { X = -1, Y = -1 }, false);
            this.imageBox4.Image = img3;

            var img4 = imgG.Copy();
            CvInvoke.GaussianBlur(imgG, img4, new Size { Height = 201, Width = 201 }, 1);
            this.imageBox5.Image = img4;

            var img5 = imgG.Copy();
            CvInvoke.MedianBlur(imgG, img5, 5);
            this.imageBox6.Image = img5;


            // Task 3
            var img6 = imgG.Copy();
            CvInvoke.Erode(imgG, img6, new Mat(), new Point() { X = -1, Y = -1 }, 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1));
            this.imageBox7.Image = img6;

            var img7 = imgG.Copy();
            CvInvoke.Dilate(imgG, img7, new Mat(), new Point() { X = -1, Y = -1 }, 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(1));
            this.imageBox8.Image = img7;


            // Task 4
            var img8 = imgG.Copy();
            CvInvoke.Canny(imgG, img8, 10, 10, 3);
            this.imageBox9.Image = img8;


            // Task 5
            var img = new Image<Gray, byte>("D:/Subject/MultiMedia/Lab/Lab1/Lab1/1.jpg");
            var img9 = img.Copy();
            CvInvoke.EqualizeHist(img, img9);
            this.imageBox10.Image = img9;
        }
    }
}
