using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics;
//using System.Drawing;
using System.IO;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;

namespace TsubakiBACr604_18
{
    
    public partial class MainScreen : Form
    {
        Timer SystemClock_Display = new Timer();
        Timer AlarmCheck_Timer = new Timer();
        Timer DayofWeek_Timer = new Timer();
        public bool supervisor_logged_in = false;
        public bool HourInput_active = false;
        public bool MinuteInput_active = false;
        public bool SecondInput_active = false;
        public bool mute = false;
        public bool PM = false;
        public bool Weekend = false;
        string ampm = "AM";
        string day = "Sunday";

        public MainScreen()
        {
            InitializeComponent();
        }

        public void MainScreen_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;


            SystemClock_Display.Interval = 1000;
            SystemClock_Display.Tick += new EventHandler(SystemClock_Display_Tick);
            SystemClock_Display.Start();

            AlarmCheck_Timer.Interval = 1000;
            AlarmCheck_Timer.Tick += new EventHandler(AlarmCheck_Timer_Tick);
            AlarmCheck_Timer.Start();

            AlarmList_Populate();

            AMPMCheckbox.Text = ampm;
            DayOfWeek.Text = day;
            InitialLabelSet();

        }
        private void InitialLabelSet()
        {
            string time = DateTime.Now.ToString("hh:mm:"+"00" + " tt dddd");
            using (StreamReader sr = File.OpenText("alarmlist.txt"))
            {
                string[] lines = File.ReadAllLines("alarmlist.txt");

                for (var i = 0; i <= lines.Length - 1; i++)
                {

                    if (time == lines[i])
                    {
                        int index = i + 1;
                        if (index >= lines.Length)
                        {
                            index = 0;
                        }
                        NextAlarm.Text = lines[index].ToString();
                        PrevAlarm.Text = DateTime.Now.ToString("hh:mm:ss tt dddd");
                    }
                }
                    //PrevAlarm.Text = "";
                    //NextAlarm.Text = "";
                }
            

        }

        public void SystemClock_Display_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("hh:mm:ss tt dddd");
            clock_display.Text = time;
        }

        public void AlarmCheck_Timer_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("hh:mm:ss tt dddd");

            using (StreamReader sr = File.OpenText("alarmlist.txt"))
            {
                string[] lines = File.ReadAllLines("alarmlist.txt");

                for (var i = 0; i <= lines.Length - 1; i++)
                {

                    if (time == lines[i])
                    {
                        int index = i + 1;
                        if (index >= lines.Length)
                        {
                            index = 0;
                        }
                        switch (lines[index].ToString())
                        {
                            case "3rd Shift Monday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "1st Shift Monday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "2nd Shift Monday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "3rd Shift Tuesday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "1st Shift Tuesday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "2nd Shift Tuesday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "3rd Shift Wednesday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "1st Shift Wednesday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "2nd Shift Wednesday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "3rd Shift Thursday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "1st Shift Thursday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "2nd Shift Thursday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "3rd Shift Friday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "1st Shift Friday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "2nd Shift Friday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "3rd Shift Saturday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "1st Shift Saturday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            case "2nd Shift Saturday":
                                NextAlarm.Text = lines[index + 1].ToString();
                                break;
                            default:
                                NextAlarm.Text = lines[index].ToString();
                                break;
                        }
                                
                       
                        NextAlarm.Text = lines[index].ToString();
                        PrevAlarm.Text = DateTime.Now.ToString("hh:mm:ss tt dddd");
                        AlarmTrigger();
                    }
                }
            }
        }
        public void AlarmTrigger()
        {
            if (mute == true)
            {
                Timer debounce = new Timer();
                debounce.Interval = 5000;
                debounce.Tick += new EventHandler(Debounce_Tick);
                debounce.Start();
            }
            else if (mute == false)
            {
                AlarmScreen ass = new AlarmScreen(this);
                ass.FormClosed += new FormClosedEventHandler(AlarmScreen_FormClosed);
                ass.Show();
            }
                      
        }
        private void Debounce_Tick(object sender, EventArgs e)
        {
            mute = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            AlarmCodeScreen ecs = new AlarmCodeScreen(this);
            ecs.FormClosed += new FormClosedEventHandler(ExitCodeScreen_FormClosed);
            ecs.Show();
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("alarmlist.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(HourInput.Text + ":" + MinuteInput.Text + ":" + SecondInput.Text + " " + AMPMCheckbox.Text + " " + DayOfWeek.Text);
            }
            HourInput.Text = "";
            MinuteInput.Text = "";
            SecondInput.Text = "";

            AlarmList_Populate();

        

        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (AlarmList.SelectedIndex > -1)
            {
                AlarmList.Items.Remove(AlarmList.SelectedItem);
                using (FileStream fs = new FileStream("alarmlist.txt", FileMode.Open, FileAccess.ReadWrite))
                {
                    TextWriter tw = new StreamWriter(fs);
                    foreach (string item in AlarmList.Items)
                        tw.WriteLine(item);
                }

            }

            else
            {
                MessageBox.Show("No alarm was selected!");

            }
        }
        private void ButtonModify_Click(object sender, EventArgs e)
        {
            if (AlarmList.SelectedIndex > -1)
            {
                AlarmList.Items.Remove(AlarmList.SelectedItem);
                using (FileStream fs = new FileStream("alarmlist.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    TextWriter t_w = new StreamWriter(fs);
                    foreach (string item in AlarmList.Items)
                        t_w.WriteLine(item);
                }

            }
            else
            {
                MessageBox.Show("No alarm was selected!");

            }
        }

        public void AlarmList_Populate()
        {
            AlarmList.Items.Clear();

            string line;
            var file = new System.IO.StreamReader("alarmlist.txt");
            while ((line = file.ReadLine()) != null)
            {
                AlarmList.Items.Add(line);
            }

            file.Close();

        }

        public void AlarmScreen_FormClosed(object sender, EventArgs e)
        {

        }
        public void ExitCodeScreen_FormClosed(object sender, EventArgs e)
        {

        }
        public void SupervisorLoginScreen_FormClosed(object sender, EventArgs e)
        {

        }

        private void Button_Sup_Login_Click(object sender, EventArgs e)
        {
            SupervisorLoginScreen sls = new SupervisorLoginScreen(this);
            sls.FormClosed += new FormClosedEventHandler(AlarmScreen_FormClosed);
            sls.Show();

        }

        public void EnableButtons()
        {
            Button_Cancel.Visible = true;
            Button_SoundAlarm.Visible = true;
            Button_MuteAlarm.Visible = true;
            Button_Sup_login.Visible = false;

        }
        public void DisableButtons()
        {
            Button_Cancel.Visible = false;
            Button_SoundAlarm.Visible = false;
            Button_MuteAlarm.Visible = false;
            Button_Sup_login.Visible = true;

        }

        private void HourInput_Click(object sender, EventArgs e)
        {
            HourInput_active = true;
            MinuteInput_active = false;
            SecondInput_active = false;
        }
        private void MinuteInput_Click(object sender, EventArgs e)
        {
            HourInput_active = false;
            MinuteInput_active = true;
            SecondInput_active = false;
        }
        private void SecondInput_Click(object sender, EventArgs e)
        {
            HourInput_active = false;
            MinuteInput_active = false;
            SecondInput_active = true;
        }

        private void Button_1_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "1";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "1";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "1";
            }
        }
        private void Button_2_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "2";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "2";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "2";
            }
        }
        private void Button_3_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "3";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "3";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "3";
            }
        }
        private void Button_4_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "4";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "4";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "4";
            }
        }
        private void Button_5_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "5";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "5";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "5";
            }
        }
        private void Button_6_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "6";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "6";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "6";
            }
        }
        private void Button_7_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "7";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "7";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "7";
            }
        }
        private void Button_8_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "8";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "8";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "8";
            }
        }
        private void Button_9_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "9";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "9";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "9";
            }
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            HourInput.Text = "";
            MinuteInput.Text = "";
            SecondInput.Text = "";
        }
        private void Button_0_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length < 2)
            {
                HourInput.Text += "0";
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length < 2)
            {
                MinuteInput.Text += "0";
            }
            else if (SecondInput_active == true && SecondInput.Text.Length < 2)
            {
                SecondInput.Text += "0";
            }
        }
        private void ButtonBksp_Click(object sender, EventArgs e)
        {
            if (HourInput_active == true && HourInput.Text.Length > 0)
            {
                this.HourInput.Text = this.HourInput.Text.Remove(this.HourInput.Text.Length - 1);
            }
            else if (MinuteInput_active == true && MinuteInput.Text.Length > 0)
            {
                this.MinuteInput.Text = this.MinuteInput.Text.Remove(this.MinuteInput.Text.Length - 1);
            }
            else if (SecondInput_active == true && SecondInput.Text.Length > 0)
            {
                this.SecondInput.Text = this.SecondInput.Text.Remove(this.SecondInput.Text.Length - 1);
            }
        }

        private void AMPMCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AMPMCheckbox.Checked)
            {
                AMPMCheckbox.Text = "PM";
            }
            else
            {
                AMPMCheckbox.Text = "AM";
            }
        }

        private void SundayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DayOfWeek.Text = "Sunday";
        }
        private void MondayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DayOfWeek.Text = "Monday";
        }
        private void TuesdayRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            DayOfWeek.Text = "Tuesday";
        }
        private void WednesdayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DayOfWeek.Text = "Wednesday";
        }
        private void ThursdayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DayOfWeek.Text = "Thursday";
        }
        private void FridayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DayOfWeek.Text = "Friday";
        }
        private void SaturdayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DayOfWeek.Text = "Saturday";
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DisableButtons();
        }
        private void Button_SoundAlarm_Click(object sender, EventArgs e)
        {
            PrevAlarm.Text = "Manually Sounded at: " + DateTime.Now.ToString("hh:mm:ss");
            AlarmTrigger();
            DisableButtons();
        }
        private void Button_MuteAlarm_Click(object sender, EventArgs e)
        {
            mute = true;
            NextAlarm.Text = ("Next Alarm Muted");
        }
    }
}
