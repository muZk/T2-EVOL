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
        private int[] tour = new int[20];

        public Tour()
        {
            List<int> cities = new List<int>(20);
            for (int city = 1; city <= 20; city++)
                cities.Add(city);
            
            for (int i = 0; i < 20; i++)
            {
                int randomCityIndex = RandomUtils.RandomInt(0, cities.Count);
                tour[i] = cities[randomCityIndex];
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

        

    }
}