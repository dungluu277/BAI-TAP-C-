double[,] matrix = ReadMatrix(out int rows, out int columns);
int positiveCount = 0;
int negativeCount = 0;
int zeroCount = 0;

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        if (i != 0 && i != rows - 1 && j != 0 && j != columns - 1)
        {
            continue;
        }

        if (matrix[i, j] > 0) positiveCount++;
        else if (matrix[i, j] < 0) negativeCount++;
        else zeroCount++;
    }
}

Console.WriteLine($"Tren duong bien co {positiveCount} so duong, {negativeCount} so am va {zeroCount} so khong.");

static double[,] ReadMatrix(out int rows, out int columns)
{
    Console.Write("Moi ban nhap so dong n: ");
    rows = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Moi ban nhap so cot m: ");
    columns = int.Parse(Console.ReadLine() ?? "0");
    if (rows < 1 || rows > 100 || columns < 1 || columns > 100)
    {
        throw new ArgumentException("So dong va so cot phai nam trong khoang 1 den 100.");
    }

    double[,] result = new double[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"A[{i},{j}] = ");
            result[i, j] = double.Parse(Console.ReadLine() ?? "0");
        }
    }
    return result;
}