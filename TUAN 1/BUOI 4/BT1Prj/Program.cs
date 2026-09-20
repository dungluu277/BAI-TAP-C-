Console.Write("Moi ban nhap diem Toan, Ly, Hoa: ");
string[] input = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

double math = double.Parse(input[0]);
double physics = double.Parse(input[1]);
double chemistry = double.Parse(input[2]);
double average = (math * 2 + physics * 3 + chemistry) / 6;

string classification = average switch
{
    >= 8 => "Gioi",
    >= 6.5 => "Kha",
    >= 5 => "Trung binh",
    _ => "Yeu"
};

Console.WriteLine($"Ban co diem trung binh {average:F2} duoc xep loai {classification}.");