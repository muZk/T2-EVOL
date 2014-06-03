# Tarea 2 - Nicolás Gómez

Asumo lo que el profesor dijo en clases, que el desafío no es "leer" un excel, si no que solucionar el problema en sí. Por esta razón, hay una clase que se llama "Data", la cuál tiene hardcodeado los datos.

1. Tipo de representación: de camino. Cada individuo es un arreglo P de largo 20, el cual directamente dice la lista de ciudades por las que se deben pasar, en orden.

2. Como operador de crossover, se usa PMX (recombinación parcialmente mapeada)

3. Operador de mutación, se usó Intercambio recíprocro: Intercambia 2 ciudades

4. Se utilizó Nondominating Sorting Genetic Algorithm, el cuál esta implementado en la clase NSGA. A grandes rasgos duplica la población utilizando crossover (según la probabilidad de configuración) y con mutación. En base a la nueva población duplicada, crea un ranking de no-dominación y elige a los mejores X (población especificada en configuración) a partir de los distintos frentes de no dominación, partiendo desde la frontera 0. La elección de individuos de los frentes es FIFO, no hay discriminación. Estos X individuos pasan a ser la nueva generación. Además armar este ranking nos sirve para tomar a la elite, que toma desde el frente 0 hasta el ALPHA - 1 como elite.

5. El archivo opt.parametros.txt debe ir dentro de la carpeta bin/Debug (si se corre la aplicación con debug) o en bin/Release en caso de que se corra en modo release.

6. No hay validación de los parámetros especificados en opt.parametros.txt, ya que no está en la pauta de evaluación ni es requerimiento de enunciado.