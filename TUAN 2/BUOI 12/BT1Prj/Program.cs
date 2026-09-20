int[,] matrix = ReadMatrix(out int rows, out int columns);
long evenSum = 0;
long oddSum = 0;

foreach (int value in matrix)
{
    if (value % 2 == 0)
    {
        evenSum += value;
    }
    else
    {
        oddSum += value;
    }
}

Console.WriteLine($"Tong cac so chan la {evenSum} va tong cac so le la {oddSum}.");

static int[,] ReadMatrix(out int rows, out int columns)
{
    Console.Write("Moi ban nhap so dong n: ");
    rows = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Moi ban nhap so cot m: ");
    columns = int.Parse(Console.ReadLine() ?? "0");
    if (rows < 1 || rows > 100 || columns < 1 || columns > 100)
    {
        throw new ArgumentException("So dong va so cot phai nam trong khoang 1 den 100.");
    }

    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"A[{i},{j}] = ");
            result[i, j] = int.Parse(Console.ReadLine() ?? "0");
        }
    }
    return result;
}