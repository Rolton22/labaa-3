namespace labaa_3
{
    using System;
    internal class Program
    {

        //заполнение двумерного массива по спирали числами от 1 до 100 
        static void Task928()
        {
            Random r = new Random();
            int size = 10;
            int[,] array = new int[size, size];
            int value = 1;

            for (int side = 0; side < (size + 1) / 2; side++)
            {
                for (int i = side; i < size - side; i++)
                {
                    array[side, i] = value++;
                }

                for (int i = side + 1; i < size - side; i++)
                {
                    array[i, size - 1 - side] = value++;
                }

                for (int i = side + 1; i < size - side; i++)
                {
                    array[size - 1 - side, size - 1 - i] = value++;
                }

                for (int i = side + 1; i < size - 1 - side; i++)
                {
                    array[size - 1 - i, side] = value++;
                }
            }

            Console.WriteLine("Массив заполненный по спирали:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.Write("\n");
            }
        }

        //К элементам k-й строки Двумерного массива прибавить элементы р-й строки.
        static void Task954()
        {
            Console.WriteLine("\n\n");
            Random r = new Random();
            int size = 5;
            string input1, input2;
            int[,] array = new int[size, size];
            Console.WriteLine("Массив:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = r.Next(1, 100);
                    Console.Write($"{array[i, j]}\t");
                }
                Console.Write("\n");
            }
            Console.WriteLine("Введите номер строки:");
            input1 = Console.ReadLine();
            Console.WriteLine("Введите номер строки числа которого прибавяться");
            input2 = Console.ReadLine();
            if (int.TryParse(input1, out int number1) && int.TryParse(input2, out int number2) && number1 >= 0 && number1 < size && number2 >= 0 && number2 < size)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"\n{array[number1, i]} + {array[number2, i]} = ");
                    array[number1, i] += array[number2, i];
                    Console.Write($"{array[number1, i]}");
                }
            }
            else
            {
                Console.WriteLine("Неккоректное значение");
            }
            Console.WriteLine("\nМассив отредактированный:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.Write("\n");
            }
        }

        /*
        Задан массив чисел А[n, m], упорядоченный по возрастанию по строкам и столбцам, то есть:
        А[i, 1] < А[i, 2] < … < А[i, m] (при всех i);
        А[1, j] < А[2, j] < … < А[n, j] (при всех j).
        Найти элемент массива, равный заданному числу Х, и вывести его индексы (i, j). Напечатать слово «НЕТ», если такого элемента не окажется. Х можно сравнить не более чем с m + n элементами массива.

         */
        static void Task935()
        {
            Random r = new Random();
            string input;
            int row = 5, column = 7;
            int[,] array = new int[row, column];
            int[] arraySorted = new int[row * column];
            int k = 0;
            Console.WriteLine("Массив:");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = r.Next(0, 100);
                    Console.Write($"{array[i, j]}\t");
                }
                Console.Write("\n");
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    arraySorted[k] = array[i, j];
                    k++;
                }
            }
            Array.Sort(arraySorted);
            k = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = arraySorted[k];
                    k++;
                }
            }
            Console.WriteLine("Массив отсортирован:");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.Write("\n");
            }
            Console.WriteLine("Введите число:");
            input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                bool found = false;

                for (int i = 0, j = column - 1; i < row && j >= 0;)
                {
                    if (array[i, j] == number)
                    {
                        Console.WriteLine($"Элемент {number} находится в позиции ({i}, {j})");
                        found = true;
                        break;
                    }
                    else if (array[i, j] < number)
                    {
                        i++;
                    }
                    else
                    {
                        j--;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("НЕТ");
                }
            }
            else
            {
                Console.WriteLine("Inccorect value");
            }


        }

        /*
         Дана матрица размером n × m. Переставляя ее строки и столбцы, добиться того, 
         чтобы наибольший элемент (или один из них) оказался в верхнем левом углу.
         */
        static void Task991()
        {
            Random r = new Random();
            int row = 5, column = 7;
            int[,] array = new int[row, column];
            Console.WriteLine("Массив:");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = r.Next(0, 100);
                    Console.Write($"{array[i, j]}\t");
                }
                Console.Write("\n");
            }

            int maxElement = array[0, 0];
            int maxRow = 0;
            int maxColumn = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (array[i, j] > maxElement)
                    {
                        maxElement = array[i, j];
                        maxRow = i;
                        maxColumn = j;
                    }
                }
            }

            int[] tempRow = new int[column];
            for (int j = 0; j < column; j++)
            {
                tempRow[j] = array[0, j];
                array[0, j] = array[maxRow, j];
                array[maxRow, j] = tempRow[j];
            }

            int[] tempColumn = new int[row];
            for (int i = 0; i < row; i++)
            {
                tempColumn[i] = array[i, 0];
                array[i, 0] = array[i, maxColumn];
                array[i, maxColumn] = tempColumn[i];
            }

            Console.WriteLine("Массив отсортирован:");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.Write("\n");
            }
        }

        static void Main()
        {
            //Task928();
            //Task954();
            //Task935();
            //Task991();
        }
    }
}