using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    class Program
    {
        public int m;
        public int min;
        public static void Main(string[] args)
        {
            int quantity = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            int[] numbers = new int[quantity];
            for (int i = 0; i < quantity; i++)
            {
                numbers[i] = rand.Next(0, quantity);
            }
            Sort(numbers, quantity);
        }

        public static void Sort(int[] numbers, int quantity)
        {
            var range = new SortedDictionary<int, int>();

            for (int i = 0; i < quantity; i++)
            {
                if (range.ContainsKey(numbers[i]))
                {
                    range[numbers[i]]++;
                }
                else
                {
                    range.Add(numbers[i], 1);
                }
            }

            foreach (var key in range.Keys)
            {
                for (int j = 1; j <= range[key]; j++)
                {
                    Console.WriteLine(key);
                }
            }
        }
    }
}
