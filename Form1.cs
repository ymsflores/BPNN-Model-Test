using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;


namespace BPNN_Model_Test_2
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        int epochCounter;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(4, Convert.ToInt32(textBox7.Text), 1);
            epochCounter = 0;

            textBox8.Text = epochCounter.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int epochAdd = Convert.ToInt32(textBox6.Text);
            epochCounter += epochAdd;
            textBox8.Text = epochCounter.ToString();

            // instead of using textboxes, pre-generate since we know what results we want
            for (int x = 0; x < epochAdd; x++)
            {
                generate_input(0.0, 0.0, 0.0, 0.0);
                generate_input(0.0, 0.0, 0.0, 1.0);
                generate_input(0.0, 0.0, 1.0, 0.0);
                generate_input(0.0, 0.0, 1.0, 1.0);
                generate_input(0.0, 1.0, 0.0, 0.0);
                generate_input(0.0, 1.0, 0.0, 1.0);
                generate_input(0.0, 1.0, 1.0, 0.0);
                generate_input(0.0, 1.0, 1.0, 1.0);
                generate_input(1.0, 0.0, 0.0, 0.0);
                generate_input(1.0, 0.0, 0.0, 1.0);
                generate_input(1.0, 0.0, 1.0, 0.0);
                generate_input(1.0, 0.0, 1.0, 1.0);
                generate_input(1.0, 1.0, 0.0, 0.0);
                generate_input(1.0, 1.0, 0.0, 1.0);
                generate_input(1.0, 1.0, 1.0, 0.0);
                generate_input(1.0, 1.0, 1.0, 1.0);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.setInputs(2, Convert.ToDouble(textBox3.Text));
            nn.setInputs(3, Convert.ToDouble(textBox4.Text));
            nn.run();
            textBox5.Text = "" + nn.getOuputData(0);
        }

        private void generate_input(double i0, double i1, double i2, double i3)
        {
            nn.setInputs(0, i0);
            nn.setInputs(1, i1);
            nn.setInputs(2, i2);
            nn.setInputs(3, i3);

            if (i0 == 1.0 && i1 == 1.0 && i2 == 1.0 && i3 == 1.0)
                nn.setDesiredOutput(0, 1.0);
            else
                nn.setDesiredOutput(0, 0.0);

            nn.learn();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
