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
            public bool EsClase = false;
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
        void entrenar(int CantidadGenerar, int ColumnaClase)
        {
            if (TablaDiscreta.Count < 1)
            {
                MessageBox.Show("Tabla sin transformar");
                TransFormarArregloALista(TablaDiscretizada);
            }
            for (int i = 0; i < TablaDiscretizada.GetLength(0); i++)
            {
             
                //Se vuelve a obtener los datos del a tabla ya discretizada
                //esto para hacer bien el vayes
                DatosColumna[i].Correr(TablaDiscretizada, i);

            }
            
            List<string[]> generados = new List<string[]>();
            //Empieza a generar datos
           
            for(int i =0 ; i <= CantidadGenerar; i++)
            {
                string[] Temp = new string [TablaDiscreta[1].GetLength(0)];
                for(int j=0; j<=TablaDiscreta[i].GetLength(0); j++)
                {
                    if (j != ColumnaClase) { 
                    //Se obtiene el la cantidad de categorias
                    int aux = DatosColumna[j].CantidadCategorias;
                    //Se crea una columna aleatoria con el resultado de una categoria aleatoria por aux(la cantidad de Categorias en la columna)
                    Temp[j] = DatosColumna[j].Categoria[NumeroRandom(aux)].Nombre;
                    }                  
                }
                generados.Add(Temp);
            }

            for(int i=0; i< generados.Count; i++)
            {
                generados[i][ColumnaClase] = SuavisadoLaplacae(generados, ColumnaClase);
            }

        }

        //InfoColumna guarda los datos especificos a una columna
        public string SuavisadoLaplacae(List<string[]> input, int ColumnaClase)
        {
            //en el caso de que este vacia
           

            //Convierte la tabla en una lista de vectores string
            List<string[]> TablaLista = TablaDiscreta;


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
            double[] Clase = new double[DatosColumna[ColumnaClase].CantidadCategorias];
            //Ciclo para obtener el 
            double bayesSuave(string[] Entrada, int IndiceClase) {

                double[] AuxiliarBayes = new double[DatosColumna.GetLength(0)];

                // I controla la Categoria Clase 
                //Nombre de la categoria interesada
                string Categoria = DatosColumna[ColumnaClase].Categoria[IndiceClase].Nombre;

                //Ciclo para sacar el bayes


                for (int i = 0; i <= Entrada.GetUpperBound(0); i++)
                {

                    double Arriba;
                    double Abajo;
                    if (i == ColumnaClase)
                    {
                        Arriba = DatosColumna[i].Categoria[IndiceClase].TotalEncontrado;
                        Abajo = TablaLista.Count;
                        MessageBox.Show(i + "CLASE| " + Arriba + "\n" + Abajo);
                        // P =  Categoria / Total de del atributos
                        AuxiliarBayes[i] = Arriba / Abajo;

                    }
                    else
                    {
                        //MessageBox.Show((ContarIndicidencia(i, Entrada[i], Categoria) + 1)+ "\n" +( DatosColumna[ColumnaClase].Categoria[IndiceClase].TotalEncontrado + DatosColumna[i].CantidadCategorias));

                        Arriba = (ContarIndicidencia(i, Entrada[i], Categoria) + 1);
                        Abajo = (DatosColumna[ColumnaClase].Categoria[IndiceClase].TotalEncontrado + DatosColumna[i].CantidadCategorias);

                        MessageBox.Show(i + "| " + Arriba + "\n" + Abajo);
                        AuxiliarBayes[i] = Arriba / Abajo;


                    }
                    MessageBox.Show("Bayes Aux: " + AuxiliarBayes[i] + "");

                }





                double Resultado = 1;
                //Resultado del calculo
                for (int i = 0; i <= AuxiliarBayes.GetUpperBound(0); i++)
                {
                    Resultado = Resultado * AuxiliarBayes[i];
                }
                MessageBox.Show("Resul " + Resultado);
                return Resultado;
            }


            //Se calcula el valor para cada clase
            for (int i = 0; i < input.Count; i++) {
                for (int j = 0; j <= Clase.GetUpperBound(0); j++)
                {

                    Clase[j] = bayesSuave(input[i], j);

                    MessageBox.Show("Clase: " + Clase[j] + "\n Indice: " + j + " " + DatosColumna[ColumnaClase].Categoria[j].Nombre);
                }
            }

            //Se determina a cual clase pertenece
            double[] MayorDeArreglo(double[] Arreglo)
            {
                //Guarda el indice al que pertenece en el 1 y en el 0, su valor
                double[] Mayor = new double[2];
                Mayor[0] = Arreglo[0];
                Mayor[1] = 0;
                for (int i = 0; i <= Arreglo.GetUpperBound(0); i++)
                {
                    if (Arreglo[i] > Mayor[0])
                    {
                        Mayor[0] = Arreglo[i];
                        Mayor[1] = i;
                    }
                }
                return Mayor;
            }
            double[] Resul = MayorDeArreglo(Clase);
            int indice = ((int)Resul[1]);

            MessageBox.Show("Fue :" + DatosColumna[ColumnaClase].Categoria[indice].Nombre );

            return DatosColumna[ColumnaClase].Categoria[indice].Nombre;
        }

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
                TablaTitulos =  new string[Columnas];

                for (int i = 0; i < Columnas; i++)
                {
                    DatosColumna[i] = new InfoColumna();
                    DatosColumna[i].Indice = i;
                    DatosColumna[i].NombreColumna = values[i];
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
            TablaTitulos = reader.ReadLine().Split(',');//Se salta los nombres de columnas
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


        public void FuncionDensidad(string [,] values, int clase)
        {
            double[] columna = new double[values.GetUpperBound(0) + 1];
            double[] calculos = new double[2];   //Aquí se guardara la media y la desviacion estandar de cada columna

            //Carga la columna en un array unidimensional
            for (int i = 0; i <= values.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= values.GetUpperBound(0); j++)
                {
                    //MessageBox.Show(values[j, i]);
                    columna[i] = Convert.ToDouble(values[j, i]);
                }  
            }
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
