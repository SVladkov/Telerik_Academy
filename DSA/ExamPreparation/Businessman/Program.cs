using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessman
{
    class Program
    {
        static void Main()
        {
            int peopleCount = 0;
            peopleCount = int.Parse(Console.ReadLine());

            long count = CountHandshakes(peopleCount);

            Console.WriteLine(count);
        }

        static long CountHandshakes(int peopleCount)
        {
            long[] countOfHandshakesForCountOfPeople = new long[peopleCount + 1];
            countOfHandshakesForCountOfPeople[0] = 1;

            for (int i = 2; i <= peopleCount; i+=2)
            { 
                long newPeopleCount = i;
                for (long j = 0; j <= newPeopleCount - 2; j+=2) // to 2
                {
                    countOfHandshakesForCountOfPeople[i] +=
                            countOfHandshakesForCountOfPeople[j] *
                            countOfHandshakesForCountOfPeople[(newPeopleCount - 2) - j];
                }
            }

            return countOfHandshakesForCountOfPeople[peopleCount];
        }
    }
}
