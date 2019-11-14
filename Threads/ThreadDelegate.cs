using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace MultThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        delegate void SetTextCallback(string texto);
        bool b = true;

        public int teste = 0;

        public void f1()

        {

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(2000);
                string texto = i.ToString();

                if (oListBox.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(DefinirTexto);
                    this.Invoke(d, new object[] { texto + " (Invoke)" });
                }
                else
                {
                    oListBox.Items.Add (texto + " (No Invoke)");
                }


            }

        }

        private void OBtnInicio_Click(object sender, EventArgs e)
        {

            Thread t = new Thread(new ThreadStart(f1));

            t.Start();

            oListBox.Items.Add("Thread 1");

        }
        private void DefinirTexto(string texto)
        {
            oListBox.Items.Add (texto);
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {

       /*     oListBox.Items.Clear();
            oListBox.Items.Add(teste);*/
            
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;

        }

        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        private void SetControlPropertyValue(Control oControl, string propName, object propValue)

        {

            if (oControl.InvokeRequired)

            {

                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);

                oControl.Invoke(d, new object[] { oControl, propName, propValue });

            }

            else

            {

                Type t = oControl.GetType();

                PropertyInfo[] props = t.GetProperties();

                foreach (PropertyInfo p in props)

                {

                    if (p.Name.ToUpper() == propName.ToUpper())

                    {

                        p.SetValue(oControl, propValue, null);

                    }

                }

            }

        }


    }

       
    

}
