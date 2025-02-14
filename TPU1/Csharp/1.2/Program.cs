// See https://aka.ms/new-console-template for more information
/*Z = ( A + 1 ) * 3 - B^2 * ( X1 + 2 )^2 ; где     X1 = 3.5 * A * B
          Y = ( B + 1 ) * 8 - A * ( X2 - X1 ) ;                  X2 = 15.36 - A * B .
*/
Console.WriteLine("Z = ( A + 1 ) * 3 - B^2 * ( X1 + 2 )^2");
Console.WriteLine("Y = ( B + 1 ) * 8 - A * ( X2 - X1 )");
Console.WriteLine("X1 = 3.5 * A * B");
Console.WriteLine("X2 = 15.36 - A * B\n");
Console.WriteLine("Enter double A, double B (in one line):");
string temp = Console.ReadLine();
List<string> s = temp.Split(" ").ToList();
double a = Convert.ToDouble(s[0]);
double b = Convert.ToDouble(s[1]);
double x1 = 3.5 * a * b;
double x2 = 15.36 - a * b;
double z = (a + 1) * 3 - b * b * (x1 + 2) * (x1 + 2);
double y = (b + 1) * 8 - a * (x2 - x1);
Console.WriteLine($"\nZ: {z}\nY: {y}\nX1: {x1}\nX2: {x2}\n");