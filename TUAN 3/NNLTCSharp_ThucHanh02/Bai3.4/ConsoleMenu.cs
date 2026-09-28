using System;

public class ConsoleMenu
{
    private readonly string _title;
    private readonly string[] _options;

    public event Action<int>? Choose;

    public ConsoleMenu(string title, params string[] options)
    {
        _title = title;
        _options = options;
    }

    public void Show()
    {
        Console.WriteLine(_title);
        Console.WriteLine(new string('-', _title.Length));

        for (int i = 0; i < _options.Length; i++)
        {
            Console.WriteLine(_options[i]);
        }

        Console.WriteLine();
        Console.Write("Bạn thực hiện chức năng: ");
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Show();

            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Nhấn phím bất kỳ để thử lại.");
                Console.ReadKey();
                continue;
            }

            if (choice == 0)
            {
                Console.WriteLine("Thoát chương trình.");
                break;
            }

            if (choice < 1 || choice > _options.Length)
            {
                Console.WriteLine($"Không có chức năng {choice}. Nhấn phím bất kỳ để thử lại.");
                Console.ReadKey();
                continue;
            }

            Choose?.Invoke(choice);
        }
    }
}
