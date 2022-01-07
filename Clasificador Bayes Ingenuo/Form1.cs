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
using System.IO;

namespace Clasificador_Bayes_Ingenuo
{
    public partial class Form1 : Form
    {
        public static Archivo Datos = new Archivo();

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Open File Dialog
                openFileDialog1.Filter = "Todos los archivos|*.*|Archivo de Texto|*.txt|Archivo Separado por comas|*.csv";
                openFileDialog1.Title = "Cargar Dataset";
                openFileDialog1.ShowDialog();

                if (File.Exists(openFileDialog1.FileName))
                {
                    txt_dataset.Text = openFileDialog1.FileName;
                    Datos.LeerArchivo(txt_dataset.Text);
                    numUpDown.Maximum = Datos.TablaValores.GetUpperBound(1) + 1;

                    dgvDataset.Columns.Clear();
                    dgvDataset.Rows.Clear();

                    for (int i = 0; i <= Datos.TablaValores.GetUpperBound(1); i++)
                    {
                        dgvDataset.Columns.Add($"Columna{i}", Datos.TablaTitulos[i].ToString());  
                    }

                    for (int i = 0; i <= Datos.TablaValores.GetUpperBound(0); i++)
                    {
                        dgvDataset.Rows.Add();
                        for (int j = 0; j <= Datos.TablaValores.GetUpperBound(1); j++)
                        {
                            dgvDataset.Rows[i].Cells[j].Value = Datos.TablaValores[i,j];
                        }                      
                    }
                       

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: al abrir el archivo");
            }

            //Crea el dialogo para escoger el archivo
            //OpenFileDialog open = new OpenFileDialog();
            //open.CheckFileExists = true;
            //open.CheckPathExists = true;
            //open.InitialDirectory = @"C:\";
            //open.Title = "Seleccione un dataset";
            //open.DefaultExt = "csv";
            //open.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            /*
          Si el txt no esta vacio y es un numero
            if (txt_clase.Text != "" && int.TryParse(txt_clase.Text,out _))
            {
                Si el recuadro no esta vacio se abre con la direccion puesta
                if (txt_dataset.Text != "")
                {

                    Archivo.LeerArchivo(txt_dataset.Text , Convert.ToInt32(txt_clase.Text));

                    MessageBox.Show("");
                    Form2 settingsForm = new Form2();
                    settingsForm.Show();
                }
                else
                {
                    Si el recuadro se abre se abre el la interfaz para
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

        private void button2_Click(object sender, EventArgs e)
        {
            //Datos.DiscretizacionFrencuencias(int.Parse(txt_intervalo.Text));
            //, int.Parse(numUpDown.Text)
            Datos.DiscretizacionFrencuencias(int.Parse(txt_intervalo.Text), Datos.TablaValores);
            Datos.FuncionDensidad(Datos.TablaValores, int.Parse(numUpDown.Text));

            List<string[]> Pruebas = new List<string[]>();
            //P(+) P(Amarillo | +) P(no | +P(pequeño | +) P(alta | +) = 0


            //string[] temp = { "amarillo", "no", "peque~no", "alta", "" };
            //Pruebas.Add(temp);
            //Datos.SuavisadoLaplacae(Pruebas, 4);

            Form2 settingsForm = new Form2();
            settingsForm.Show();
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
