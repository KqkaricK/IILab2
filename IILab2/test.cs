using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace IILab2
{
    public partial class test : Form
    {
        private Stopwatch stopWatch;
        const int size = 50;
        int[] num;
        int master = 0;
        string[] lines = File.ReadAllLines("data.txt");
        string[] done = new string[size];
        string time = DateTime.Now.ToString("d-M-yyyy HH-mm-ss");

        public test()
        {
            InitializeComponent();
        }

        private void yes_button_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
            File.AppendAllText("log" + time + ".txt", label2.Text + " Да " + label1.Text + Environment.NewLine);
            if (master > 49)
            {
                MessageBox.Show("Тест заверщён!");
                System.Windows.Forms.Application.Exit();
            }
            else 
            {
                stopWatch.Reset();
                stopWatch.Start();
                voprosi();
            }
        }

        private void no_button_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
            File.AppendAllText("log" + time + ".txt", label2.Text + " Нет " + label1.Text + Environment.NewLine);
            if (master > 49)
            {
                MessageBox.Show("------------");
                Application.Exit();
            }
            else
            {
                stopWatch.Reset();
                stopWatch.Start();
                voprosi();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = string.Format("{0:hh\\:mm\\:ss\\:fff}", stopWatch.Elapsed);
        }

        private void test_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            num = poradok();
            voprosi();
        }
        private int[] poradok()
        {
            int[] nums = new int[size];
            int i = 0;
            while (size > i)
            {
                nums[i] = i;
                i++;
            }
            Random rand = new Random();
            for (i = size - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                int tmp = nums[j];
                nums[j] = nums[i];
                nums[i] = tmp;
            }
            return nums;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void voprosi()
        {
            done[master] = lines[num[master]];
            label2.Text = done[master];
            master++;
        }
    }
}
