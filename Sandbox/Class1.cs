using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    internal class Class1
    {
        public static int tryCounter; // Счетчик вариантов.

        /// <summary>
        /// Метод заполнения координат массива.
        /// </summary>
        /// <param name="firstItem"></param> Координата Х.
        /// <param name="secondItem"></param> Координата Y.
        public static void CreateArrayFirst(int firstItem, int secondItem)
        {
            if (tryCounter == 0) // Заполнение первичной координаты при входе.
            {
                EigthQueens.queenCounter = firstItem; // Установка счетчика вертикали в соответствии с входной координатой.
                tryCounter++; // Счетчик вариантов.                
                for (int i = firstItem; i < 8; i++) // Установка подходящих координат.
                {
                    if (i > EigthQueens.queenCounter) // Проверка: не превысила ли координата счетчик вертикали.
                    {
                        CreateArrayCorrect();
                    }

                    for (int j = secondItem; j < 8; j++) // Заполнение горизонтали.
                    {
                        Sandbox.EigthQueens.CreateArray(i, j);
                    }

                    secondItem = 0; // Обнуление счетчика горизонтальной координаты.
                }

                if (EigthQueens.queenCounter != 8) // Проверка на расстановку всех 8 ферзей.
                {
                    CreateArrayCorrect();
                }
            }

            else // Заполнение остальных координат.
            {
                EigthQueens.queenCounter = firstItem; // Установка счетчика вертикали в соответствии с входной координатой.
                for (int i = firstItem; i < 8; i++)
                {
                    if (i > EigthQueens.queenCounter)
                    {
                        CreateArrayCorrect();
                    }

                    for (int j = secondItem + 1; j < 8; j++)
                    {
                        Sandbox.EigthQueens.CreateArray(i, j);
                    }

                    secondItem = -1;
                }

                if (EigthQueens.queenCounter != 8)
                {
                    CreateArrayCorrect();
                }

                Console.WriteLine("Case " + tryCounter); // Вывод номеров вариантов расстановок.
                tryCounter++;
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("[" + EigthQueens.xChord[i] + "," + EigthQueens.yChord[i] + "] ");
                }
                Console.WriteLine();
                if (tryCounter == 93) // Условие остановки программы.
                {
                    Console.WriteLine("Congratuations, you've already found 92 available variants");
                    System.Environment.Exit(0);
                }
                CreateArrayCorrect(); // Дальнейшая проверка.
            }
        }
        /// <summary>
        /// Метод корректировки координат.
        /// </summary>
        public static void CreateArrayCorrect()
        {            
            Array.Clear(EigthQueens.array); // Обнуляем массив.
            EigthQueens.saveCounter = EigthQueens.queenCounter - 1; // Инициализируем корректную вертикаль.
            EigthQueens.queenCounter = 0; // Обнуляем счетчик с не правильной вертикалью.
            

            for (int i = 0; i < EigthQueens.saveCounter; i++) // Вводим в обнуленный массив корректные координаты.
            {
                Sandbox.EigthQueens.CreateArray(EigthQueens.xChord[i], EigthQueens.yChord[i]);
            }
            
            CreateArrayFirst(EigthQueens.xChord[EigthQueens.saveCounter], EigthQueens.yChord[EigthQueens.saveCounter]); // Запускаем метод заполнения массива с увеличением некорректной координаты.
        }
    }
}
