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

        private List<Tour> tours;
        
        /// <summary>
        /// Constructor para la población inicial
        /// </summary>
        public Population()
        {
            tours = new List<Tour>(Config.poblacion);

            for (int i = 0; i < Config.poblacion; i++)
                tours.Add(new Tour());

        }



    }
}
