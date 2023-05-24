Console.WriteLine("Press a: Clock Problem. \nPress b: Tree Problem");
string val = Console.ReadLine();

// Clock Problem
if(val == "a")
{
    Console.Write("Enter hour: ");
    double hour = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter minutes: ");
    double minutes = Convert.ToDouble(Console.ReadLine());

    //Calculate hour degrees
    double hourDegrees = hour * 30;

    //Calculate minute degrees
    double minuteDegrees = minutes * 6;

    if(minutes > 0)
    {
        hourDegrees += ((minutes / 60) * 30);
    }

    /// Subtract hour degrees to minute degrees
    /// to get the lesser degree
    Console.WriteLine("{0}, {1}", hourDegrees, minuteDegrees);

    double result = Math.Abs(hourDegrees - minuteDegrees);

    while(result > 360)
    {
        result = result / 360;
    }

    Console.WriteLine("Lesser Degree is {0} degrees", result);
} 

// Tree Problem
else if(val == "b")
{

}
else
{
    Console.WriteLine("Please enter correct choice.");
}

class Branch 
{
    List<Branch> branches;
}

