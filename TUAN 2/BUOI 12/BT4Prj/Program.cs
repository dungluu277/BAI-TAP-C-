int[,] matrix = ReadMatrix(out int rows, out int columns);
List<int> increasingRows = new();

for (int i = 0; i < rows; i++)
{
    bool isIncreasing = true;
    for (int j = 1; j < columns; j++)
    {
        if (matrix[i, j] <= matrix[i, j - 1])
        {
            isIncreasing = false;
            break;
        }
    }

    if (isIncreasing)
    {
        increasingRows.Add(i);
    }
}

Console.WriteLine(increasingRows.Count == 0
    ? "Khong co dong nao tao thanh day tang."
    : $"Cac dong tao thanh day tang: {string.Join(" ", increasingRows)}");

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