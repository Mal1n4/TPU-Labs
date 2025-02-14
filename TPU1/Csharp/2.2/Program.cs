// See https://aka.ms/new-console-template for more information
Console.WriteLine("Input 3 doubles A, B, C (in one line): ");
string s = Console.ReadLine();
List<string> v = s.Split(" ").ToList();
double a = Convert.ToDouble(v[0]);
double b = Convert.ToDouble(v[1]);
double c = Convert.ToDouble(v[2]);
if (a > c && a > b)
{
    Console.WriteLine($"Max(A, B, C) = {a}");
}
else if (b > a && b > c)
{
    Console.WriteLine($"Max(A, B, C) = {b}");
}
else
{
    Console.WriteLine($"Max(A, B, C) = {c}");
}