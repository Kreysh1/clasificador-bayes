using System;
using System.Collections.Generic;
using System.IO;

namespace Clasificador_Bayes_Ingenuo
{
    class Leer_Archivos
    {
      public string[,] TablaValores;

        private void DeterminarDimensiones(string DirArchivo)
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
      

            //Se crea la tabla
            TablaValores = new string[Fila, Columnas];

            System.Windows.Forms.MessageBox.Show(Fila + " | " + Columnas + " \n " + TablaValores.GetUpperBound(0) + " | " + TablaValores.GetUpperBound(1));
            Reader.Close();
        }
        public void LeerArchivo(string DirArchivo)
        {
            //Se dimensiona el array para guardar los datos
            DeterminarDimensiones(DirArchivo);

            StreamReader reader = new StreamReader(File.OpenRead(DirArchivo));
           
     
            int FilaActual = 0;
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
