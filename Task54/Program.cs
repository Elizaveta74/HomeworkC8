/*
Задача 54: Задайте двумерный массив. Напишите программу,
которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

int[,] FillMatrix(int rowsCount, int columnsCount, int leftRange = 1, int rightRange = 20)
{
    int[,] matrix = new int[rowsCount, columnsCount];

    Random rand = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}

void SortMatrixRowDescending(int[,] matrix, int rowNumber)
{
    // длина одномерного массива (строки) равна количеству столбцов
    int n = matrix.GetLength(1); 
    for(int i = 0; i < n-1; i++)
    {
        for(int j = 0; j < n - i - 1; j++)
        {
            if (matrix[rowNumber, j] < matrix[rowNumber, j + 1])
            {
                int temp = matrix[rowNumber, j];
                matrix[rowNumber, j] = matrix[rowNumber, j + 1];
                matrix[rowNumber, j + 1] = temp; 
            }
        }
    }
}

void SortMatrixDescending(int[,] matrix)
{
    for(int row = 0; row < matrix.GetLength(0); row++)
    {
        SortMatrixRowDescending(matrix, row);
    }
}

Console.WriteLine("Введите m и n через Enter:");
int m = Convert.ToInt32(Console.ReadLine()); 
int n = Convert.ToInt32(Console.ReadLine()); 
int[,] array2D = FillMatrix(m, n);
PrintMatrix(array2D);
Console.WriteLine("--------------------------");
SortMatrixDescending(array2D);
PrintMatrix(array2D);
