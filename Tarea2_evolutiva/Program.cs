using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = Data.GetInstance();

            if(args.Length > 0)
                Config.ReadConfig(args[0]);
            
            Config.PrintConfig();

            new GeneticAlgorithm().Start();

           

            Console.ReadKey();
        }
    }
}
