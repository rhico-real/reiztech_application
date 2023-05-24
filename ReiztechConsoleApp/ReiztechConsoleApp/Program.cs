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
    double result = Math.Abs(hourDegrees - minuteDegrees);

    if(result > 180)
    {
        result -= 180;
    }

    Console.WriteLine("Lesser Degree is {0} degrees", result);
} 

// Tree Problem
else if(val == "b")
{       
        //  Sample Tree:
        /// Root
        /// |
        /// Child 1--------------------------------------Child 2
        ///     |                   /                       |                   \
        /// Grandchild11       Grandchild12           Grandchild22            Grandchild32
        ///                         |                   /       \               
        ///                    Grandchild112   Grandchild122   Grandchild222
        ///                                          |
        ///                                    Grandchild1122


        Branch<string> root = new Branch<string>("Root");
        
        Branch<string> child1 = new Branch<string>("Child 1");
        Branch<string> child2 = new Branch<string>("Child 2");

        Branch<string> grandchild11 = new Branch<string>("Grandchild 1 - 1");
        Branch<string> grandchild12 = new Branch<string>("Grandchild 1 - 2");
        Branch<string> grandchild22 = new Branch<string>("Grandchild 2 - 2");
        Branch<string> grandchild32 = new Branch<string>("Grandchild 3 - 2");

        Branch<string> grandchild112 = new Branch<string>("Grandchild 1 - 1 - 2");
        Branch<string> grandchild122 = new Branch<string>("Grandchild 1 - 2 - 2");
        Branch<string> grandchild222 = new Branch<string>("Grandchild 2 - 2 - 2");

        Branch<string> grandchild1122 = new Branch<string>("Grandchild 1 - 1 - 2 - 2");


        root.AddChild(child1);
        root.AddChild(child2);

        child1.AddChild(grandchild11);
        child2.AddChild(grandchild12);
        child2.AddChild(grandchild22);
        child2.AddChild(grandchild32);

        grandchild12.AddChild(grandchild112);
        grandchild22.AddChild(grandchild122);
        grandchild22.AddChild(grandchild222);

        grandchild122.AddChild(grandchild1122);

        // Perform operations on the tree
        TraverseTree(root);

        // Calculate the depth of the tree
        int depth = CalculateTreeDepth(root);

        Console.WriteLine("The depth of the tree is: " + depth);
}
else
{
    Console.WriteLine("Please enter correct choice.");
}

static void TraverseTree(Branch<string> node)
{
    Console.WriteLine(node.Value);

    foreach (var child in node.Branches)
    {
        TraverseTree(child);
    }
}

static int CalculateTreeDepth(Branch<string> node)
{
    if (node.Branches.Count == 0)
    {
        return 1; // Leaf node has depth 1
    }

    int maxChildDepth = 0;

    foreach (var child in node.Branches)
    {
        int childDepth = CalculateTreeDepth(child);
        maxChildDepth = Math.Max(maxChildDepth, childDepth);
    }

    return maxChildDepth + 1; // Add 1 for the current node
}

public class Branch<T>
{
    public T Value { get; set; }
    public Branch<T>? Parent { get; set; }
    public List<Branch<T>> Branches { get; set; }

    public Branch(T value)
    {
        Value = value;
        Parent = null;
        Branches = new List<Branch<T>>();
    }

    public void AddChild(Branch<T> child)
    {
        child.Parent = this;
        Branches.Add(child);
    }
}

