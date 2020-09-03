using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

using DirectShowLib;
namespace Lab1
{
    public partial class Form1 : Form
    {
        #region Variables

        #region Camera Capture Variables
        private Emgu.CV.VideoCapture _capture = null;
        private bool _captureInProgress = false;
        int CameraDevice = 0; 
        VideoDevice[] WebCams;
        #endregion

        #region Camera Settings
        int Brightness_Store = 0;
        int Contrast_Store = 0;
        int Sharpness_Store = 0;
        #endregion

        #endregion

        public Form1()
        {
            InitializeComponent();

            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new VideoDevice[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new VideoDevice(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID);
                CamSelect.Items.Add(WebCams[i].ToString());
            }
            if (CamSelect.Items.Count > 0)
            {
                CamSelect.SelectedIndex = 0; 
                Shot.Enabled = true;
            }
        }


        private void Shot_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    Shot.Text = "Start";
                    _capture.Pause();
                    _captureInProgress = false;
                }
                else
                {
                    Shot.Text = "Stop";
                    _capture.Start(); 
                    _captureInProgress = true;
                }

            }
            else
            {
                SetupCapture(CamSelect.SelectedIndex);
                Shot_Click(null, null);
            }
        }
        private void SetupCapture(int Camera_Identifier)
        {
            CameraDevice = Camera_Identifier;

            if (_capture != null) _capture.Dispose();
            try
            {
                _capture = new VideoCapture(CameraDevice);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = new Mat();
            Mat frame1 = new Mat();
            _capture.Retrieve(frame);
            _capture.Retrieve(frame1);
            CvInvoke.MedianBlur(frame1, frame, 5);
            if (BRG.Checked)
            {
                DisplayImage(frame.ToImage<Bgr, byte>().ToBitmap());
            }
            if (Gray.Checked)
            {
                DisplayImage(frame.ToImage<Gray, byte>().ToBitmap());
            }
            if (Sobel.Checked)
            {
                CvInvoke.Sobel(frame, frame, Emgu.CV.CvEnum.DepthType.Default, 1, 1);
                DisplayImage(frame.ToImage<Gray, byte>().ThresholdBinary(new Gray(10), new Gray(255)).ToBitmap());
            }
            if (Laplas.Checked)
            {
                CvInvoke.Laplacian(frame, frame, Emgu.CV.CvEnum.DepthType.Default);
                DisplayImage(frame.ToImage<Gray, byte>().ThresholdBinary(new Gray(10), new Gray(255)).ToBitmap());
            }
            if (Canny.Checked)
            {
                CvInvoke.Canny(frame1, frame, 10, 10, apertureSize: 3);
                DisplayImage(frame.ToImage<Gray, byte>().ThresholdBinary(new Gray(10), new Gray(255)).ToBitmap());
            }
        }

        private delegate void DisplayImageDelegate(Bitmap Image);
        private void DisplayImage(Bitmap Image)
        {
            if (pictureBox1.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(DI, new object[] { Image });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                pictureBox1.Image = Image;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
