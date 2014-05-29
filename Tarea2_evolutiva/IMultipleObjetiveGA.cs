using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{
    interface IMultipleObjetiveGA
    {
        Population NextPopulation();

        /// <summary>
        /// Obtiene el conjunto considerado de elite de los frentes de no-dominación. 
        /// Esto lo hace con los <b>Config.alpha</b> "mejores" frentes.
        /// </summary>
        /// <returns>Mejores <b>Config.alpha</b> frentes</returns>
        List<Tour> Elite();
    }
}
