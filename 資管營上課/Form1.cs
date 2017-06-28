using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 資管營上課
{
    public partial class Form1 : Form
    {
        Boolean UpDown = true, LeftRight =true ;
        int score = 0,time = 30, speed=1;      
        
        public Form1()
        {
            InitializeComponent();
            Random rand = new Random();
            label1.Location = new Point(rand.Next(0, Width - label1.Width), rand.Next(35, Height - label1.Height));
        }
        void Direction()
        {
            if(label1.Bottom > Height-label1.Height/2)
            {
                UpDown = true;
            }else if(label1.Top <30)
            {
                UpDown = false;
            }
            if (label1.Right > Width)
            {
                LeftRight = true;
            }else if (label1.Left < 0)
            {
                LeftRight = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (time <= 0)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = true;
                button1.Visible = true;
                button1.Text = "Restart";
                label4.Text = "TIME OUT \r\n\r\n SCORED: " + score;
            }
            time -= 5;
            label3.Text = "Time: " + time;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            score += 1;
            speed += 1;
            label2.Text = "Score: " + score;
            Random rand = new Random();
            label1.Location = new Point(rand.Next(0, Width - label1.Width), rand.Next(35, Height - label1.Height));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Direction();
            if (UpDown)
            {
                label1.Top -= speed;
            }else
            {
                label1.Top += speed;
            }
            if (LeftRight)
            {
                label1.Left -= speed;
            }else
            {
                label1.Left += speed;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            speed = 1;
            score = 0;
            label2.Text = "Score: " + score;
            time = 30;
            label3.Text = "Time: " + time;
            timer1.Start();
            timer2.Start();
            timer1.Interval = 10;
            timer2.Interval = 1000;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            button1.Visible = false;
        }
    }
}
