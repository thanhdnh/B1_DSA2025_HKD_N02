public class Program
{
    static void Swap<T>(ref T a, ref T b)   //Swap<T, U, V>
    {
        T temp = a;
        a = b;
        b = temp;
    }
    //Tính tổng của 2 số, 2 xâu, 2 mảng (int)
    static T Sum<T>(T a, T b)
    {
        if(a.GetType()==typeof(int[]) && b.GetType()==typeof(int[]))//là mảng
        {
            int[] arr = new int[((dynamic)a).Length + ((dynamic)b).Length];
            for (int i = 0; i < arr.Length; i++)
                if(i<((dynamic)a).Length)
                    arr[i] = ((dynamic)a)[i];
                else
                    arr[i] = ((dynamic)b)[i-((dynamic)a).Length];
            return (dynamic)arr;
        } else
            return (dynamic)a + (dynamic)b;
    }
    static void Main(string[] args)
    {
        Console.Clear();

        int a = 10, b = 20;
        Console.WriteLine("{0}+{1}={2}", a, b, Sum<int>(a, b));

        string x = "Hello", y = "World";
        Console.WriteLine("{0}+{1}={2}", x, y, Sum<string>(x, y));

        int[] arr1 = { 1, 2, 3 }, arr2 = { 4, 5, 6 };
        Console.WriteLine("[{0}]+[{1}]=[{2}]", string.Join(",", arr1), 
                string.Join(",", arr2), string.Join(",", Sum<int[]>(arr1, arr2)));
        
        //int[] a = { 1, 2, 3 };
        //Console.WriteLine(a.GetType()==typeof(int[]));

        /*
        int a = 10, b = 20;
        Swap<int>(ref a, ref b);
        Console.WriteLine("a={0}, b={1}", a, b);

        string x = "Hello", y = "World";
        Swap<string>(ref x, ref y);
        Console.WriteLine("x={0}, y={1}", x, y);
        */
    }
}