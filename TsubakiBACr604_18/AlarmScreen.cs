using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RaspberryPiDotNet;


namespace TsubakiBACr604_18
{
    public partial class AlarmScreen : Form
    {
        private MainScreen ms;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


        private void AlarmScreen_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

        }
        void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }

        public AlarmScreen(MainScreen ms)
        {
            InitializeComponent();
            this.ms = ms;
            timer.Interval = 5000;
            timer.Tick += new EventHandler(Timer_Tick);
            AlarmGPIO();
            timer.Start();
        }

        private void AlarmGPIO()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "/usr/bin/python3.5",
                Arguments = "Alarm.py"
            };
            process.StartInfo = startInfo;
            process.Start();
        }

    }
}
