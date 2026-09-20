Console.Write("Moi ban nhap so nguyen n: ");
string number = Console.ReadLine()?.Trim() ?? "";

if (!long.TryParse(number, out long value))
{
    Console.WriteLine("n khong hop le.");
    return;
}

Console.Write("Moi ban nhap vi tri k (tinh tu trai): ");
int k = int.Parse(Console.ReadLine() ?? "0");

string digits = value.ToString().TrimStart('-');
if (k < 1 || k > digits.Length)
{
    Console.WriteLine("Vi tri k khong hop le.");
    return;
}

int selectedDigit = digits[k - 1] - '0';
int oddSum = 0;
int smallestOdd = 10;
int largestOdd = -1;

foreach (char digitCharacter in digits)
{
    int digit = digitCharacter - '0';
    if (digit % 2 == 1)
    {
        oddSum += digit;
        smallestOdd = Math.Min(smallestOdd, digit);
        largestOdd = Math.Max(largestOdd, digit);
    }
}

Console.WriteLine($"Chu so vi tri {k} (tinh tu trai) cua {value} la {selectedDigit}.");
if (largestOdd == -1)
{
    Console.WriteLine($"{value} khong co chu so le.");
}
else
{
    Console.WriteLine($"Tong cac chu so le cua {value} la {oddSum}.");
    Console.WriteLine($"{value} co chu so le nho nhat la {smallestOdd} va lon nhat la {largestOdd}.");
}