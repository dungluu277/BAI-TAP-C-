using Tuan02.TH2;

var pl = new PersonList();
pl.Input(); 

Console.WriteLine();
Console.WriteLine("Danh sach tat ca (Output()):");
pl.Output();

Console.WriteLine();
Console.WriteLine("Danh sach nguoi con song (LivingPeople()):");
pl.LivingPeople().Output();
