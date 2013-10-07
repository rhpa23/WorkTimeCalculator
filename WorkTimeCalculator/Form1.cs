using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkTimeCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CalculaTempo();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            CalculaTempo();
        }

        private void CalculaTempo()
        {
            DateTime dtDiaTodo = dateTimePicker4.Value.Subtract(dateTimePicker1.Value.TimeOfDay);

            DateTime dtAlmoco = dateTimePicker3.Value.Subtract(dateTimePicker2.Value.TimeOfDay);

            DateTime dtTotal = dtDiaTodo.Subtract(dtAlmoco.TimeOfDay);


            if (checkBox1.Checked)
            {
                DateTime dtSaidaExtra = dateTimePicker5.Value.Subtract(dateTimePicker6.Value.TimeOfDay);
                dtTotal = dtTotal.Subtract(dtSaidaExtra.TimeOfDay);
            }

            lblTotal.Text = dtTotal.ToString("HH:mm");

            if (dtTotal.Minute > 0)
            {
                double fracao = (double)dtTotal.Minute / (double)60;
                lblFracao.Text = (dtTotal.Hour + Math.Round(fracao,3)).ToString();
            }
            else
            {
                lblFracao.Text = dtTotal.Hour.ToString("0.000");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pnlExtra.Visible = checkBox1.Checked;
            CalculaTempo();
        }
    }
}
