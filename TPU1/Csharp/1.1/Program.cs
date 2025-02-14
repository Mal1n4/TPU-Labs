// See https://aka.ms/new-console-template for more information
// 5.Создать программу, вычисляющую площадь трапеции (S) по формуле 
//   S = 0,5Н(А+В).

Console.WriteLine("Enter H - height, A - length1, B - length2 (in different lines)");
double h = Convert.ToDouble(Console.ReadLine());
double a = Convert.ToDouble(Console.ReadLine());
double b = Convert.ToDouble(Console.ReadLine());
double s = (1 / 2.0) * h * (a + b);
Console.WriteLine($"Square of trapeze: {s}");


