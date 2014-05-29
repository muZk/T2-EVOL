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


        public void Repeat()
        {
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("### Generación {0}", populations.Count);
                Evaluate();
                Selection();
                Mutation();
            } while (populations.Count <= Config.generaciones);
        }

        private void Mutation()
        {
            currentPopulation.Mutate();
        }

        private void Selection()
        {
            throw new NotImplementedException();
        }

        private void Evaluate()
        {
            currentPopulation.Evaluate();
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
            throw new NotImplementedException();
        }

        private void CreateInitialPopulation()
        {
            currentPopulation = new Population();
            populations.Add(currentPopulation);
        }

    }
}
