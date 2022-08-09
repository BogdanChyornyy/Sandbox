using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    class EigthQueens
    {
        public static int queenCounter;
        public static int saveCounter;
        public static int fillingChordX;
        public static int fillingChordY;
        public static int checkChordX;
        public static int checkChordY;
        public static int[,] array = new int[8, 8];
        public static int[] xChord = new int[8];
        public static int[] yChord = new int[8];

        public static void CreateArray(int firstItem, int secondItem)
        {
            checkChordX = firstItem;

            checkChordY = secondItem;

            if (array[checkChordX,checkChordY] == 0)
            {
                array[checkChordX, checkChordY] = 1; // Установка ферзя (1).

                if (array[checkChordX, fillingChordY] == 1) // Проверка крайнего значения.
                {
                    fillingChordY++;
                }
                
                while (fillingChordY < 8 && fillingChordY >= 0) // Заполнение оси Х (9).
                {
                    array[checkChordX, fillingChordY] = 9;
                    fillingChordY++;

                    if (fillingChordY > 7)
                    {
                        fillingChordY = 0; // Обнуление оси после заполнения.
                        break;
                    }

                    if (array[checkChordX,fillingChordY] == 1)
                    {
                        fillingChordY++;

                        if (fillingChordY > 7)
                        {
                            fillingChordY = 0; // Обнуление оси после заполнения.
                            break;
                        }
                    }                    
                }

                if (array[fillingChordX, checkChordY] == 1)  // Проверка крайнего значения.
                {
                    fillingChordX++;
                }

                while (fillingChordX < 8 && fillingChordX >= 0) // Заполнение оси Y (9).
                {
                    array[fillingChordX, checkChordY] = 9;                    
                    fillingChordX++;

                    if (fillingChordX > 7)
                    {
                        fillingChordX = 0; // Обнуление оси после заполнения.
                        break;
                    }

                    if (array[fillingChordX, checkChordY] == 1)
                    {
                        fillingChordX++;

                        if (fillingChordX > 7)
                        {
                            fillingChordX = 0; // Обнуление оси после заполнения.
                            break;
                        }
                    }
                }

                if (array[fillingChordX, checkChordY] == 1 || array[checkChordX, fillingChordY] == 1) // Проверка крайнего значения.
                {
                    fillingChordX = checkChordX + 1;
                    fillingChordY = checkChordY + 1;

                    while (fillingChordX < 8 && fillingChordY < 8) // Заполнение диагонали вправо (9) при крайнем положении ферзя.
                    {
                        array[fillingChordX, fillingChordY] = 9;
                        fillingChordX++;
                        fillingChordY++;

                        if (fillingChordX > 7 || fillingChordY > 7)
                        {
                            break;
                        }
                    }

                    if (checkChordX == 0)
                    {
                        fillingChordX = checkChordX + 1;
                        fillingChordY = checkChordY - 1;

                        while (fillingChordY > 0) // Заполнение диагонали влево (9) при крайнем положении ферзя.
                        {
                            array[fillingChordX, fillingChordY] = 9;
                            fillingChordX++;
                            fillingChordY--;

                            if (fillingChordY == 0)
                            {
                                array[fillingChordX, fillingChordY] = 9;
                                fillingChordX = 0;
                                fillingChordY = 0;
                                break;
                            }
                        }
                    }

                    if (checkChordY == 0)
                    {
                        fillingChordY = checkChordY + 1;
                        fillingChordX = checkChordX - 1;

                        while (fillingChordX > 0) // Заполнение диагонали вверх (9) при крайнем положении ферзя.
                        {
                            array[fillingChordX, fillingChordY] = 9;
                            fillingChordX--;
                            fillingChordY++;

                            if (fillingChordX == 0)
                            {
                                array[fillingChordX, fillingChordY] = 9;
                                fillingChordX = 0;
                                fillingChordY = 0;
                                break;
                            }
                        }
                    }
                }
                
                if (checkChordX > 0 && checkChordY > 0) // Не крайнее положение.
                {
                    fillingChordX = checkChordX;
                    fillingChordY = checkChordY;

                    while (fillingChordX > 0 && fillingChordY > 0)
                    {
                        fillingChordX--;
                        fillingChordY--;
                    }

                    array[fillingChordX, fillingChordY] = 9;

                    while (fillingChordX < 8 && fillingChordY < 8) // Заполнение диагонали (9) при крайнем положении ферзя.
                    {
                        fillingChordX++;
                        fillingChordY++;

                        if (fillingChordX > 7 || fillingChordY > 7)
                        {
                            fillingChordX = 0;
                            fillingChordY = 0;
                            break;
                        }

                        if (array[fillingChordX, fillingChordY] == 1)
                        {
                            fillingChordX++;
                            fillingChordY++;

                            if (fillingChordX > 7 || fillingChordY > 7)
                            {
                                fillingChordX = 0;
                                fillingChordY = 0;
                                break;
                            }
                        }

                        array[fillingChordX, fillingChordY] = 9;
                    }

                    ///
                    fillingChordX = checkChordX;
                    fillingChordY = checkChordY;

                    while (fillingChordY > 0 && fillingChordX != 7)
                    {
                        fillingChordX++;
                        fillingChordY--;
                    }

                    array[fillingChordX, fillingChordY] = 9;

                    while (fillingChordX < 8 && fillingChordY < 8) // Заполнение диагонали (9) при крайнем положении ферзя.
                    {
                        fillingChordX--;
                        fillingChordY++;

                        if (fillingChordX < 0 || fillingChordY > 7)
                        {
                            fillingChordX = 0;
                            fillingChordY = 0;
                            break;
                        }

                        if (array[fillingChordX, fillingChordY] == 1)
                        {
                            fillingChordX++;
                            fillingChordY++;

                            if (fillingChordX < 0 || fillingChordY > 7)
                            {
                                fillingChordX = 0;
                                fillingChordY = 0;
                                break;
                            }
                        }
                        array[fillingChordX, fillingChordY] = 9;
                    }
                }
                fillingChordX = fillingChordY = 0;
                
                saveArrayData(checkChordX, checkChordY, queenCounter);
                queenCounter++;

                Console.WriteLine("[" + checkChordX + "," + checkChordY + "]");
            }
        }
        public static void saveArrayData(int x, int y, int arrayCount)
        {
            xChord[arrayCount] = x;
            yChord[arrayCount] = y;
            //Console.WriteLine("[" + xChord + "," + yChord + "]");
        }
    }
}
