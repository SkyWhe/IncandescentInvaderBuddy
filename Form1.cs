using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;


using System.Threading.Tasks;
using System.Windows.Forms;
using tessnet2;
using System.Net.Mail;
using System.Media;

namespace IncandescentInvaderBuddy
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        private int left;
        private int top;
        private int right;
        private int bottom;

        public RECT(RECT Rectangle)
            : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
        {
        }

        public RECT(int Left, int Top, int Right, int Bottom)
        {
            left = Left;
            top = Top;
            right = Right;
            bottom = Bottom;
        }

        public int X
        {
            get { return left; }
            set { left = value; }
        }
        public int Y
        {
            get { return top; }
            set { top = value; }
        }
        public int Left
        {
            get { return left; }
            set { left = value; }
        }
        public int Top
        {
            get { return top; }
            set { top = value; }
        }
        public int Right
        {
            get { return right; }
            set { right = value; }
        }
        public int Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }
        public int Height
        {
            get { return bottom - top; }
            set { bottom = value + top; }
        }
        public int Width
        {
            get { return right - left; }
            set { right = value + left; }
        }
        public Point Location
        {
            get { return new Point(Left, Top); }
            set
            {
                left = value.X;
                top = value.Y;
            }
        }
        public Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                right = value.Width + left;
                bottom = value.Height + top;
            }
        }

        public static implicit operator Rectangle(RECT Rectangle)
        {
            return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
        }
        public static implicit operator RECT(Rectangle Rectangle)
        {
            return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
        }
        public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
        {
            return Rectangle1.Equals(Rectangle2);
        }
        public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
        {
            return !Rectangle1.Equals(Rectangle2);
        }

        public override string ToString()
        {
            return "{Left: " + left + "; " + "Top: " + top + "; Right: " + right + "; Bottom: " + bottom + "}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public bool Equals(RECT Rectangle)
        {
            return Rectangle.Left == left && Rectangle.Top == top && Rectangle.Right == right && Rectangle.Bottom == bottom;
        }

        public override bool Equals(object Object)
        {
            if (Object is RECT)
            {
                return Equals((RECT)Object);
            }
            else if (Object is Rectangle)
            {
                return Equals(new RECT((Rectangle)Object));
            }

            return false;
        }
    }


    public partial class Form1 : Form
    {

        SoundPlayer simpleSound = new SoundPlayer(@"Alarm.wav");
        Tesseract ocr = new Tesseract();

        public Form1()
        {
            InitializeComponent();
            ocr.Init(null, "eng", false);
        }



        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindow(IntPtr hwnd, int wFlag);

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]

        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        public static Image CaptureDesktop()
        {
            return CaptureWindow(GetDesktopWindow());
        }

        public static Bitmap CaptureActiveWindow()
        {
            return CaptureWindow(GetForegroundWindow());
        }

        public static Bitmap CaptureWindow(IntPtr handle)
        {
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }


        public static IntPtr WinGetHandle(string wName)
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains(wName))
                {
                    hWnd = pList.MainWindowHandle;
                }
            }
           

            return hWnd;
        }


        public void sendWarning(String msg1, String msg2)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("grosslyincandescentwarrior@gmail.com");
                mail.To.Add(emailbox.Text);
                mail.Subject = msg1;
                mail.Body = msg2;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("grosslyincandescentwarrior@gmail.com", "Gunther*23");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {

            }

            scanTimer.Enabled = false;
            running.Text = "Not Running";

        }
        public void scanForKeywords()
        {
            IntPtr point = WinGetHandle(windowName.Text);

            if (point != IntPtr.Zero)
            {

                Bitmap screen = CaptureWindow(point);


                List<tessnet2.Word> result = ocr.DoOCR(screen, Rectangle.Empty);
                String LCtest = "";

                foreach (tessnet2.Word word in result)
                {

                    LCtest = word.Text.ToLower();
                    if (LCtest == "invading")
                    {

                        if (emailcheckbox.Checked)
                        {
                            sendWarning("Praise the sun!", "You are invading another world");
                        }

                        if (soundcheckbox.Checked)
                        {
                            simpleSound.Play();
                        }

                        break;

                    }

                    if (LCtest == "invaded")
                    {

                        if (emailcheckbox.Checked)
                        {
                            sendWarning("Praise the sun!", "You are invading another world");
                        }

                        if (soundcheckbox.Checked)
                        {
                            simpleSound.Play();
                        }

                        break;

                    }

                }

                screen.Dispose();
                ocr.Dispose();
            }
            else
            {
                running.Text = "Not Running";
                scanTimer.Enabled = false;
                System.Windows.Forms.MessageBox.Show("Cannot find window with this name, please double check");

            }
        }





        private void runBtn_Click(object sender, EventArgs e)
        {
            scanTimer.Enabled = !scanTimer.Enabled;


            if (scanTimer.Enabled == true)
            {
                running.Text = "Running";
            }
            else
            {

                running.Text = "Not Running";
            }
        }

        private void scanTimer_Tick(object sender, EventArgs e)
        {

            scanForKeywords();

        }
    }
}
