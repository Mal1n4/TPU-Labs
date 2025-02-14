// See https://aka.ms/new-console-template for more information
/*P = ( M * Z1 - L * Z2 ) / 5.85 ;
      L изменяется от 0.1 до 1 с шагом 0.2
         m,z1,z2-произвольно
*/
Console.WriteLine("Enter m, z1, z2 (in different lines):");
double m = Convert.ToDouble(Console.ReadLine());
double z1 = Convert.ToDouble(Console.ReadLine());
double z2 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("P = ( M * Z1 - L * Z2 ) / 5.85\n");
double l = 0.1;
while (l<=1)
{
    double p = (m*z1-l*z2) / 5.85;
    Console.WriteLine($"P({l}) = {p}");
    l += 0.2;
    l = Math.Round(l, 1);
}
