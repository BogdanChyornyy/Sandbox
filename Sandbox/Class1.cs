using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    internal class Class1
    {
        public static int tryCounter;

        public static void CreateArrayFirst(int firstItem, int secondItem)
        {
            if (tryCounter == 0)
            {
                tryCounter++;
                Console.WriteLine("Case " + tryCounter);
                for (int i = firstItem; i < 8; i++)
                {
                    if (i > EigthQueens.queenCounter)
                    {
                        CreateArrayCorrect();
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        Sandbox.EigthQueens.CreateArray(i, j);
                    }
                }

                if (EigthQueens.queenCounter != 8)
                {
                    CreateArrayCorrect();
                }
            }

            else
            {
                tryCounter++;
                Console.WriteLine("Case " + tryCounter);
                for (int i = firstItem; i < 8; i++)
                {
                    if (i > EigthQueens.queenCounter)
                    {
                        CreateArrayCorrect();
                    }

                    for (int j = secondItem + 1; j < 8; j++)
                    {
                        //if (j == secondItem)
                        //{
                        //    secondItem = 9;
                        //    continue;
                        //}

                        Sandbox.EigthQueens.CreateArray(i, j);
                    }

                    secondItem = -1;
                }

                if (EigthQueens.queenCounter != 8)
                {
                    CreateArrayCorrect();
                }
            }
        }
        public static void CreateArrayCorrect()
        {
            tryCounter++;
            Console.WriteLine("Case " + tryCounter);
            Array.Clear(EigthQueens.array);
            EigthQueens.saveCounter = EigthQueens.queenCounter - 1;
            EigthQueens.queenCounter = 0;
            int conductor = 0;

            if (EigthQueens.yChord[EigthQueens.saveCounter] == 7)
            {
                conductor = 7;
            }

            for (int i = 0; i < EigthQueens.saveCounter; i++)
            {
                Sandbox.EigthQueens.CreateArray(EigthQueens.xChord[i], EigthQueens.yChord[i]);
            }
            
            CreateArrayFirst(EigthQueens.xChord[EigthQueens.saveCounter], EigthQueens.yChord[EigthQueens.saveCounter]);
        }
    }
}
