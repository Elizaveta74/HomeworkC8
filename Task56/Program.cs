/*
Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку
с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке
и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/
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

long GetRowElementsSum(int[,] matrix, int rowNumber)
{
    long sum = 0;
    for(int columnNumber = 0; columnNumber < matrix.GetLength(1); columnNumber++)
    {
        sum+=matrix[rowNumber, columnNumber];
    }
    return sum;
}

int GetMinimalSumRowNumber(int[,] matrix)
{
    long minimalSum = GetRowElementsSum(matrix, 0);
    int foundRowNumber = 0;
    for(int row = 1; row < matrix.GetLength(0); row++)
    {
        long sum = GetRowElementsSum(matrix, row);
        if(sum < minimalSum)
        {
            minimalSum = sum;
            foundRowNumber = row;
        }
    }
    return foundRowNumber;
}

Console.WriteLine("Введите m и n через Enter:");
int m = Convert.ToInt32(Console.ReadLine()); 
int n = Convert.ToInt32(Console.ReadLine()); 
int[,] array2D = FillMatrix(m, n);
PrintMatrix(array2D);
Console.WriteLine("--------------------------");
int rowNumber = GetMinimalSumRowNumber(array2D);
Console.WriteLine($"Номер строки с минимальной суммой: {rowNumber}");

