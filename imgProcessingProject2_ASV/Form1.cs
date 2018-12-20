/*
 * Geliştirici: Onur Mert ANARAT | 2013010812004
 * e-mail: anrtonurmert@gmail.com
 * GitHub: github.com/anrtonurmert
 * Üniversite: Karabük Üniversitesi
 * Fakülte: Teknoloji Fakültesi
 * Bölüm: Mekatronik Mühendisliği
 * Dip not: "Görüntü İşleme" dersi için dönem sonu proje ödevi olarak yapılmıştır.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO.Ports;


namespace imgProcessingProject2_ASV
{
    public partial class formASV : Form
    {
        private FilterInfoCollection captureDevice;
        private VideoCaptureDevice finalFrame;
        Graphics graph;
        Bitmap video1, video2, video3;
        string[] ports = SerialPort.GetPortNames();
        public formASV()
        {
            InitializeComponent();
        }

        int mode;
        int red, green, blue;

        private void button1_Click(object sender, EventArgs e)
        {
            finalFrame = new VideoCaptureDevice(captureDevice[comboBox1.SelectedIndex].MonikerString);
            finalFrame.NewFrame += finalFrame_newFrame;
            finalFrame.Start();
        }

        private void formASV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalFrame.IsRunning==true)
            {
                finalFrame.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            finalFrame.Stop();
            picBox1.Image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mode = 2;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            red = (int)trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            green = (int)trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            blue = (int)trackBar3.Value;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                pictureBox10.BackColor = Color.Red;
                if (comboBox2.Text == "") return;
                serialPort1.PortName = comboBox2.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox3.Text);
                try
                {
                    pictureBox10.BackColor = Color.Green;
                    serialPort1.Open();
                    label13.Text = serialPort1.PortName + " ile bağlantı oluşturuldu.";
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata: " + hata.Message);
                }
            }
            else label13.Text = serialPort1.PortName + " ile bağlantı oluşturulamadı!";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen==true)
            {
                pictureBox10.BackColor = Color.Red;
                serialPort1.Close();
                label13.Text = serialPort1.PortName + " ile bağlantı kesildi.";
            }
        }

        private void formASV_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen==true)
            {
                pictureBox10.BackColor = Color.Red;
                serialPort1.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mode = 3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            aboutForm abtForm = new aboutForm();
            abtForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void picBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mode = 4;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            mode = 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void finalFrame_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            video1 = (Bitmap)eventArgs.Frame.Clone();
            video2 = (Bitmap)eventArgs.Frame.Clone();
            video3 = (Bitmap)eventArgs.Frame.Clone();
            video1.RotateFlip(RotateFlipType.Rotate180FlipY);
            video2.RotateFlip(RotateFlipType.Rotate180FlipY);
            video3.RotateFlip(RotateFlipType.Rotate180FlipY);
            switch (mode)
            {
                case 1:
                    {
                        //null
                    }
                    break;
                case 2:
                    {
                        //Öklit Renk Filtresi
                        EuclideanColorFiltering eucFilter = new EuclideanColorFiltering();
                        eucFilter.CenterColor = new RGB(Color.FromArgb(red, green, blue));
                        eucFilter.Radius = 125;
                        eucFilter.ApplyInPlace(video2);
                        eucFilter.ApplyInPlace(video3);

                        BlobCounter blobCounter = new BlobCounter();
                        blobCounter.MinHeight = 13;
                        blobCounter.MinWidth = 13;
                        blobCounter.ObjectsOrder = ObjectsOrder.Size;
                        blobCounter.ProcessImage(video2);
                        video2 = video1;
                        Rectangle[] rect = blobCounter.GetObjectsRectangles();
                        if (rect.Length>0)
                        {
                            Rectangle object1 = rect[0];
                            graph = Graphics.FromImage(video2);
                            int object1X = object1.X;
                            int object1Y = object1.Y;
                            using (Pen pen= new Pen(Color.DarkOrange, 3))
                            {
                                graph.DrawRectangle(pen, object1);
                                graph.DrawString(object1.Location.ToString(), new Font("Bookman Old Style", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(object1X-13, object1Y-13));
                            }
                            graph.Dispose();                                                       
                        }
                    }
                    break;
                case 3:
                    {
                        //Öklit Renk Filtresi
                        EuclideanColorFiltering eucFilter = new EuclideanColorFiltering();
                        eucFilter.CenterColor = new RGB(Color.FromArgb(red, green, blue));
                        eucFilter.Radius = 125;
                        eucFilter.ApplyInPlace(video2);
                        eucFilter.ApplyInPlace(video3);

                        BlobCounter blobCounter = new BlobCounter();
                        blobCounter.MinHeight = 13;
                        blobCounter.MinWidth = 13;
                        blobCounter.ObjectsOrder = ObjectsOrder.Size;
                        blobCounter.ProcessImage(video2);
                        video2 = video1;
                        Rectangle[] rect = blobCounter.GetObjectsRectangles();
                        if (rect.Length > 0)
                        {
                            Rectangle object1 = rect[0];
                            graph = Graphics.FromImage(video2);
                            int object1X = object1.X;
                            int object1Y = object1.Y;
                            using (Pen pen = new Pen(Color.DarkOrange, 3))
                            {
                                graph.DrawRectangle(pen, object1);
                                graph.DrawString(object1.Location.ToString(), new Font("Bookman Old Style", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(object1X - 13, object1Y - 13));
                            }
                            graph.Dispose();
                            //Birinci satır
                            if (object1X <= 200 && object1Y <= 160)
                            {
                                pictureBox1.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("1");
                                }
                                pictureBox2.BackColor = Color.White;
                                pictureBox3.BackColor = Color.White;
                                pictureBox4.BackColor = Color.White;
                                pictureBox5.BackColor = Color.White;
                                pictureBox6.BackColor = Color.White;
                                pictureBox7.BackColor = Color.White;
                                pictureBox8.BackColor = Color.White;
                                pictureBox9.BackColor = Color.White;
                            }
                            else if (object1X >= 200 && object1X <= 400 && object1Y <= 160)
                            {
                                pictureBox1.BackColor = Color.White;
                                pictureBox2.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("2");
                                }
                                pictureBox3.BackColor = Color.White;
                                pictureBox4.BackColor = Color.White;
                                pictureBox5.BackColor = Color.White;
                                pictureBox6.BackColor = Color.White;
                                pictureBox7.BackColor = Color.White;
                                pictureBox8.BackColor = Color.White;
                                pictureBox9.BackColor = Color.White;
                            }
                            else if (object1X >= 400 && object1X <= 600 && object1Y <= 160)
                            {
                                pictureBox1.BackColor = Color.White;
                                pictureBox2.BackColor = Color.White;
                                pictureBox3.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("3");
                                }
                                pictureBox4.BackColor = Color.White;
                                pictureBox5.BackColor = Color.White;
                                pictureBox6.BackColor = Color.White;
                                pictureBox7.BackColor = Color.White;
                                pictureBox8.BackColor = Color.White;
                                pictureBox9.BackColor = Color.White;
                            }
                            //İkinci satır
                            else if (object1X <= 200 && object1Y >= 160 && object1Y <= 320)
                            {
                                pictureBox1.BackColor = Color.White;
                                pictureBox2.BackColor = Color.White;
                                pictureBox3.BackColor = Color.White;
                                pictureBox4.BackColor = Color.White;
                                pictureBox5.BackColor = Color.White;
                                pictureBox6.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("4");
                                }
                                pictureBox7.BackColor = Color.White;
                                pictureBox8.BackColor = Color.White;
                                pictureBox9.BackColor = Color.White;
                            }
                            else if (object1X >= 200 && object1X <= 400 && object1Y >= 160 && object1Y <= 320)
                            {
                                pictureBox1.BackColor = Color.White;
                                pictureBox2.BackColor = Color.White;
                                pictureBox3.BackColor = Color.White;
                                pictureBox4.BackColor = Color.White;
                                pictureBox5.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("5");
                                }
                                pictureBox6.BackColor = Color.White;
                                pictureBox7.BackColor = Color.White;
                                pictureBox8.BackColor = Color.White;
                                pictureBox9.BackColor = Color.White;
                            }
                            else if (object1X >= 400 && object1X <= 600 && object1Y >= 160 && object1Y <= 320)
                            {
                                pictureBox1.BackColor = Color.White;
                                pictureBox2.BackColor = Color.White;
                                pictureBox3.BackColor = Color.White;
                                pictureBox4.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("6");
                                }
                                pictureBox5.BackColor = Color.White;
                                pictureBox6.BackColor = Color.White;
                                pictureBox7.BackColor = Color.White;
                                pictureBox8.BackColor = Color.White;
                                pictureBox9.BackColor = Color.White;
                            }
                            //Üçüncü satır
                            else if (object1X <= 200 && object1Y >= 320 && object1Y <= 480)
                            {
                                pictureBox1.BackColor = Color.White;
                                pictureBox2.BackColor = Color.White;
                                pictureBox3.BackColor = Color.White;
                                pictureBox4.BackColor = Color.White;
                                pictureBox5.BackColor = Color.White;
                                pictureBox6.BackColor = Color.White;
                                pictureBox7.BackColor = Color.White;
                                pictureBox8.BackColor = Color.White;
                                pictureBox9.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("7");
                                }
                            }
                            else if (object1X >= 200 && object1X <= 400 && object1Y >= 320 && object1Y <= 480)
                            {
                                pictureBox1.BackColor = Color.White;
                                pictureBox2.BackColor = Color.White;
                                pictureBox3.BackColor = Color.White;
                                pictureBox4.BackColor = Color.White;
                                pictureBox5.BackColor = Color.White;
                                pictureBox6.BackColor = Color.White;
                                pictureBox7.BackColor = Color.White;
                                pictureBox8.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("8");
                                }
                                pictureBox9.BackColor = Color.White;
                            }
                            else if (object1X >= 400 && object1X <= 600 && object1Y >= 320 && object1Y <= 480)
                            {
                                pictureBox1.BackColor = Color.White;
                                pictureBox2.BackColor = Color.White;
                                pictureBox3.BackColor = Color.White;
                                pictureBox4.BackColor = Color.White;
                                pictureBox5.BackColor = Color.White;
                                pictureBox6.BackColor = Color.White;
                                pictureBox7.BackColor = Color.Red;
                                if (serialPort1.IsOpen == true)
                                {
                                    serialPort1.Write("9");
                                }
                                pictureBox8.BackColor = Color.White;
                                pictureBox9.BackColor = Color.White;
                            }
                        }
                    }
                    break;
                case 4:
                    {
                        //Öklit Renk Filtresi
                        EuclideanColorFiltering eucFilter = new EuclideanColorFiltering();
                        eucFilter.CenterColor = new RGB(Color.FromArgb(red, green, blue));
                        eucFilter.Radius = 125;
                        eucFilter.ApplyInPlace(video2);
                        eucFilter.ApplyInPlace(video3);

                        BlobCounter blobCounter = new BlobCounter();
                        blobCounter.MinHeight = 13;
                        blobCounter.MinWidth = 13;
                        blobCounter.ObjectsOrder = ObjectsOrder.Size;
                        blobCounter.ProcessImage(video2);
                        video2 = video1;
                        Rectangle[] rect = blobCounter.GetObjectsRectangles();
                        if (rect.Length > 0)
                        {
                            Rectangle object1 = rect[0];
                            graph = Graphics.FromImage(video2);
                            int object1X = object1.X;
                            int object1Y = object1.Y;
                            using (Pen pen = new Pen(Color.DarkOrange, 3))
                            {
                                graph.DrawRectangle(pen, object1);
                                graph.DrawString(object1.Location.ToString(), new Font("Bookman Old Style", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Point(object1X - 13, object1Y - 13));
                            }                            
                            graph.Dispose();
                            int myInt = object1.Location.X;
                            byte[] b = BitConverter.GetBytes(myInt);
                            serialPort1.Write(b,0,4);
                        }
                    }
                    break;
            }
            picBox1.Image = video1;
            picBox2.Image = video3;
        }

        private void formASV_Load(object sender, EventArgs e)
        {
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in captureDevice)
            {
                comboBox1.Items.Add(device.Name);
            }
            comboBox1.SelectedIndex = 0;
            finalFrame = new VideoCaptureDevice();
            pictureBox10.BackColor = Color.Red;
            foreach (string myPort in ports)
            {
                comboBox2.Items.Add(myPort);
                comboBox2.SelectedIndex = 0;
            }
            comboBox3.Items.Add("9600");
            comboBox3.SelectedIndex = 1;                     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
