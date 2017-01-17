using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SleepFromTimer
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Countdown = 0;

        private string udregnTidFraSekunder()
        {
            int tempCountDown = Countdown;
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            if(tempCountDown/3600 > 0)
            {
                hours = tempCountDown / 3600;
                tempCountDown -= hours * 3600;
            }
            if(tempCountDown/60 > 0)
            {
                minutes = tempCountDown / 60;
                tempCountDown -= minutes * 60;
            }
            seconds = tempCountDown;

            string hoursText = hours.ToString();
            string minutesText = minutes.ToString();
            string secondsText = seconds.ToString();

            if(hoursText.Length != 2)
            {
                hoursText = "0" + hoursText;
            }
            if(minutesText.Length != 2)
            {
                minutesText = "0" + minutesText;
            }
            if(secondsText.Length != 2)
            {
                secondsText = "0" + secondsText;
            }

            return hoursText + ":" + minutesText + ":" + secondsText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(startButton.Text == "Stop")
            {
                timer1.Stop();
                Countdown = 0;
                countDownShow.Text = "";
                startButton.Text = "Start";
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }

            if((textBox1.Text == null || textBox1.Text == "") && (textBox2.Text == null || textBox2.Text == "") )
            {
                return;
            }
            
            startButton.Text = "Stop";
            int timerISekunder = 0;
            int minutterISekunder = 0;
            if (textBox1.Text != null && textBox1.Text != "")
            {
                timerISekunder = Convert.ToInt16(textBox1.Text) * 60 * 60;
            }
            if (textBox2.Text != null && textBox2.Text != "")
            {
                minutterISekunder = Convert.ToInt16(textBox2.Text) * 60;
            }
                
            Countdown = timerISekunder + minutterISekunder;
            countDownShow.Text = udregnTidFraSekunder();
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Countdown--;
            countDownShow.Text = udregnTidFraSekunder();

            if(Countdown == 0)
            {
                timer1.Stop();
                startButton.Text = "Start";
                Application.SetSuspendState(PowerState.Suspend, false, false);
            }
        }

        

        

        private void Form1_Load(object sender, EventArgs e)
        {
   
            Timer.BackColor = Color.Transparent;
            Minutter.BackColor = Color.Transparent;
            countDownShow.BackColor = Color.Transparent;
            textBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox2.BorderStyle = BorderStyle.Fixed3D;
            startButton.BackColor = Color.Transparent;
            startButton.TabStop = false;
            startButton.TabStop = false;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            startButton.FlatAppearance.CheckedBackColor = Color.White;
            startButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            startButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            
        }

        private void startButton_MouseEnter(object sender, EventArgs e)
        {
            startButton.FlatAppearance.BorderSize = 1;
            startButton.FlatAppearance.BorderColor = Color.White;
        }

        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            startButton.FlatAppearance.BorderSize = 0;
            startButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                MessageBox.Show("Kun tal");
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                MessageBox.Show("Kun tal");
                e.Handled = true;
            }
        }

        
    }
}
