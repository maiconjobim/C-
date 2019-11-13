using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MultThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        bool b = true;

        public int teste = 0;

        public void f1()

        {

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(3000);
                teste = i;
            }

        }

        private void OBtnInicio_Click(object sender, EventArgs e)
        {

            Thread t = new Thread(new ThreadStart(f1));

            t.Start();
          

        }

       

        private void Timer1_Tick(object sender, EventArgs e)
        {

            oListBox.Items.Clear();
            oListBox.Items.Add(teste);
            
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;

        }
    }

       
    

}
