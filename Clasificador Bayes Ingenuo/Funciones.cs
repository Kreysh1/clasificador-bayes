using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
namespace Clasificador_Bayes_Ingenuo
{
    public class Archivo
    {
        public struct DatosCategoria
        {
            public int TotalEncontrado;
            public string Nombre;
        }
        public class InfoColumna
        {
           
            public int Indice = 1;
            public string NombreColumna;
            public bool EsClase = false;
            public bool EsNumero = false;
            public int CantidadCategorias = 0;
            public List<DatosCategoria> Categoria= new List<DatosCategoria>();

            //Datos de desnsidad
            public double Media =0; 
            public double DesvacionEstandar = 0;
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
                    //En caso de que sea un numero se hace lo siguiente
                    
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
        public string[] TablaTitulos;
        public string[] ValoresPrueba;
        public List<string[]> TablaDiscreta = new List<string[]>();
       
        void TransFormarArregloALista(string[,] Entrada)
        {
            for (int i = 0; i <= Entrada.GetUpperBound(0); i++)
            {
                string[] Temp = new string[Entrada.GetLength(1)];
                for (int j = 0; j <= Entrada.GetUpperBound(1); j++)
                {
                    Temp[j] = Entrada[i, j];
                }
                TablaDiscreta.Add(Temp);
            }
        }
        //Dimensiones de la tabla
        public int Column;
        public int Rows;

        int NumeroRandom(int Rango)
        {
            Random r = new Random();
            int rInt = r.Next(0, Rango);
            return rInt;
        }
        void ObtenerDatosColumnaDiscreto()
        {
            DatosColumnasDiscretisar = new InfoColumna[TablaDiscretizada.GetLongLength(1)];
            for (int i = 0; i <= TablaDiscretizada.GetUpperBound(1); i++)
            {
                DatosColumnasDiscretisar[i] = new InfoColumna();    
                DatosColumnasDiscretisar[i].Correr(TablaDiscretizada, i);
            }
        }
        public double[,] CrearMatrizDeConfusion(string[,] TablaDiscreta, string[,] TablaReal, List<DatosCategoria> ListaClases, int colClase)
        {
            //Se crea un diccionaria de claes para facilizar ciertas acciones
            Dictionary<string, double> DiccionarioDeClases = new Dictionary<string, double>();
            for (int i = 0; i < ListaClases.Count; i++)
            {
                DiccionarioDeClases.Add(ListaClases[i].Nombre, ListaClases[i].TotalEncontrado);
                DiccionarioDeClases[ListaClases[i].Nombre] = 1;
            }

   
            

            double[,] matrizConfusion = new double[DiccionarioDeClases.Count, DiccionarioDeClases.Count];

            for (int i = 0; i < TablaDiscreta.GetLength(0); i++)
            {

                if (TablaDiscreta[i, colClase].Equals(TablaReal[i, colClase]) || TablaDiscreta[i, colClase] != TablaReal[i, colClase])
                {

                    //MessageBox.Show($"Valor en matrizDatos: {matrizDatos[i, colClase]}, Valor en matrizReal: {matrizReal[i, colClase]}", "Matriz Confusion");

                    int indice1 = DiccionarioDeClases.Keys.ToList().IndexOf(TablaDiscreta[i, colClase]);
                    int indice2 = DiccionarioDeClases.Keys.ToList().IndexOf(TablaReal[i, colClase]);

                    matrizConfusion[indice1, indice2] += 1;
                    //MessageBox.Show($"El valor de la posicion {indice1}, {indice2} es {matrizConfusion[indice1, indice2]}", "Matriz Confusion");
                    //MessageBox.Show($"", "Matriz Confusion");

                }

            }

            return matrizConfusion;

        }

        ///Categorias es es la cantidad de categorias por dicretisacion
        ///Entrenamiento es la cadena que representa el porcentaje
        ///Lista de claes es la lista de las categorias de del la columna clase
        public string[,] Validar(string[,] Tabla, int ColumnaClase, List<DatosCategoria> ListaClases,  int categorias, string entrenamiento)
        {

            //Se conviete a un diccionario para agilizar ciertas acciones
            Dictionary<string, double> DiccionarioDeClaeses = new Dictionary<string, double>();

            for (int i = 0; i < ListaClases.Count; i++)
            {
                DiccionarioDeClaeses.Add(ListaClases[i].Nombre, ListaClases[i].TotalEncontrado);
                DiccionarioDeClaeses[ListaClases[i].Nombre] = 1;
            }


            //Se cuentan los datos relacionados a la tabla (Nombre, N cantidad de categorias y sus categorias Etc)
           int[] CantidaDeCategoriasPorColumna= new int[Tabla.GetLength(1)];

            ObtenerDatosColumnaDiscreto();
            for (int i = 0; i < Tabla.GetLength(1); i++)
            {

                //Se vuelve a obtener los datos del a tabla ya discretizada
                //esto para hacer bien el vayes
                DatosColumnasDiscretisar[i].Correr(Tabla, i);
                //en el caso de que sea la columna clase este pasara a aser 0
                if (i !=ColumnaClase){
                    CantidaDeCategoriasPorColumna[i] = DatosColumnasDiscretisar[i].Categoria.Count;
                }
                else
                {
                    CantidaDeCategoriasPorColumna[i] =0;
                }


            }
            //Dimensiones de la tabla
            int Renglones = Tabla.GetLength(0);
            int Columnas = Tabla.GetLength(1);


            //Se Convierte el los la cadena del porcentage de entrenamiento a unn decimal correspondiente
            double PorcentajeDeEntremaniento = Double.Parse(entrenamiento) / 100;
            //Cantidad de datos en la tabla
            double CantidadDeDatosEnLaTabla = Math.Ceiling(Renglones * PorcentajeDeEntremaniento);

            int IndiceFinDeEntrenamiento = Convert.ToInt32(Renglones - CantidadDeDatosEnLaTabla);

            // Se necesita una lista de probabilidades ya que estas variaran dependiendo del numero de clases
            double[] ProbabilidadDeClase = new double[DiccionarioDeClaeses.Count];     // Lista de probabilidades
            int k = 1;

        
            //Arreglo que guardara los contadores por atributo y  clase 
            double[,] TablaDeProbabilidades = new double[Columnas, DiccionarioDeClaeses.Count];

            
            //Este ciclo empieza desde el renglon donde comienzan las los pruebas
            for (int i = IndiceFinDeEntrenamiento; i < Renglones; i++)    
            {
                // Se inicializa la tabla de probabilidades  con los valores de k = 1 (Lapacle)
                for (int j = 0; j < Columnas; j++)
                {

                    for (int z = 0; z < DiccionarioDeClaeses.Count; z++)
                    {
                        //Le asigna a todas las probs 1
                        TablaDeProbabilidades[j, z] = k;

                    }

                }
                //Se saca la probabilada de que sumando la incidencia de los datos prueba
                // Comienza la asignacion de valores
                //Se Recorren todas las columnas de la tabla
                for (int j = 0; j < Columnas; j++)           
                {
                    //Si el indice J no es mismo que el de la columna clase
                    if (!(j == ColumnaClase))
                    {

                        // En este for se buscan los valores del valor en el que se esta parado
                        for (int x = 0; x < IndiceFinDeEntrenamiento; x++)          // Este for recorre los indices que son de entrenamiento
                        {
                            // Se recorre las clases para verificar si el valor pertenece a alguna de ellas
                            for (int c = 0; c < DiccionarioDeClaeses.Count; c++)
                            {
                    

                                //Funcion para contar la incidencia de la clase 
                                //Si el el dato en la columna tiene                     Si el renglo tiene la clase

                                if (Tabla[i, j].Equals(Tabla[x, j]) && DiccionarioDeClaeses.ElementAt(c).Key.Equals(Tabla[x, ColumnaClase]))
                                {

                                    //Cuando se cumple aumenta en uno la tabla
                                    //MessageBox.Show("Se cumple en la hilera:" );
                                    TablaDeProbabilidades[j, c] += 1;   // Aquí se va almacenando la cantidad de veces que se tiene el valor y pertenece a la clase
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("No se cumplio");
                                }

                            }


                        }



                    }
                   

                }
              
                // Se obtienen las probabilidades del renglon
                for (int y = 0; y < DiccionarioDeClaeses.Count; y++)
                {

                    double ProababildadFinal = 1;

                    for (int x = 0; x < Columnas; x++)
                    {
                        if (!(x == ColumnaClase))
                        {

                            // Se debe saber cuantas categorias hay por columna, es decir, si el dato ya viene discretizado se necesita saber cuantas categorias tiene esa columna
                            // De forma que si es igual a 0 entonces la columna no estaba discretizada
                            if (CantidaDeCategoriasPorColumna[x] == 0)
                            {
                                TablaDeProbabilidades[x, y] = TablaDeProbabilidades[x, y] / (DiccionarioDeClaeses.ElementAt(y).Value + categorias);   // Se suma el numero categorias del atributo
                            }
                            else
                            {

                                TablaDeProbabilidades[x, y] = TablaDeProbabilidades[x, y] /(DiccionarioDeClaeses.ElementAt(y).Value + CantidaDeCategoriasPorColumna[x]);   // Se suma el numero categorias de la columna que ya estaba discretizada al atributo

                            }
                            //Se multiplica lo que ya tenia con la Probabiliad producida de la tabla
                            ProababildadFinal *= TablaDeProbabilidades[x, y];

                        }

                    }

                    // Se guardan las probabilidades del renglón de cada clase 
                    ProbabilidadDeClase[y] = ProababildadFinal * (DiccionarioDeClaeses.ElementAt(y).Value / Renglones);
                    //MessageBox.Show($"La probabilidad de la clase {y} = {probabilidades[y]}", "Probabilidades");

                }

                // Se obtiene el indice del numero mayor y se asigna la clase al renglón mediante el indice
                for (int x = 0; x < ProbabilidadDeClase.Length; x++)
                {


                    if (ProbabilidadDeClase[x] == ProbabilidadDeClase.Max())
                    {

                        Tabla[i, ColumnaClase] = DiccionarioDeClaeses.ElementAt(x).Key;
                        
                    }

                }


            }

            return Tabla;
        }


        //InfoColumna guarda los datos especificos a una columna
        
        //Guarda el nombre de la columna bajo el mismo indice de la tabla
        public InfoColumna[] DatosColumna;
        public InfoColumna[] DatosColumnasDiscretisar;

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
                    double rangos = (double)elementos / (double)categorias;
                    var entero = (long)rangos;
                    var decimalPart = rangos - entero;

                    //MessageBox.Show(decimalPart.ToString());

                    //Redondear el valor de los rangos
                    if (decimalPart >= 0.5)
                    {
                        rangos = entero + 1;
                    }
                    else
                    {
                        rangos = entero; //<== Se puede quitar
                    }


                    //MessageBox.Show($"Rangos:{rangos.ToString("F2")}Categorias:{categorias.ToString()}");

                    int pivote = (int)rangos;
                    string[,] disc = new string[categorias, 3];

                    //Detectar valor de los rangos ===========================
                    int x = 0;
                    for (int j = 0; j <= sortedValues.GetUpperBound(0); j++)
                    {
                        if ((j == pivote-1) && (j < sortedValues.Length-1))
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
                            //MessageBox.Show($"{disc[x, 0]} mayor o igual: {disc[x, 1]} menor: {disc[x, 2]}");
                            pivote += (int)rangos;
                            //MessageBox.Show($"Pivote:{pivote} sortedLength: {sortedValues.Length}");
                            x++;
                        }
                    }
                    //MessageBox.Show(x.ToString());
                    if (x < categorias)
                    {
                        disc[x, 0] = $"Cat{x + 1}";
                        disc[x, 1] = disc[x - 1, 2];                                    //MAYOR O IGUAL
                        disc[x, 2] = "99999999999999999999999999999999999999";          //MENOR
                       // MessageBox.Show($"{disc[x, 0]} mayor o igual: {disc[x, 1]} menor: {disc[x, 2]}");
                    }


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
                        for (int k = 0; k<=disc.GetUpperBound(0); k++)
                        {
                            if (Convert.ToDouble(sortedValues[j]) >= Convert.ToDouble(disc[k, 1]) && (Convert.ToDouble(sortedValues[j]) < Convert.ToDouble(disc[k, 2])))
                            {
                                TablaDiscretizada[j, i] = disc[k, 0];
                               // MessageBox.Show($"{sortedValues[j]} =  {TablaDiscretizada[j, i]}");
                                break;
                            }
                        }
                    }

                }
                else
                {
                    // Aca entra cuando los valores de la columna son discretos (osea que los valores son categorias)
                    for (int j = 0; j <= values.GetUpperBound(0); j++)
                    {
                        //MessageBox.Show(values[j, i]);
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
                TablaTitulos =  new string[Columnas];

                for (int i = 0; i < Columnas; i++)
                {
                    DatosColumna[i] = new InfoColumna();
                    DatosColumna[i].Indice = i;
                    DatosColumna[i].NombreColumna = values[i];
                    TablaTitulos[i] = values[i];
                }
       
                Column = Columnas;
                Rows = Fila;
               

                //MessageBox.Show(Fila + " | " + Columnas + " \n " + TablaValores.GetUpperBound(0) + " | " + TablaValores.GetUpperBound(1));
                Reader.Close();
            }
            catch (Exception e)
            {
               
                throw e;
            }
            
        }


        public void LeerArchivo(string DirArchivo)
        {
            //Se dimensiona el array para guardar los datos
            DeterminarDimensiones(DirArchivo);
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
            for (int i = 0; i <= TablaValores.GetUpperBound(1); i++)
            {
                DatosColumna[i].Correr(TablaValores, i);
            }

            reader.Close();
        }
        //Genera una matriz de confususion a partir de la tabla Discreta y la tabla real
        public double[,] GenerarMatrizConfusion(string[,] TablaDiscreta, string[,] TablaReal,int ColumnaClase, Dictionary<string, double> clases)
        {
            double[,] MatrizDeConfucion = new double[clases.Count, clases.Count];
            for (int i = 0; i < TablaDiscreta.GetLength(0); i++)
            {

                if (TablaDiscreta[i, ColumnaClase].Equals(TablaReal[i, ColumnaClase]) || TablaDiscreta[i, ColumnaClase] != TablaReal[i, ColumnaClase])
                {
                    int indice1 = clases.Keys.ToList().IndexOf(TablaDiscreta[i, ColumnaClase]);
                    int indice2 = clases.Keys.ToList().IndexOf(TablaReal[i, ColumnaClase]);

                    MatrizDeConfucion[indice1, indice2] += 1;

                }
            }
            return MatrizDeConfucion;
        }

        public void FuncionDensidad(string [,] values, int clase)
        {
            double[] columna = new double[values.GetUpperBound(0) + 1];
            double[,] calculos = new double[2, values.GetUpperBound(1) + 1];   //Aquí se guardara la media y la desviacion estandar de cada columna
              
            // Obtiene Medias y Desv.Est. de cada columna (sin considerar las clases)
            for (int i = 0; i <= values.GetUpperBound(1); i++)
            {
                if (i != clase - 1)         //Se salta la columna de clase
                {
                    //Carga la columna en un array unidimensional
                    for (int j = 0; j <= values.GetUpperBound(0); j++)
                    {                             
                            //MessageBox.Show(values[j, i]);
                            columna[j] = Convert.ToDouble(values[j, i]);
                    }

                    calculos[0, i] = GetMedia(columna); ;                                   // Media de cada columna
                    calculos[1, i] = GetDesviacionEstandar(GetVarianza(columna)); ;         // Desviacion estandar de cada columna

                    //MessageBox.Show($"Media:{calculos[0, i]} Desv.Estandar:{calculos[1, i]}");
                }
            }

            // Obtiene Medias y Desv.Est. de cada columna (considerando las clases)
            // EJ. Existen las clases "Hombre/Mujer", de la columna se calculan los que
            // pertenecen a Hombre y despues los que pertenecen a mujer
            for (int i = 0; i <= values.GetUpperBound(1); i++)
            {
                if (i != clase - 1)         //Se salta la columna de clase
                {
                    foreach (var x in DatosColumna[clase - 1].Categoria)    // Por cada clase en la columna de clases
                    {
                        //double[,] calculosXclase = new double[2, ];    //
                        //Carga la columna en un array unidimensional
                        for (int j = 0; j <= values.GetUpperBound(0); j++)
                        {
                            if (values[j, 0] == x.Nombre)
                            {
                                //MessageBox.Show(values[j, i]);
                                columna[j] = Convert.ToDouble(values[j, i]);
                            }
                        }
                    }
                }
            }
        }

        public double GetVarianza(double[] values)                  //(x-media) al cuadrado
        {
            double avg = GetMedia(values);
            double variance = 0.0;

            for (int i = 0; i < values.Length; i++)
            {
                // Math.Pow => Devuelve un número especificado elevado a la potencia especificada.
                variance += Math.Pow(values[i] - avg, 2.0);
            }
            variance = variance / values.Length;
            //MessageBox.Show($"Varianza: {variance.ToString()}");
            return variance;
        }
        public double GetSuma(double[] values)     //Suma los valores de la columna
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
                //MessageBox.Show($"valor: {values[i].ToString()}");
            }
            //MessageBox.Show($"Suma: {sum.ToString()}");
            return sum;
        }

        public double GetMedia(double[] values) //Promedio
        {
            double sum = GetSuma(values);
            double avg = sum / values.Length;
            return avg;
        }

        public double GetDesviacionEstandar(double variance)        //Raiz cuadrada de la varianza  (DESVEST.P para poblacion)
        {
            return Math.Sqrt(variance);
        }
    }
}
