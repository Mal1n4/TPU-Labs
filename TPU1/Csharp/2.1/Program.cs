// See https://aka.ms/new-console-template for more information
/*           |   M ,                 если            M < A ;
        N =  |   M * √( M^2 + 3 ) ,                  M = A ;
             |   4 - M ,                             M > A .
*/
Console.WriteLine("Enter double M, A (in one line):");
string s =  Console.ReadLine();
List<string> vars = s.Split(" ").ToList();
double m = Convert.ToDouble(vars[0]);
double a = Convert.ToDouble(vars[1]);
Console.WriteLine("     | M ,                 если     M < A ;");
Console.WriteLine("N =  | M * √( M^2 + 3 ) ,           M = A ;");
Console.WriteLine("     | 4 - M ,                      M > A .");
if (m < a) {
    Console.WriteLine($"N = {m}\n");
}
else if (m == a) {
    Console.WriteLine($"N = {m * Math.Sqrt(m * m + 3)}\n");
}
else {
    Console.WriteLine($"N = {4 - m}\n");
}
