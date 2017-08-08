using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Randomized.Distribution
{
    public class CryptoSafeRandomGenerator : IRandomGenerator
    {
        private RNGCryptoServiceProvider rng;
        private byte[] buffer;
        private DefaultRandomGenerator randomHelper;

        public CryptoSafeRandomGenerator()
        {
            this.rng = new RNGCryptoServiceProvider();
            this.buffer = new byte[4];
            this.randomHelper = new DefaultRandomGenerator();
        }
        public int Next()
        {
            this.rng.GetBytes(this.buffer);
            return BitConverter.ToInt32(this.buffer, 0);
        }
        
        public int Next(int maxValue)
        {
            // The below is a trick to make sure the random value are picked uniformly from range [0, maxValue)
            return (int)(((long)this.randomHelper.Next(maxValue) + (long)this.Next()) % maxValue);
        }
    }
}
