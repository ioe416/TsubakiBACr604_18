using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TsubakiBACr604_18
{
    public partial class SupervisorLoginScreen : Form
    {
        string supervisor_code = "";
        public MainScreen ms;

        public SupervisorLoginScreen(MainScreen ms)
        {
            InitializeComponent();
            this.ms = ms;
        }

        public void SupervisorLoginScreen_load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

        }

        private void Button_1_Click(object sender, EventArgs e)
        {
            supervisor_code += 1;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_2_Click(object sender, EventArgs e)
        {
            supervisor_code += 2;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_3_Click(object sender, EventArgs e)
        {
            supervisor_code += 3;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_4_Click(object sender, EventArgs e)
        {
            supervisor_code += 4;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_5_Click(object sender, EventArgs e)
        {
            supervisor_code += 5;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_6_Click(object sender, EventArgs e)
        {
            supervisor_code += 6;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_7_Click(object sender, EventArgs e)
        {
            supervisor_code += 7;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_8_Click(object sender, EventArgs e)
        {
            supervisor_code += 8;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_9_Click(object sender, EventArgs e)
        {
            supervisor_code += 9;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (supervisor_code == "1010")
            {
                ms.EnableButtons();

                this.Close();
            }
            else
            {
                supervisor_code = "";
                SupervisorInput.Text = "";
            }
        }
        private void Button_0_Click(object sender, EventArgs e)
        {
            supervisor_code += 0;
            SupervisorInput.Text = supervisor_code;
        }
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            SupervisorInput.Text = "";
            this.Close();
        }
    }
}
