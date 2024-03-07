using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.05;
        int days = 1;
        bool check = true;
        double euro;
        double dollar;

        Random random = new Random();

        private void btPredict_Click(object sender, EventArgs e)
        {
            if (check)
            {
                check = false;

                euro = (double)edRate.Value;
                dollar = (double)edDollar.Value;

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.Series[0].Points.AddXY(0, euro);
                chart1.Series[1].Points.AddXY(0, dollar);
            }
            if (timer1.Enabled) timer1.Stop();
            else timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            euro = euro * (1 + k * (random.NextDouble() - 0.5));
            dollar = dollar * (1 + k * (random.NextDouble() - 0.5));

            chart1.Series[0].Points.AddXY(days, euro);
            chart1.Series[1].Points.AddXY(days, dollar);

            days += 1;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        
    }
}
