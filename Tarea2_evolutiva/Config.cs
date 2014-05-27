using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{
    public static class Config
    {
        /// <summary>
        /// Número de generaciones máxima
        /// </summary>
        public static int generaciones = 100000;
        /// <summary>
        /// Número de individuos en la población
        /// </summary>
        public static int poblacion = 40;
        /// <summary>
        /// Probabilidad de crossover
        /// </summary>
        public static double crossover = 0.5;
        /// <summary>
        /// Probabilidad de putación
        /// </summary>
        public static double mutacion = 0.1;
        /// <summary>
        /// Alpha
        /// </summary>
        public static double alpha = 2;

        /// <summary>
        /// Le da un valor a cierto parámetro de configuración
        /// </summary>
        /// <param name="key">Nombre configuración</param>
        /// <param name="value">Valor de la configuración</param>
        private static void SetConfig(string key, string value)
        {
            switch (key)
            {
                case "Generaciones":
                    Config.generaciones = int.Parse(value);
                    break;
                case "Poblacion":
                    Config.poblacion = int.Parse(value);
                    break;
                case "Crossover":
                    Config.crossover = double.Parse(value);
                    break;
                case "Mutacion":
                    Config.mutacion = double.Parse(value);
                    break;
                case "Alpha":
                    Config.alpha = int.Parse(value.Replace(".", ""));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Lee un archivo de configuración
        /// </summary>
        /// <param name="path">PATH del archivo de configuración</param>
        public static void ReadConfig(string path)
        {

            if (path.Trim().Equals(""))
                return;

            try
            {

                string[] lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] parameters = line.Split('=');
                    string key = parameters[0].Trim();
                    string value = parameters[1].Trim();
                    SetConfig(key, value);
                }
            }
            catch
            {
                Console.WriteLine("No se ha encontrado el archivo especificado. Pruebe colocando una ruta absoluta.");
                Console.WriteLine("Cargando configuración por defecto...");
            }

        }

        /// <summary>
        /// Imprime en consola los valores de configuración
        /// </summary>
        public static void PrintConfig()
        {
            Console.WriteLine("Generaciones = {0}", generaciones);
            Console.WriteLine("Poblacion = {0}", poblacion);
            Console.WriteLine("Crossover = {0}", crossover);
            Console.WriteLine("Mutacion = {0}", mutacion);
            Console.WriteLine("Alpha = {0}", alpha);
        }

    }
}
