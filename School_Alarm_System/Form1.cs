using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Alarm_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void PortBarlaweDak()
        {
            serialPort1.Close();
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine(ports);
            // Display each port name to the console.
            foreach (string port in ports)
            {
                serialPort1.PortName = port;
            }
            try
            {
                serialPort1.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Maglumat beriji enjamlar bilen baglanyşyk kesildi! Baglanyşygy barlaň!");
                Form1_Load(MessageBoxButtons.OKCancel, null);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PortBarlaweDak();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //autoRefresh++;
            string s, m, se;

            if (Convert.ToInt32(DateTime.Now.Hour) < 10) { s = "0" + DateTime.Now.Hour.ToString(); }
            else { s = DateTime.Now.Hour.ToString(); }

            if (Convert.ToInt32(DateTime.Now.Minute) < 10) { m = "0" + DateTime.Now.Minute.ToString(); }
            else { m = DateTime.Now.Minute.ToString(); }

            if (Convert.ToInt32(DateTime.Now.Second) < 10) { se = "0" + DateTime.Now.Second.ToString(); }
            else { se = DateTime.Now.Second.ToString(); }

            lbl_wagt.Text = s + ":" + m + ":" + se;

            if (lbl_wagt.Text == "08:30:00" || lbl_wagt.Text == "09:15:00" || lbl_wagt.Text == "09:20:00" || lbl_wagt.Text == "10:05:00" || lbl_wagt.Text == "10:10:00" || lbl_wagt.Text == "10:55:00" || lbl_wagt.Text == "11:25:00" || lbl_wagt.Text == "12:10:00" || lbl_wagt.Text == "12:15:00" || lbl_wagt.Text == "13:00:00" || lbl_wagt.Text == "13:05:00" || lbl_wagt.Text == "13:50:00" || lbl_wagt.Text == "14:30:00" || lbl_wagt.Text == "15:15:00") 
            {
                Saz_chal();
            }
        }

        private void Saz_chal()
        {
            serialPort1.WriteLine("h");
        }
    }
}
