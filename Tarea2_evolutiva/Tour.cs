using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{
    /// <summary>
    /// Esta clase representa una solución en particular. Las ciudades se representarán 
    /// con números del 1 al 20
    /// </summary>

    class Tour
    {
        private List<int> tour = new List<int>(20);

        public Tour()
        {
            List<int> cities = GetCityList();
            
            for (int i = 0; i < 20; i++)
            {
                int randomCityIndex = RandomUtils.RandomInt(0, cities.Count);
                tour.Add(cities[randomCityIndex]);
                cities.RemoveAt(randomCityIndex);
            }

        }

        public int this[int key]
        {
            get
            {
                return tour[key];
            }
            set
            {
                tour[key] = value;
            }
        }

        public override string ToString()
        {
            return string.Join(" ", tour);
        }

        public int Count
        {
            get
            {
                return tour.Count;
            }
        }

        public int IndexOf(int city)
        {
            return tour.IndexOf(city);
        }

        public static CrossoverResult Crossover(Tour t1, Tour t2)
        {
            int randomCity = RandomUtils.RandomCity();
            CrossoverResult crossover = new CrossoverResult();
            crossover.offspring1 = Pmx(t1, t2, randomCity);
            crossover.offspring2 = Pmx(t2, t1, randomCity);

            Console.WriteLine("RandomCity: "+randomCity);

            return crossover;
        }

        private static Tour Pmx(Tour t1, Tour t2, int city)
        {
            int index = t1.IndexOf(city);
            Tour offspring = new Tour();
            List<int> remainingCities = GetCityList();

            // Copio en offspring la parte mantenida de t1
            // mientras voy guardando las ciudades que me quedan
            // por rellenar

            for (int i = 0; i <= index; i++)
            {
                offspring[i] = t1[i];
                remainingCities.Remove(t1[i]);
            }

            // Coloco en offspring las ciudades que me quedan por rellenar
            // según el orden de aparición en t2

            for (int i = 0; i < t2.Count; i++)
            {
                if (remainingCities.Count == 0)
                    break;

                int rIndex = remainingCities.IndexOf(t2[i]);

                if (rIndex == -1)
                    continue;

                index++;
                offspring[index] = t2[i];
                remainingCities.RemoveAt(rIndex);
            }

            return offspring;
        }

        private static List<int> GetCityList()
        {
            List<int> cities = new List<int>(20);
            for (int city = 1; city <= 20; city++)
                cities.Add(city);
            return cities;
        }

    }
}