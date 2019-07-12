using System;
using System.Diagnostics;
using System.Numerics;

class FibonacciChecks
{
    public static BigInteger[] my_memo;
    public static DateTime my_time;
    public static long my_counter;

    static void Main()
    {
        // Console.WriteLine("Enter number between 2 and 1300 for Fibonacci calculation:");
        // int k = int.Parse(Console.ReadLine());
        // my_memo = new BigInteger[k + 1];

        my_counter = 0;
        my_time = DateTime.Now;

        int[] a = GetInput();
        Console.WriteLine(a.Length);


        // Console.WriteLine("----- Memorization -----");

        // for (int i = 0; i < a.Length; i++)
        // {
        //     my_memo = new BigInteger[a[i] + 1];
        //     Console.WriteLine("\n{0}; {1}; {2};{3} ", a[i], FibWithMemo(a[i]), my_counter, (DateTime.Now - my_time).TotalMilliseconds);

        // }

        // Console.WriteLine("----- No Recursion -----");

        // for (int i = 0; i < a.Length; i++)
        // {
        //     my_memo = new BigInteger[a[i] + 1];
        //     Console.WriteLine("\n{0}; {1}; {2};{3} ", a[i], FibWithLoop(a[i]),my_counter (DateTime.Now - my_time).TotalMilliseconds);
        // }
        var watch = new System.Diagnostics.Stopwatch();
        Console.WriteLine("----- No Memorization -----");

        for (int i = 0; i < a.Length; i++)
        {
            my_memo = new BigInteger[a[i] + 1];
            watch.Start();
            BigInteger res = FibWithMemo(a[i], false);
            watch.Stop();
            Console.WriteLine("{0};{1};{2};{3}", a[i], res, my_counter, watch.Elapsed.TotalMilliseconds);
        }




        // Console.WriteLine("\n{0}", FibWithMemo(k));
        // Console.WriteLine("Calculations {0}", my_counter);
        // Console.WriteLine(DateTime.Now - my_time);


        // my_counter = 2; //Here we already have the first two numbers, so it is a bit unfair
        // my_time = DateTime.Now;

        // Console.WriteLine("\n{0}", FibWithLoop(k));
        // Console.WriteLine("Calculations {0}", my_counter);
        // Console.WriteLine(DateTime.Now - my_time);

        // my_counter = 0;
        // my_time = DateTime.Now;

        // Console.WriteLine("\n{0}", FibWithMemo(k, false));
        // Console.WriteLine("Calculations {0}", my_counter);
        // Console.WriteLine(DateTime.Now - my_time);
    }

    static BigInteger FibWithLoop(int counter_inside)
    {

        BigInteger f1 = 1;
        BigInteger f2 = 1;
        BigInteger f_result = 0;

        for (my_counter = 2; my_counter < counter_inside; my_counter++)
        {
            f_result = f1 + f2;
            f1 = f2;
            f2 = f_result;
        }

        return f_result;


    }

    static BigInteger FibWithMemo(int counter_inside, bool with_memo = true)
    {
        if (with_memo)
        {
            if (my_memo[counter_inside] != 0) return my_memo[counter_inside];
        }

        my_counter++;

        if (counter_inside == 0) return 0;
        if (counter_inside == 1) return 1;
        my_memo[counter_inside] = FibWithMemo(counter_inside - 1, with_memo) + FibWithMemo(counter_inside - 2, with_memo);
        return my_memo[counter_inside];
    }

    static int[] GetInput()
    {
        string line = null;
        int counter = 0;

        System.IO.StreamReader file = new System.IO.StreamReader(@"input.txt");
        int[] res = new int[int.Parse(file.ReadLine())];
        while ((line = file.ReadLine()) != null)
        {
            res[counter] = int.Parse(line);
            counter++;
        }

        file.Close();
        System.Console.WriteLine("There were {0} lines.", counter);

        return res;
    }

}
