using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TsubakiBACr604_18
{
    public partial class AlarmCodeScreen : Form
    {
        string exit_code = "";
        public MainScreen ms;

        public AlarmCodeScreen(MainScreen ms)
        {
            InitializeComponent();
        }

        public void ExitCodeScreen_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

        }


        private void Button_1_Click(object sender, EventArgs e)
        {
            exit_code += 1;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            exit_code += 2;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            exit_code += 3;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            exit_code += 4;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            exit_code += 5;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            exit_code += 6;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            exit_code += 7;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            exit_code += 8;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            exit_code += 9;
            ExitCodeEntry.Text = exit_code;
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            exit_code += 0;
            ExitCodeEntry.Text = exit_code;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            exit_code = "";

            this.Close();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (exit_code.ToString() == "4356")
            {
                Application.Exit();
            }
            else
            {
                exit_code = "";
                ExitCodeEntry.Text = exit_code;
            }
                
        }
    }
}
