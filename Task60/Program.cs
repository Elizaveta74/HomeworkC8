/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив,
добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

int[,,] Fill3DMatrix(int sideLength)
{
    // берем трехмерный массив с одинаковыми ребрами
    int[,,] matrix = new int[sideLength, sideLength,sideLength];

    int count = 9;

    for (int i = 0; i < sideLength; i++)
    {
        for (int j = 0; j < sideLength; j++)
        {
            for (int k = 0; k < sideLength; k++)
            {
                count++;
                matrix[i, j, k] = count;
            } 
        }
    }
    return matrix;
}

void Print3DMatrix(int[,,] matrix)
{
    for(int z = 0; z < matrix.GetLength(2); z++)
    {
        for(int x = 0; x < matrix.GetLength(0); x++)
        {
            for(int y = 0; y < matrix.GetLength(1); y++)
            {
                Console.Write($"{matrix[x, y, z]} ({x},{y},{z})\t");
            }
            Console.WriteLine();
        }
    }
}


int[,,] matrix3D = Fill3DMatrix(3);
Print3DMatrix(matrix3D);
