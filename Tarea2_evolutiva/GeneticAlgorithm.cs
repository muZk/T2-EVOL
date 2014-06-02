using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{

    /// <summary>
    /// Esta clase se encarga de correr el algoritmo genérico.
    /// </summary>

    class GeneticAlgorithm
    {

        private List<Population> populations = new List<Population>();
        private Population currentPopulation;
        
        private void Repeat()
        {
            do
            {
                Evaluate();
                Selection();
                Mutation();
                PrintProgress();
            } while (populations.Count <= Config.generaciones);
        }

        private void Selection()
        {
            IMultipleObjetiveGA ga = new NSGA(currentPopulation);
            Population nextPopulation = ga.NextPopulation();

            currentPopulation.elite = ga.Elite();
            //currentPopulation.Print();
            

            currentPopulation = nextPopulation;
            populations.Add(currentPopulation);
        }

        private void Evaluate()
        {
            currentPopulation.Evaluate();
        }

        private void Mutation()
        {
            currentPopulation.Mutate();
        }

        /// <summary>
        /// Inicia el algoritmo genérico
        /// </summary>
        public void Start()
        {
            CreateInitialPopulation();
            Repeat();
            PrintSolution();
        }

        private void PrintSolution()
        {
            Console.WriteLine("\nGenerando rutas.out...");
            populations[populations.Count - 2].PrintInFile();
            Console.WriteLine("\nImprimiendo solución en consola...\n");
            populations[populations.Count - 2].Print();
        }

        private void CreateInitialPopulation()
        {
            currentPopulation = new Population();
            populations.Add(currentPopulation);
        }

        private void PrintProgress()
        {
            Console.Clear();
            Config.PrintConfig();
            Console.WriteLine("Progreso: "+100*populations.Count/Config.generaciones + "%");
        }

    }
}
