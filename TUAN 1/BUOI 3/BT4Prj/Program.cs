Console.Write("Moi ban nhap vao thang: ");
int month = int.Parse(Console.ReadLine() ?? "0");

string monthName = month switch
{
    1 => "January",
    2 => "February",
    3 => "March",
    4 => "April",
    5 => "May",
    6 => "June",
    7 => "July",
    8 => "August",
    9 => "September",
    10 => "October",
    11 => "November",
    12 => "December",
    _ => "Thang khong hop le"
};

Console.WriteLine(monthName);