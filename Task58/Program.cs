/*
Задача 58: Задайте две матрицы. Напишите программу,
которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

int[,] FillMatrix(int rowsCount, int columnsCount, int leftRange = 1, int rightRange = 10)
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

int CalcResultMatrixElement(int[,] matrix1, int[,] matrix2, int resultMatrixRow, int resultMatrixColumn)
{
    int sum = 0;
    for(int count = 0; count < matrix1.GetLength(1); count++)
    {
        sum += matrix1[resultMatrixRow, count] * matrix2[count, resultMatrixColumn];
    }
    return sum;
}

int[,] MultiplyMatrixes(int[,] matrix1, int[,] matrix2)
{
    // количество строк новой матрицы =  кол-ву строк первой матрицы
    int rows1 = matrix1.GetLength(0); 
    // количество столбцов новой матрицы = кол-ву столбцов второй матрицы
    int columns2 = matrix2.GetLength(1);
    int[,] resultMatrix = new int[rows1, columns2];
    for(int row = 0; row < resultMatrix.GetLength(0); row++)
    {
        for(int column = 0; column < resultMatrix.GetLength(1); column++)
        {
            resultMatrix[row, column] = CalcResultMatrixElement(matrix1, matrix2, row, column);
        }
    }
    return resultMatrix;
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


Console.WriteLine("Введите m и n для первой матрицы через Enter:");
int m1 = Convert.ToInt32(Console.ReadLine()); 
int n1 = Convert.ToInt32(Console.ReadLine()); 
int[,] array1 = FillMatrix(m1, n1);
PrintMatrix(array1);
Console.WriteLine("--------------------------");
Console.WriteLine($"Введите n для второй матрицы,\nчисло строк будет равно количеству столбцов первой матрицы {n1}");
int m2 = n1; 
int n2 = Convert.ToInt32(Console.ReadLine()); 
int[,] array2 = FillMatrix(m2, n2);
PrintMatrix(array2);
Console.WriteLine("--------------------------");

int[,] resultArray = MultiplyMatrixes(array1, array2);
PrintMatrix(resultArray);
