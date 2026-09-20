Console.Write("Moi ban nhap so nguyen duong n: ");
string input = Console.ReadLine()?.Trim() ?? "";

if (!long.TryParse(input, out long number) || number <= 0)
{
    Console.WriteLine("n phai la so nguyen duong.");
    return;
}

int[] digitCounts = new int[10];
foreach (char digitCharacter in number.ToString())
{
    digitCounts[digitCharacter - '0']++;
}

for (int digit = 0; digit <= 9; digit++)
{
    if (digitCounts[digit] > 0)
    {
        Console.WriteLine($"Chu so {digit} xuat hien {digitCounts[digit]} lan.");
    }
}