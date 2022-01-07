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
        int Columna;

        DataGridView MostrarDataset(string[] Titulos, string[,] Contenido)
        {
            dgvDataset.Columns.Clear();
            dgvDataset.Rows.Clear();
            DataGridView Tabla = new DataGridView();
            for (int i = 0; i <= Contenido.GetUpperBound(1); i++)
            {
                dgvDataset.Columns.Add($"Columna{i}", Titulos[i].ToString());
            }

            for (int i = 0; i <= Contenido.GetUpperBound(0); i++)
            {
                dgvDataset.Rows.Add();
                for (int j = 0; j <= Contenido.GetUpperBound(1); j++)
                {
                    dgvDataset.Rows[i].Cells[j].Value = Contenido[i, j];
                }
            }

            return Tabla;
        }
        DataGridView MostrarTablaDeConfucion(string[] Titulos, string[,] Contenido)
        {
            TablaConfusion.Columns.Clear();
            TablaConfusion.Rows.Clear();
            DataGridView Tabla = new DataGridView();
            for (int i = 0; i <= Contenido.GetUpperBound(1); i++)
            {
                TablaConfusion.Columns.Add($"Columna{i}", Titulos[i].ToString());
            }

            for (int i = 0; i <= Contenido.GetUpperBound(0); i++)
            {
                TablaConfusion.Rows.Add();
                for (int j = 0; j <= Contenido.GetUpperBound(1); j++)
                {
                    TablaConfusion.Rows[i].Cells[j].Value = Contenido[i, j];
                }
            }

            return Tabla;
        }
        DataGridView MostrarTablaDeEvaluacion(string[,] Contenido)
        {
            dgvDataset.Columns.Clear();
            dgvDataset.Rows.Clear();
            DataGridView Tabla = new DataGridView();

            for (int i = 0; i <= Contenido.GetUpperBound(0); i++)
            {
                dvgEvaluacion.Rows.Add();
                for (int j = 0; j <= Contenido.GetUpperBound(1); j++)
                {
                    dvgEvaluacion.Rows[i].Cells[j].Value = Contenido[i, j];
                }
            }

            return Tabla;
        }
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
                    
                    txt_clase.Maximum = Datos.TablaValores.GetUpperBound(1) + 1;
                    txt_intervalo.Maximum = Datos.TablaValores.GetUpperBound(0) + 1;

                    dgvDataset.Columns.Clear();
                    dgvDataset.Rows.Clear();
                   
                    MostrarDataset(Datos.TablaTitulos, Datos.TablaValores);
                    //for (int i = 0; i <= Datos.TablaValores.GetUpperBound(1); i++)
                    //{
                    //    dgvDataset.Columns.Add($"Columna{i}", Datos.TablaTitulos[i].ToString());
                    //    MessageBox.Show("Titulo");
                    //}

                    //for (int i = 0; i <= Datos.TablaValores.GetUpperBound(0); i++)
                    //{
                    //    dgvDataset.Rows.Add();
                    //    for (int j = 0; j <= Datos.TablaValores.GetUpperBound(1); j++)
                    //    {
                    //        dgvDataset.Rows[i].Cells[j].Value = Datos.TablaValores[i,j];
                    //    }                      
                    //}
                       

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: al abrir el archivo");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Datos.DiscretizacionFrencuencias(int.Parse(txt_intervalo.Text));
            //, int.Parse(numUpDown.Text)
            Datos.ClaseIndex =int.Parse(txt_clase.Text) -1;

            Datos.DiscretizacionFrencuencias(int.Parse(txt_intervalo.Text), Datos.TablaValores);
            MostrarDataset(Datos.TablaTitulos,Datos.TablaDiscretizada);

            // Datos.FuncionDensidad(Datos.TablaValores, int.Parse(numUpDown.Text));

            string[,]ArregloValidacion=Datos.Validar(Datos.TablaDiscretizada,Datos.ClaseIndex, Datos.DatosColumna[Datos.ClaseIndex].Categoria, int.Parse(txt_intervalo.Text), txt_Entrenamiento.Text);

            double[,] TablaConfusion = Datos.CrearMatrizDeConfusion(ArregloValidacion, Datos.TablaValores, Datos.DatosColumna[Datos.ClaseIndex].Categoria, Datos.ClaseIndex);

            string[,] TablaEvaluacion = Datos.MetricasEvaluacion(int.Parse(txt_clase.Text)-1, TablaConfusion);
            MostrarTablaDeEvaluacion(TablaEvaluacion);
            txt_accuracy.Text = Datos.Accuracy.ToString();

            List<string[]> Pruebas = new List<string[]>();

          
            //P(+) P(Amarillo | +) P(no | +P(pequeño | +) P(alta | +) = 0


            //string[] temp = { "amarillo", "no", "peque~no", "alta", "" };
            //Pruebas.Add(temp);
            //Datos.SuavisadoLaplacae(Pruebas, 4);

            //Form2 settingsForm = new Form2();
            //settingsForm.Show();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[,] DatosPrueba = Datos.DatosPrueba(@"C:\Users\alex_\Desktop\Radeon ReLive\Documentacion\datasets\prueba.txt");
            Console.WriteLine();
        }
    }
}
