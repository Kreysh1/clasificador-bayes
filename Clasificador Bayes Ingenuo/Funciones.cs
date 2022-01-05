using System;
using System.Collections.Generic;
using System.IO;

namespace Clasificador_Bayes_Ingenuo
{
    public static class Archivo
    {
      
        //direccion del archivo
        public static string DirActual = "";
        //Indice de la columna clase de la tabla
        public static int ClaseIndex;

        /// arreglo con con los datos recabadadosd e la tabla
        public static string[,] TablaValores;
    

       
        //Dimensiones de la tabla
        public static int Column;
        public static int Rows;
        public class InfoColumna
        {
            public struct DatosCategoria
            {
                public int TotalEncontrado;
                public string Nombre;
            }
            public int Indice = 0;
            public string NombreColumna;
            public bool EsNumero = false;
            public int CantidadCategorias = 0;
            public static List<DatosCategoria> Categoria;
           
            public int TotalDeDatos = 0;
            private bool Buscar()
            {
                return false
            }
            void Correr(string[,] tabla, int Indice)
            {
                //Si es un numero
                EsNumero = double.TryParse(tabla[1, Indice], out _);
                if (EsNumero)
                {

                }else{
                    DatosCategoria AuxiliarCategoria= new DatosCategoria();
                    List<DatosCategoria>
                    for (int i=0; i <= tabla.GetUpperBound(0);i++)
                    {
                        Categoria.
                        bool aux = Categoria.FindAll(x => x.Nombre == AuxiliarCategoria.Nombre);
                        if ()
                        {

                        }
                        System.Windows.Forms.MessageBox.Show("Se encontro: " +);
                    }
                   
                }
                CantidadCategorias = Categoria.Count;
            }
        }

        //Guarda el nombre de la columna bajo el mismo indice de la tabla
        public static InfoColumna[] DatosColumna;


        private static void DeterminarDimensiones(string DirArchivo)
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


                //Se crea la tabla y se ommite la primera fila para el tamano de la tabla de datos
                TablaValores = new string[Fila-1, Columnas];
                DatosColumna = new InfoColumna[Columnas];

                for (int i = 0; i < Columnas; i++)
                {
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
               
                throw;
            }
            
        }
        public static void LeerArchivo(string DirArchivo, int Clase)
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


            reader.Close();
        }

    }
}
