﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2_evolutiva
{
    class RandomUtils
    {

        private static Random random = new Random();

        public static int RandomInt(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }


    }
}