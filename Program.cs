using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

namespace Szobeli_Gyak
{
    internal class Program
    {
        static void Main()
        {
            _10();
        }

        private static void _1()
        {
            char[] low = { 'a', 'o', 'u' };
            char[] high = { 'e', 'i' };

            Console.Write("Kérem a szót => ");

            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("\nÍrjál be vmit => ");

                input = Console.ReadLine();
            }

            bool hasLow = false;
            bool hasHigh = false;

            string sound = string.Empty;

            foreach (char c in input)
            {
                if (low.Contains(c)) hasLow = true;
                if (high.Contains(c)) hasHigh = true;
            }

            if (hasLow) sound = "mély";
            if (hasHigh) sound = "magas";

            if (hasLow && hasHigh) sound = "vegyes";

            Console.WriteLine("A szó hangrendje: " + sound);
        }

        private static void _2()
        {
            int[] J = { 2, 3, 2, 4, 4, 4, 3, 1, 5, 4, 2, 1, 5, 4 };

            int[] counts = { 0, 0, 0, 0, 0 };

            for (int i = 0; i < J.Length; i++)
            {
                int current = J[i];

                counts[current - 1]++;
            }

            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + counts[i]);
            }
        }

        private static void _3()
        {
            double[] T = { 10.56, 9.48, 12.01, 11.34, 11.56, 11.33, 10.41, 12.04, 11.01 };

            int[] winningIndices = { 0, 0, 0 };

            double min = 99;
            int minIndex = 0;

            // 1. megoldás
            for (int k = 0; k < winningIndices.Length; k++)
            {
                for (int i = 0; i < T.Length; i++)
                {
                    double current = T[i];

                    if (current < min)
                    {
                        min = current;

                        minIndex = i;
                    }
                }
                winningIndices[k] = (minIndex + 1);
                T[minIndex] = 99;
                min = 99;
            }

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine((i + 1) + ". helyezett: " + winningIndices[i] + ". sorszámú diák.");
            }
        }

        private static void _4()
        {
            string[] TT = { "almafa", "bodzavirág", "szőlőcukor", "paradicsombokor", "almapaprika" };

            List<string> firstStudent = new List<string>();
            List<string> secondStudent = new List<string>();

            Console.Write("Megállapodás a kiemelésre (karakter sorszáma, mennyit) => ");

            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("\nÍrjál be vmit => ");

                input = Console.ReadLine();
            }

            string[] split = input.Split(',');

            int startIndex = Convert.ToInt32(split[0].Trim());
            int nChars = Convert.ToInt32(split[1].Trim());

            for(int i = 0; i < TT.Length; i++)
            {
                string current = TT[i];
                string highlighted = current.Substring(startIndex - 1, nChars);

                if (i % 2 == 0) firstStudent.Add(highlighted);
                else { secondStudent.Add(highlighted); }
            }

            Console.WriteLine("Első tanuló: ");

            foreach (string s in firstStudent)
            {
                Console.Write(s + ", ");
            }

            Console.WriteLine("\nMásodik tanuló: ");

            foreach (string s in secondStudent)
            {
                Console.Write(s + ", ");
            }
        }

        private static void _5()
        {
            int n = 16;

            Random rand = new Random();

            int[] D = new int[n];

            int[] countOfValues = { 0, 0, 0, 0, 0, 0 };

            // tudom hogy meg vannak adva de így gyorsabb volt xd
            for(int i = 0; i < n; i++)
            {
                D[i] = rand.Next(1, 7);
            }

            foreach(int i in D)
            {
                Console.Write(i + " ");

                countOfValues[i - 1]++;
            }

            bool isOnlyOne = false;

            for(int i = 0; i < countOfValues.Length; i++)
            {
                if (countOfValues[i] == 1)
                {
                    Console.WriteLine("\nA(z) " + (i + 1) + " dobásból csak 1 volt.");
                    isOnlyOne = true;
                }
            }

            if(!isOnlyOne) Console.WriteLine("\nNem volt ilyen dobás.");
        }

        private static void _6()
        {
            int area = 0;

            int db = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i < db; i++)
            {
                int side = Convert.ToInt32(Console.ReadLine());
                area += (side * side);
            }

            Console.WriteLine(area);
        }

        private static void _7()
        {
            int[] bills = { 5, 10, 20, 50, 100 };

            int input = Convert.ToInt32(Console.ReadLine());

            int[] output = { 0, 0, 0, 0, 0 };

            for (int i = bills.Length - 1; i >= 0; i--)
            {
                int currentBill = bills[i];

                int divide = input / currentBill;

                if (divide == 0) continue;

                input -= divide * currentBill;
                output[i] += divide;

                if (input == 0) break;
            }

            for (int i = 0; i < output.Length; i++)
            {
                Console.Write(bills[i] + ": " + output[i] + "\n");
            }
        }

        private static void _8()
        {
            Random rand = new Random();

            int[] numbers = new int[30];
            int[] fiveRandoms = new int[5];

            int[] hits = { 0, 0, 0, 0, 0, 0 };

            Console.WriteLine("Amiket feladtak: ");

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1, 91);
                if(i % 5 == 0) Console.WriteLine();
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine("\n\nTényleges lottószámok: ");

            for (int i = 0; i < fiveRandoms.Length; i++)
            {
                fiveRandoms[i] = rand.Next(1, 91);
                Console.Write(fiveRandoms[i] + " ");
            }

            List<int[]> split = numbers.Chunk(5).ToList();

            for(int k = 0; k < split.Count; k++)
            {
                int[] arr = split[k];

                for(int i = 0; i < arr.Length; i++)
                {
                    int current = arr[i];

                    if(fiveRandoms.Contains(current)) hits[k]++;
                }
            }

            Console.WriteLine("\n\nA találatok: ");

            foreach (int n in hits)
            {
                Console.Write(n + ", ");
            }
        }

        private static void _9()
        {
            Random rand = new Random();

            int[] S = new int[50];

            int F = 10;

            Console.WriteLine("Pontszámok: ");

            for (int i = 0; i < S.Length; i++)
            {
                S[i] = rand.Next(1, 101);
                if(i % 10 == 0) Console.WriteLine();
                Console.Write(S[i] + " ");
            }

            // buborékrendezés csökkenőbe
            for(int i = S.Length - 2; i >= 0; i--)
            {
                for(int k = S.Length - 1; k >= 1; k--)
                {
                    int current = S[k];
                    int next = S[i];

                    if(current > next)
                    {
                        S[k] = next;
                        S[i] = current;
                    }
                }
            }

            Console.WriteLine("\n\nFelvettük: ");

            for (int i = 0; i < F; i++)
            {
                Console.Write(S[i] + " ");
            }
        }

        private static void _10()
        {
            int n = 17;
            int total = 0;

            Random rand = new Random();

            for(int i = 0; i < n; i++)
            {
                int current = rand.Next(50, 151);
                Console.WriteLine((i + 1) + ". palánta: " + current + "dkg-ot termett.");

                total += current;
            }

            Console.WriteLine("Összesen: " + total + "dkg vagy " + ((double)total / (double)100) + "kg.");
        }
    }
}
