using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Clasificador_Bayes_Ingenuo
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //try{
                //Crea el dialogo para escoger el archivo
                OpenFileDialog open = new OpenFileDialog();
                open.CheckFileExists = true;
                open.CheckPathExists = true;
                open.InitialDirectory = @"C:\";
                open.Title = "Seleccione un dataset";
                open.DefaultExt = "csv";
                open.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            
            Archivo.LeerArchivo(@"C:\Users\alex_\Documents\Diabetes.csv",9);
                MessageBox.Show("a");
                Form2 settingsForm = new Form2();
                settingsForm.Show();
            /*
          //Si el txt no esta vacio y es un numero
            if (txt_clase.Text != "" && int.TryParse(txt_clase.Text,out _))
            {
                //Si el recuadro no esta vacio se abre con la direccion puesta
                if (txt_dataset.Text != "")
                {

                    Archivo.LeerArchivo(txt_dataset.Text , Convert.ToInt32(txt_clase.Text));

                    MessageBox.Show("");
                    Form2 settingsForm = new Form2();
                    settingsForm.Show();
                }
                else
                {
                    //Si el recuadro se abre se abre el la interfaz para
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        Archivo.LeerArchivo(open.FileName, Convert.ToInt32(txt_clase.Text));
                        for(int i=0; i < Archivo.Column; i++)
                        {
                            MessageBox.Show("");
                        }
                        Form2 settingsForm = new Form2();
                        settingsForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se selecciono un archivo");
                    }

                }
            }
            else
            {
                MessageBox.Show("Indique la columna de clase");
            }

        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

      */


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
