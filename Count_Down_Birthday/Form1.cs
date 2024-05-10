using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Count_Down_Birthday
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // asome templates
            Dictionary<string, Color> template = new Dictionary<string, Color>();
            template.Add("bottomleft", Color.FromArgb(255, 192, 128));
            template.Add("bottomright", Color.FromArgb(251, 97, 122));
            template.Add("topleft", Color.FromArgb(251, 97, 122));
            template.Add("topright", Color.FromArgb(251, 97, 122));

            bunifuThinButton21.BackColor = Color.Transparent;
            bunifuThinButton22.BackColor = Color.Transparent;

            templates.Add(template);

            template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(192, 0, 192));
            template.Add("bottomright", Color.Black);
            template.Add("topleft", Color.FromArgb(251, 97, 122));
            template.Add("topright", Color.FromArgb(251, 97, 122));

            templates.Add(template);

            template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.Black);
            template.Add("bottomright", Color.Black);
            template.Add("topleft", Color.FromArgb(251, 97, 122));
            template.Add("topright", Color.DarkTurquoise);

            templates.Add(template);
           
        }

        public void load_theme(Dictionary<string, Color> theme)
        {

            loader.Visible = true;

            bunifuGradientPanel1.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel1.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel1.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel1.GradientTopRight = theme["topright"];

            hideloader.Start();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        int Cur_Template = 0;
        //store grad themes
        List<Dictionary<string, Color>> templates = new List<Dictionary<string, Color>>();

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           if (Cur_Template < templates.Count()-1)
            {
                Cur_Template++;
            }
            else
            {
                Cur_Template = 0;
            }

            load_theme(templates[Cur_Template]);

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            Random r = new Random();

            Dictionary<string, Color> template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("bottomright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("topleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("topright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));


            bunifuThinButton21.BackColor = Color.Transparent;
            bunifuThinButton22.BackColor = Color.Transparent;

            load_theme(template);

            // safe theme
            templates.Add(template);

        }

        DateTime endTime = new DateTime(2020, 01, 08, 0, 0, 0); //MyBirthday

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = endTime.Subtract(DateTime.Now);

            d.Text = ts.Days.ToString();
            h.Text = ts.Hours.ToString();
            m.Text = ts.Minutes.ToString();
            s.Text = ts.Seconds.ToString();
        }

        private void hideloader_Tick(object sender, EventArgs e)
        {
            hideloader.Stop();
            loader.Visible = false;
            this.Opacity = 0.97;
        }

        void openurl(string url)
        {
            
        }


        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            openurl("https://www.vk.com");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsd, int wparam, int lparam);


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
