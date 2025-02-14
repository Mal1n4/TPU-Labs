// See https://aka.ms/new-console-template for more information
/*X = √( Y1^2 + Z1^2 + P1^2 )/tn(Z1) 
     a) y1,P1- задаются произвольно 
        z1 изменяется от -3 до -5 с шагом -1 
*/
Console.WriteLine("Enter y1, P1 (in different lines):");
double y1 = Convert.ToDouble(Console.ReadLine());
double p1 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("X = √( Y1^2 + Z1^2 + P1^2 )/tn(Z1)\n");
for (int z1 = -3; z1 >= -5; z1--)
{
    double x = Math.Sqrt(y1 * y1 + z1 * z1 + p1 * p1) / Math.Tan(z1);
    Console.WriteLine($"X({z1}) = {x}");
}