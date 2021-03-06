﻿using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Randomized.Distribution
{
    public class DefaultRandomGenerator : IRandomGenerator
    {
        private Random r;
        public DefaultRandomGenerator()
        {
            this.r = new Random();
        }

        public int Next()
        {
            return r.Next();
        }
        public int Next(int maxValue)
        {
            return this.r.Next(maxValue);
        }
    }
}
