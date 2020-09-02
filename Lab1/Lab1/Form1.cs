using Emgu.CV.Structure;
using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        Emgu.CV.Image<Gray, byte> imgG = new Emgu.CV.Image<Gray, byte>("D:/Subject/MultiMedia/Lab/Lab1/Lab1/1.jpg");
        public Form1()
        {
            InitializeComponent();

            this.imageBox1.Image = new Emgu.CV.Image<Bgr, byte>("D:/Subject/MultiMedia/Lab/Lab1/Lab1/1.jpg");
            //this.imageBox2.Image = imgG.ThresholdBinary(new Rgb(150, 150, 10), new Rgb(255, 255, 255));
            this.imageBox2.Image = imgG.ThresholdBinary(new Gray(this.trackBar1.Value), new Gray(255));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.imageBox2.Image = imgG.ThresholdBinary(new Gray(this.trackBar1.Value), new Gray(255));
        }
    }
}
