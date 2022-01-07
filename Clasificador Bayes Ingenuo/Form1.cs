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
        string[,] DatosPrueba;
        void TablaConfusio(List<Archivo.DatosCategoria>Clases , double[,] Contenido )
        {
            TablaConfusion.Columns.Clear();
            TablaConfusion.Rows.Clear();
            DataGridView Tabla = new DataGridView();
            //TablaConfusion.Columns.Add($"", "");
            for (int i = 0; i < Clases.Count; i++)
            {
               
                TablaConfusion.Columns.Add($"Columna{i}", Clases[i].Nombre);
                //MessageBox.Show("Columna");
            }
            
            
            for (int i = 0; i <= Contenido.GetUpperBound(0); i++)
            {
                TablaConfusion.Rows.Add();
                //MessageBox.Show(TablaConfusion.Rows.Count.ToString());
                //TablaConfusion.Rows[i].Cells[0].Value = Clases[i].Nombre;
                for (int j = 0; j <= Contenido.GetUpperBound(1); j++)
                {
                    TablaConfusion.Rows[i].Cells[j].Value = Contenido[i, j];                   
                }                 
            }

           
        }
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
        DataGridView MostrarDensidad(string[] Titulos, string[,] Contenido)
        {

            DatasetDensidad.Columns.Clear();
            DatasetDensidad.Rows.Clear();
            DataGridView Tabla = new DataGridView();
            for (int i = 0; i <= Contenido.GetUpperBound(1); i++)
            {
                DatasetDensidad.Columns.Add($"Columna{i}", Titulos[i].ToString());
            }

            for (int i = 0; i <= Contenido.GetUpperBound(0); i++)
            {
                DatasetDensidad.Rows.Add();
                for (int j = 0; j <= Contenido.GetUpperBound(1); j++)
                {
                    DatasetDensidad.Rows[i].Cells[j].Value = Contenido[i, j];
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
            dvgEvaluacion.Rows.Clear();
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
                DialogoArchivo.Filter = "Todos los archivos|*.*|Archivo de Texto|*.txt|Archivo Separado por comas|*.csv";
                DialogoArchivo.Title = "Cargar Dataset";
                DialogoArchivo.ShowDialog();

                if (File.Exists(DialogoArchivo.FileName))
                {
                    txt_dataset.Text = DialogoArchivo.FileName;

                   
                    Datos.LeerArchivo(txt_dataset.Text);
                    
                    txt_clase.Maximum = Datos.TablaValores.GetUpperBound(1) + 1;
                    
                    txt_intervalo.Maximum = Datos.TablaValores.GetUpperBound(0) + 1;
                  
                    dgvDataset.Columns.Clear();
                    dgvDataset.Rows.Clear();
                    txt_clase.Text = txt_clase.Maximum.ToString();
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


            if (Validacion.Checked == true)
            {
                if(txt_Entrenamiento.Text != "")
                {
                    // Datos.FuncionDensidad(Datos.TablaValores, int.Parse(numUpDown.Text));
                   // MessageBox.Show("entro en validacion");
                    string[,] ArregloValidacion = Datos.Validar(Datos.TablaDiscretizada, Datos.ClaseIndex, Datos.DatosColumna[Datos.ClaseIndex].Categoria, int.Parse(txt_intervalo.Text), txt_Entrenamiento.Text);

                    MostrarDensidad(Datos.TablaTitulos, ArregloValidacion);
                    double[,] TablaConfusion = Datos.CrearMatrizDeConfusion(ArregloValidacion, Datos.TablaValores, Datos.DatosColumna[Datos.ClaseIndex].Categoria, Datos.ClaseIndex);
                    TablaConfusio(Datos.DatosColumna[Datos.ClaseIndex].Categoria, TablaConfusion);
                    string[,] TablaEvaluacion = Datos.MetricasEvaluacion(int.Parse(txt_clase.Text) - 1, TablaConfusion);
                    MostrarTablaDeEvaluacion(TablaEvaluacion);
                    txt_accuracy.Text = Datos.Accuracy.ToString();
                }
                else
                {
                    MessageBox.Show("Falta el porcentaje de entrenamiento");
                }
            }
            else
            {
                if ((txt_rutaprueba.Text != "")) { 
                    DatosPrueba = Datos.DatosPrueba(txt_rutaprueba.Text);
                    Datos.DiscretizarPruebas(int.Parse(txt_intervalo.Text), DatosPrueba);
                    // string[,] DatosDiscretosPrueba = Datos.DiscretizarPruebas(int.Parse(txt_intervalo.Text), DatosPrueba);
                    if (DatosPrueba.GetLength(1) != Datos.TablaValores.GetLength(1))
                    {
                        MessageBox.Show("Datos de prueba no coinciden con la cantidad de columnas ");
                    }

                    string[,] aux = Datos.SuavisadoLaplacae(Datos.PruebaDiscretizada, Datos.ClaseIndex);
                    MostrarDensidad(Datos.TablaTitulos, aux);

                }
                else
                {
                    MessageBox.Show("Falta ruta de archivo de pruebas");
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string[,] DatosPrueba = Datos.DatosPrueba(@"C:\Users\alex_\Desktop\Radeon ReLive\Documentacion\datasets\prueba.txt");
            //Console.WriteLine();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogoPruebas.Filter = "Todos los archivos|*.*|Archivo de Texto|*.txt|Archivo Separado por comas|*.csv";
                DialogoPruebas.Title = "Cargar Dataset";
                DialogoPruebas.ShowDialog();
                if (File.Exists(DialogoArchivo.FileName))
                {
                    txt_rutaprueba.Text = DialogoPruebas.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: al abrir el archivo");
            }
        }

        private void txt_rutaprueba_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
