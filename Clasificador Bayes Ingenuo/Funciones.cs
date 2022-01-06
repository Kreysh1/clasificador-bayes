using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Clasificador_Bayes_Ingenuo
{
    public class Archivo
    {
        private class InfoColumna
        {
            public struct DatosCategoria
            {
                public int TotalEncontrado;
                public string Nombre;
            }
            public int Indice = 1;
            public string NombreColumna;
            public bool EsNumero = false;
            public int CantidadCategorias = 0;
            public List<DatosCategoria> Categoria= new List<DatosCategoria>();

            public int TotalDeDatos = 0;
           
            //Se pasa la tabla i el indice que al que sacar info

            public void Correr(string[,] tabla, int Indice)
            {
                 int Buscar(DatosCategoria Busqueda)
                {

                    for (int i = 0; i < Categoria.Count; i++)
                    {
                        if (Categoria[i].Nombre == Busqueda.Nombre)
                        {
                            
                            return i;
                        }
                    }
                    return -1;
                }
                //Si es un numero
                EsNumero = double.TryParse(tabla[1, Indice], out _);
                if (EsNumero)
                {

                }
                else
                {
                    DatosCategoria AuxiliarCategoria = new DatosCategoria();
                    //Regresa indice negativo en el caso de no encontrar el elemnto

                    //Empieza la busqueda de categorias
                    int IndiceLista;

                    for (int i = 0; i <= tabla.GetUpperBound(0); i++)
                    {
                        AuxiliarCategoria.Nombre = tabla[i, Indice];
                        IndiceLista = Buscar(AuxiliarCategoria);
                        //Si no es negativo se incrementa el valo de encontrados
                        if (IndiceLista != -1)
                        {
                            //Toma el valor de del indice de la lista para manipularlo y reInsertarlo
                            AuxiliarCategoria = Categoria[IndiceLista];

                            AuxiliarCategoria.TotalEncontrado++;
                            Categoria[IndiceLista] = AuxiliarCategoria;
                        }
                        else
                        {
                            AuxiliarCategoria.Nombre = tabla[i, Indice];
                            AuxiliarCategoria.TotalEncontrado++;
                            Categoria.Add(AuxiliarCategoria);
                           //MessageBox.Show("Se encontro nueva categoria: " + tabla[i, Indice]);
                        }

                        //Limpiar el auxiliar
                        AuxiliarCategoria = new DatosCategoria();
                    }
                    
                    // foreach(var val in Categoria)
                    //{
                    //    MessageBox.Show(val.Nombre + " | " + val.TotalEncontrado);
                    //}
                    CantidadCategorias = Categoria.Count;

                }
               
            }
        }

        //direccion del archivo
        public string DirActual = "";
        //Indice de la columna clase de la tabla
        public int ClaseIndex;

        /// arreglo con con los datos recabadadosd e la tabla
        public string[,] TablaValores;
        public string[] ValoresPrueba;

       
        //Dimensiones de la tabla
        public int Column;
        public int Rows;

        //InfoColumna guarda los datos especificos a una columna
       

        //Guarda el nombre de la columna bajo el mismo indice de la tabla
         InfoColumna[] DatosColumna;

        //Tabla discretizada
        public string[,] TablaDiscretizada;

        public void DiscretizacionFrencuencias(int intervalo, string[,] values)
        {
            for (int i = 0; i <= values.GetUpperBound(1); i++)
            {
                bool EsNumero = double.TryParse(values[0, i], out _); // Comprueba que el primer valor de la columna sea un numero (valor continuo)
                if (EsNumero)
                {

                    double[] sortedValues = new double[values.GetUpperBound(0)+1];

                    //Carga la columna en un array unidimensional
                    for (int j = 0; j <= values.GetUpperBound(0); j++)
                    {
                        //MessageBox.Show(values[j, i]);
                        sortedValues[j] = Convert.ToDouble(values[j, i]);
                    }

                    Array.Sort(sortedValues);

                    int elementos = sortedValues.Length;
                    int categorias = intervalo;
                    double rangos = elementos / categorias;


                    int pivote = (int)rangos;
                    double decimals = rangos - Math.Truncate(rangos);
                    string[,] disc = new string[categorias, 3];

                    //Detectar valor de los rangos ===========================
                    int x = 0;
                    for (int j = 0; j <= sortedValues.GetUpperBound(0); j++)
                    {
                        if ((j == pivote) && (j < sortedValues.Length))
                        {
                            double valor = (Convert.ToDouble(sortedValues[pivote]) + Convert.ToDouble(sortedValues[pivote - 1])) / 2;

                            disc[x, 0] = $"Cat{x + 1}";
                            //Valors "MAYOR O IGUAL QUE"
                            if (x == 0)
                            {
                                disc[x, 1] = "0";
                            }
                            else
                            {
                                disc[x, 1] = disc[x - 1, 2];
                            }
                            //Valors "MENOR"
                            if (x == categorias - 1)
                            {
                                disc[x, 2] = "9999999999999";
                            }
                            else
                            {
                                disc[x, 2] = valor.ToString();
                            }
                           // MessageBox.Show($"{disc[x, 0]} mayor o igual: {disc[x, 1]} menor: {disc[x, 2]}");
                            pivote += (int)rangos;
                            x++;
                        }
                    }

                    disc[x, 0] = $"Cat{x + 1}";
                    disc[x, 1] = disc[x - 1, 2];                                    //MAYOR O IGUAL
                    disc[x, 2] = "99999999999999999999999999999999999999";          //MENOR
                    //MessageBox.Show($"{disc[x, 0]} mayor o igual: {disc[x, 1]} menor: {disc[x, 2]}");

                    ////Discretizacion ==================================

                    //Vuelve a cargar los datos de la columna (para que no salgan ordenados)
                    //Carga la columna en un array unidimensional
                    for (int j = 0; j <= values.GetUpperBound(0); j++)
                    {
                        //MessageBox.Show(values[j, i]);
                        sortedValues[j] = Convert.ToDouble(values[j, i]);
                    }

                    //Para el array con todos los valores.
                    x = 0;
                    for (int j = 0; j <= sortedValues.GetUpperBound(0); j++)
                    {
                        if (Convert.ToDouble(sortedValues[j]) >= Convert.ToDouble(disc[x, 1]) && (Convert.ToDouble(sortedValues[j]) < Convert.ToDouble(disc[x, 2])))
                        {
                            TablaDiscretizada[j, i] = disc[x, 0];
                            MessageBox.Show($"{sortedValues[j]} =  {TablaDiscretizada[j, i]}");
                        }
                        else if (Convert.ToDouble(sortedValues[j]) >= Convert.ToDouble(disc[x + 1, 1]) && (Convert.ToDouble(sortedValues[j]) < Convert.ToDouble(disc[x + 1, 2])))
                        {
                            x++;
                            TablaDiscretizada[j, i] = disc[x, 0];
                            MessageBox.Show($"{sortedValues[j]} = {TablaDiscretizada[j, i]}");
                        }
                    }

                }
                else
                {
                    // Aca entra cuando los valores de la columna son discretos (osea que los valores son categorias)
                    for (int j = 0; j <= values.GetUpperBound(0); j++)
                    {
                        MessageBox.Show(values[j, i]);
                        TablaDiscretizada[j, i] = values[j, i];
                    }
                }
            }
        }


        private void DeterminarDimensiones(string DirArchivo)
        {
            try
            {
                StreamReader Reader = new StreamReader(File.OpenRead(DirArchivo));

                //Tabla hecha de listas
                //Varaibles para determinar el tamano del arreglo
                int Fila, Columnas;

                //Se leen y cuenta las cantidades de lineas en el archivo
                Fila = File.ReadAllLines(DirArchivo).Length;
                //Se lee la primera fila para determinar la cantidad de columnas
                string Linea = Reader.ReadLine();
                string[] values = Linea.Split(',');
                Columnas = values.Length;
                
                //Arreglo de los datos de cada columna
                DatosColumna = new InfoColumna[Columnas];

                //Se crea la tabla y se ommite la primera fila para el tamano de la tabla de datos
                TablaValores = new string[Fila-1, Columnas];
                TablaDiscretizada = new string[Fila - 1, Columnas];

                for (int i = 0; i < Columnas; i++)
                {
                    DatosColumna[i] = new InfoColumna();
                    DatosColumna[i].Indice = i;
                    DatosColumna[i].NombreColumna = values[i];
                }
       
                Column = Columnas;
                Rows = Fila;
               

                System.Windows.Forms.MessageBox.Show(Fila + " | " + Columnas + " \n " + TablaValores.GetUpperBound(0) + " | " + TablaValores.GetUpperBound(1));
                Reader.Close();
            }
            catch (Exception e)
            {
               
                throw e;
            }
            
        }


        public void LeerArchivo(string DirArchivo, int Clase)
        {
            //Se dimensiona el array para guardar los datos
            DeterminarDimensiones(DirArchivo);
            ClaseIndex = Clase;
            StreamReader reader = new StreamReader(File.OpenRead(DirArchivo));
           
     
            int FilaActual = 0;
            reader.ReadLine();//Se salta los nombres de columnas
            //Se puebla el array con datos
            while (!reader.EndOfStream)
            {
                string[] DatosFila = reader.ReadLine().Split(',');
                for (int i = 0; i <= DatosFila.GetUpperBound(0); i++)
                {
                    TablaValores[FilaActual, i] = DatosFila[i];
                }

                FilaActual++;
            }
            for(int i = 0; i <= TablaValores.GetUpperBound(1);i++)
            {
                DatosColumna[i].Correr(TablaValores,i);
            }


            reader.Close();
        }

        public double Varianza(double[] values)                  //(x-media) al cuadrado
        {
            double avg = Media(values);
            double variance = 0.0;

            foreach (double value in values)
            {
                // Math.Pow => Devuelve un número especificado elevado a la potencia especificada.
                variance += Math.Pow(value - avg, 2.0);
            }
            return variance;
        }
        public double Suma(double[] values)     //Suma los valores de la columna
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }

        public double Media(double[] values) //Promedio
        {
            double sum = Suma(values);
            double avg = sum / values.Length;
            return avg;
        }

        public double DesviacionEstandar(double variance)        //Raiz cuadrada de la varianza  (DESVEST.P para poblacion)
        {
            return Math.Sqrt(variance);
        }
    }
}
