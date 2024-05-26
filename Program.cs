using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

namespace Szobeli_Gyak
{
    internal class Program
    {
        static void Main()
        {
            _5();
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
    }
}
