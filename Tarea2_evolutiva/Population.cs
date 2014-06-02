using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{

    /// <summary>
    /// Clase encargada de la poblacion (generación).
    /// </summary>

    class Population
    {

        private List<Tour> _tours;
        private List<Tour> _elite;
        
        /// <summary>
        /// Constructor para la población inicial
        /// </summary>
        public Population()
        {
            _tours = new List<Tour>(Config.poblacion);

            for (int i = 0; i < Config.poblacion; i++)
                _tours.Add(new Tour());

        }

        public Population(Population population)
        { 
            _tours = new List<Tour>(Config.poblacion);

            foreach (Tour t in population.tours)
                _tours.Add(new Tour(t));
        }

        public Population(List<Tour> tours)
        {
            _tours = tours;
        }


        /// <summary>
        /// Evalua a todos los tours de la población
        /// </summary>
        public void Evaluate()
        {
            foreach(Tour tour in _tours)
                tour.Evaluate();
        }

        /// <summary>
        /// Muta a todos los tours de la población, según la probabilidad de mutación
        /// </summary>
        public void Mutate()
        {
            foreach (Tour tour in _tours)
                if(RandomUtils.EvaluateMutationEvent())
                    tour.Mutate();
        }

        public Tour RandomTour()
        { 
            return _tours[RandomUtils.RandomInt(0, 20)];
        }

        public void Add(Tour t)
        {
            _tours.Add(t);
        }

        public Tour Get(int index)
        {
            return _tours[index];
        }

        public int Count { get { return _tours.Count; } }

        public List<Tour> tours { get { return _tours; } }
        public List<Tour> elite { get { return _elite; } set { _elite = value; } }

        public void Print()
        {

            Console.WriteLine("Posibles rutas a seguir (equivalentes):");

            foreach (Tour tour in elite)
            {
                Console.WriteLine(tour.ToString() + " Risk: " + tour.difficultyFitness + " Distance: " + tour.distanceFitness);
            }
        }

        public void PrintInFile()
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("rutas.out"))
            {
                foreach (Tour tour in elite)
                {
                    file.WriteLine(tour.ToString() + " [ Risk = "+ tour.difficultyFitness +" , Distance = "+ tour.distanceFitness +" ] ");
                }

                file.Close();
            }
        }



    }
}
