using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Clasificador_Bayes_Ingenuo
{
    
    public class Archivo
    {
        public class InfoColumna
        {
            public struct DatosCategoria
            {
                public int TotalEncontrado;
                public string Nombre;
            }
            public bool EsClase=false; 
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
        public InfoColumna[] DatosColumna;
        public double SuavisadoLaplacae(int ColumnaClase, List<string[]> input)
        {

            string[,] Aux = { 
                            {"negro","si","peque~no","alta","+"},
                            {"amarillo","no","grande","media","-"},
                            {"amarillo","no","grande","baja","-"},
                            {"blanco","si","medio","alta","+"},
                            {"negro","no","medio","alta","-"},
                            {"rojo","si","peque~no","alta","+"},
                            {"rojo","si","peque~no","baja","-"},
                            {"negro","no","medio","media","-"},
                            {"negro","si","peque~no","media","-"},
                            {"amarillo","si","grande","media","-"}
            };
            TablaValores = Aux;
            DatosColumna = new InfoColumna[TablaValores.GetLength(1)];
            Rows = TablaValores.GetLength(0);
            string[] Cadena = { "color", "alas", "tamañno", "velocidad ", "lepisto" };
            for (int i = 0; i<=TablaValores.GetUpperBound(1);i++)
            {
                DatosColumna[i] = new InfoColumna();
                DatosColumna[i].Indice = i;
                DatosColumna[i].NombreColumna = Cadena[i];
                if(i == (ColumnaClase))
                {
                    DatosColumna[i].EsClase = true;
                }
            }
            for (int i = 0; i <= TablaValores.GetUpperBound(1); i++)
            {
                DatosColumna[i].Correr(TablaValores, i);
              
            }
            //Convierte la tabla en una lista de vectores string
            List<string[]> TablaLista = new List<string[]>();

            for (int i = 0; i <= TablaValores.GetUpperBound(0); i++)
            {
                string[] Temp = new string[TablaValores.GetLength(1)];
                for (int j = 0; j <= TablaValores.GetUpperBound(1); j++)
                {
                    Temp[j] = TablaValores[i, j];
                }
                TablaLista.Add(Temp);
            }

            int ContarIndicidencia(int indiceSearch, string Categoria, string CategoriaCadena)
            {
                int Contar = 0;
                for (int i = 0; i < TablaLista.Count; i++)
                {


                    //&& TablaLista[i][ColumnaClase] == CategoriaCadena
                    if (TablaLista[i][indiceSearch] == Categoria)
                    {
                        if (TablaLista[i][ColumnaClase] == CategoriaCadena)
                        {
                            //MessageBox.Show("Se encontro incidencia" + "\n" + TablaLista[i][indiceSearch] + " | " + TablaLista[i][ColumnaClase]);
                            Contar++;
                        }

                    }

                }


                return Contar;
            }
            //p(+) = 3 / 10
            //p(Amarillo | +) = (0 + 1) / (3 + 4)
            //p(no | +) = (0 + 1) / (3 + 2)
            //p(pequeño | +) = (2 + 1) / (3 + 3)
            //p(alta | +) = (3 + 1) / (3 + 3)

            //p(-) = 7 / 10
            //P(Amarillo | -) = (3 + 1) / (7 + 4)
            //p(no | -) = (4 + 1) / (7 + 2)
            //p(pequeño | -) = (2 + 1) / (7 + 3)
            //p(alta | -) = (1 + 1) / (7 + 3)

            //P(+) P(Amarillo | +) P(no | +P(pequeño | +) P(alta | +) = 0
            //3 / 10 * (0 + 1) / (3 + 4) * (0 + 1) / (3 + 2) * (2 + 1) / (3 + 3) * (3 + 1) / (3 + 3) = 0.00285714


            //P(-) P(Amarillo |-) P(no |-) P(pequeño |-) P(alta |-) = 0.007
            // 7 / 10 * (3 + 1) / (7 + 4) * (4 + 1) / (7 + 2) * (2 + 1) / (7 + 3) * (1 + 1) / (7 + 3) = 0.00848485

            //empieza laplace
            //almacena el resultado de cada bayes 
            double[] Clase = new double [DatosColumna[ColumnaClase].CantidadCategorias];
            //Ciclo para obtener el 
            for(int i = 0; i <= Clase.GetUpperBound(0); i++)
            {
                double[] AuxiliarBayes = new double[DatosColumna.GetLength(0)];
                //Nombre de la categoria interesada
                string Categoria = DatosColumna[ColumnaClase].Categoria[i].Nombre;
                //Ciclo para sacar el bayes
                for (int j = 0; j < TablaLista.Count; i++)
                {
                   
                    for(int k = 0; k <= TablaLista[j].GetUpperBound(0);k++)
                    {
                        //k Maneja la el indice de la columna
                        if (k == ColumnaClase)
                        {
                            // P =  Categoria / Total de del atributos
                            AuxiliarBayes[k] = DatosColumna[k].Categoria[i].TotalEncontrado / TablaLista.Count;
                         
                        }
                        else
                        {
                            AuxiliarBayes[k] = ContarIndicidencia(k,input[j][k],Categoria)+ 1 / 
                                DatosColumna[k].Categoria[i].TotalEncontrado + DatosColumna[k].CantidadCategorias ;   
                        }

                    }
                }

            
            }
           

           

           MessageBox.Show( ContarIndicidencia(0, "amarillo", "-")+"");
           // int[] temp = new int[DatosColumna[ColumnaClase].CantidadCategorias];
           
           
            

            


            //TODO:
            //La asignacion de clases puede ser por probabiliada 20% 40% 60% etc y darles rangos deacuerdo a la distribucion
            //Ciclo para determinar donde se  cumple



            return 0;
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

        public void DiscretizacionFrecuencias(string[,] arreglo)
        {

        }

        public void FuncionDensidad()
        {

        }
        
        public double Varianza(double[] values)                  //(x-media) al cuadrado
        {
            ///<summary>
            ///<para>line1</para>
            ///<para>line2</para>
            ///</summary>
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
