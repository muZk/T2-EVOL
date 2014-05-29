using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{

    /// <summary>
    /// Clase que encarga de realizar las operaciones de Nondominating Sorting Genetic Algorithm
    /// </summary>

    class NSGA : IMultipleObjetiveGA
    {

        private Population toRank;
        private List<Tour> originalTours;
        private Dictionary<int, List<Tour>> ranking = new Dictionary<int, List<Tour>>();

        public NSGA(Population population)
        {
            // Guardar una copia
            toRank = new Population(population);

            // Guardar una copia de tours originales
            originalTours = new List<Tour>();
            foreach (Tour t in toRank.tours)
                originalTours.Add(new Tour(t));
        }

        /// <summary>
        /// Crea una nueva generación a partir de una actual.
        /// </summary>
        /// <returns>Siguiente población</returns>
        public Population NextPopulation()
        {
            DuplicatePopulationSize();
            GenerateNoDominationFronts();
            return Selection();
        }

        /// <summary>
        /// Selecciona la próxima población. Para esto, iteramos sobre los frentes de
        /// dominación desde 0 hasta el máximo de población. Esto es debido a que la cantidad
        /// máxima de frentes de dominación es dicho máximo.
        /// 
        /// Observaciones: Dentro de un mismo frente de no-dominación, la política de elección es FIFO.
        /// 
        /// </summary>
        /// <returns>Próxima generación basada en NSGA.</returns>
        private Population Selection()
        {
            List<Tour> selectedTours = new List<Tour>();
            int dominatedByCounter = 0;

            while (dominatedByCounter < Config.poblacion)
            {
                if (ranking.ContainsKey(dominatedByCounter))
                {
                    List<Tour> front = ranking[dominatedByCounter];

                    foreach (Tour t in front)
                    {
                        selectedTours.Add(t);
                        if (selectedTours.Count == Config.poblacion)
                            break;
                    }

                }

                if (selectedTours.Count == Config.poblacion)
                    break;

                dominatedByCounter++;

            }

            return new Population(selectedTours);
        }

        /// <summary>
        /// Duplica la población actual. Los nuevos individuos serán creados por crossover y mutacion.
        /// Se agregará una cantidad de individuos por crossover proporcional a la probabilidad de crossover.
        /// Se agregarán los que faltan con mutación.
        /// </summary>
        private void DuplicatePopulationSize()
        {
            int newSize = toRank.Count * 2;
            int crossoverCount = (int) (newSize * Config.crossover);

            while (toRank.Count < newSize)
            {
                if (crossoverCount >= 0)
                {
                    CrossoverResult result = Tour.Crossover(RandomTour(), RandomTour());
                    toRank.Add(result.offspring1);
                    toRank.Add(result.offspring2);
                    crossoverCount--;
                }
                else
                {
                    Tour t = new Tour(RandomTour());
                    t.Mutate();
                    toRank.Add(t);
                }
            }

            toRank.Evaluate();

        }

        /// <summary>
        /// Helper para obtener un Tour al azar de la lista original de tours.
        /// </summary>
        /// <returns></returns>
        private Tour RandomTour()
        {
            return originalTours[RandomUtils.RandomInt(0, originalTours.Count)];
        }

        /// <summary>
        /// Rellena el diccionario de forma que se cumpla lo siguiente:
        ///     ranking[number] obtiene la lista de tours que cumplen con que son dominados
        ///     por una cantidad igual a <b>number</b> de tours.
        /// </summary>
        private void GenerateNoDominationFronts()
        {
            for (int i = 0; i < toRank.Count; i++)
            {
                Tour currentTour = toRank.Get(i);
                int dominatedByCounter = 0;

                foreach (Tour t in toRank.tours)
                    // no es necesario currentTour != t, ya que por definicion dominatedBy retorna false
                    if (currentTour.dominatedBy(t))
                        dominatedByCounter++;

                if (!ranking.ContainsKey(dominatedByCounter))
                    ranking[dominatedByCounter] = new List<Tour>();

                ranking[dominatedByCounter].Add(currentTour);

            }
        }

        /// <summary>
        /// Obtiene el conjunto considerado de elite de los frentes de no-dominación. 
        /// Esto lo hace con los <b>Config.alpha</b> "mejores" frentes.
        /// </summary>
        /// <returns>Mejores <b>Config.alpha</b> frentes</returns>
        public List<Tour> Elite()
        {
            List<Tour> elite = new List<Tour>();
            int addedFronts = 0;

            for (int i = 0; i < Config.poblacion; i++)
            {
                if (ranking.ContainsKey(i))
                {
                    // Copiar todos los de este frente de dominación a la elite
                    List<Tour> front = ranking[i];
                    foreach (Tour t in front)
                        elite.Add(new Tour(t));
                    addedFronts++;        
                }
                if (addedFronts == Config.alpha)
                    break;
            }

            return elite;
        }
    }
}
