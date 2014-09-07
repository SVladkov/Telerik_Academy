using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysStore.SampleDataGenerator
{
    internal class RandomDataGenerator : IRandomDataGenerator
    {
        private static IRandomDataGenerator randomDataGenerator;

        private Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance
        {
            get
            {
                if (randomDataGenerator == null)
                {
                    randomDataGenerator = new RandomDataGenerator();
                }

                return randomDataGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            throw new NotImplementedException();
        }

        public string GetRandomString(int length)
        {
            throw new NotImplementedException();
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            throw new NotImplementedException();
        }
    }
}
