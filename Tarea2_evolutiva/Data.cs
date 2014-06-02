using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{

    /// <summary>
    /// Singleton que maneja los datos de dificultad y distancia entre las ciudades
    /// </summary>

    class Data
    {

        private const string _difficultyString = 
            "0	5	0	10	0	5	0	10	0	10	5	0	0	10	0	5	0	10	0	5\n" +
            "	0	0	0	5	0	10	0	0	5	0	10	0	0	5	0	10	0	5	5\n" +
            "		0	0	10	0	5	0	0	10	0	5	0	0	10	0	5	0	0	10\n" +
            "			0	0	0	0	5	5	5	0	0	0	10	5	10	0	0	5	0\n" +
            "				0	5	10	5	5	0	0	0	0	5	5	5	10	5	0	0\n" +
            "					0	0	0	10	0	10	5	10	0	0	0	0	5	10	0\n" +
            "						0	0	10	5	5	0	5	5	10	5	0	10	0	10\n" +
            "							0	0	0	10	0	5	0	0	0	5	0	10	5\n" +
            "								0	0	5	10	10	0	0	10	5	0	5	0\n" +
            "									0	5	5	5	5	0	0	0	0	0	0\n" +
            "										0	0	5	0	0	0	10	5	0	5\n" +
            "											0	10	5	0	5	5	5	10	0\n" +
            "												0	0	0	5	10	5	0	0\n" +
            "													0	10	5	0	0	5	10\n" +
            "														0	0	5	5	5	0\n" +
            "															0	0	10	5	0\n" +
            "																0	0	5	0\n" +
            "																	0	5	5\n" +
            "																		0	10\n" +
            "																			0";

        private const string _distanceString =
            "0	20	40	60	80	100	120	140	160	180	165	150	135	120	105	90	75	60	45	30\n" +
            "	0	18	36	54	72	90	108	126	98	116	88	106	78	96	114	132	104	122	140\n" +
            "		0	140	119	98	77	56	35	14	53	32	71	50	89	68	107	86	125	104\n" +
            "			0	34	43	52	61	70	79	88	97	106	99	92	85	78	71	64	57\n" +
            "				0	13	26	39	52	65	78	91	53	49	45	41	55	51	47	43\n" +
            "					0	11	22	21	32	18	29	40	66	77	88	32	43	54	65\n" +
            "						0	8	16	24	32	33	41	49	71	93	115	67	89	111\n" +
            "							0	14	11	25	39	34	48	76	90	64	78	52	66\n" +
            "								0	15	30	45	33	48	63	78	93	108	66	43\n" +
            "									0	26	52	78	104	130	90	116	142	87	113\n" +
            "										0	33	54	87	120	44	77	110	88	121\n" +
            "											0	78	156	88	45	123	54	87	90\n" +
            "												0	22	44	66	88	54	76	98\n" +
            "													0	14	28	42	77	91	105\n" +
            "														0	23	46	55	90	113\n" +
            "															0	45	76	109	78\n" +
            "																0	54	78	90\n" +
            "																	0	23	45\n" +
            "																		0	56\n" +
            "																			0";

        public int[,] difficulty;
        public int[,] distance;

        private static Data instance;

        private Data()
        {
            difficulty = GenerateMatrix(_difficultyString);
            distance = GenerateMatrix(_distanceString);
        }

        private static int[,] GenerateMatrix(string d)
        {
            int[,] matrix = new int[20, 20];
            string[] lines = d.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split('\t');

                for (int j = 0; j < numbers.Length; j++)
                    if (numbers[j].Equals(""))
                        matrix[i, j] = matrix[j, i];
                    else
                        matrix[i, j] = int.Parse(numbers[j]);

            }

            return matrix;
        }

        public static Data GetInstance()
        {
            if (instance == null)
                instance = new Data();
            return instance;
        }

        public int GetDistance(int city1, int city2)
        {
            return distance[city1 - 1, city2 - 1];
        }

        public int GetRisk(int city1, int city2)
        {
            return difficulty[city1 - 1, city2 - 1];
        }

    }
}
