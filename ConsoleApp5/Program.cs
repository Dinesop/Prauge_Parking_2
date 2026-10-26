namespace ConsoleApp5
{
    //public enum CoffeeSize
    //{
    //    Small = 100, Normal = 150, Double = 300
    //}
    //public class Coffee
    //{
    //    public CoffeeSize size;
    //    public Coffee(CoffeeSize size)
    //    {
    //        this.size = size;
    //    }
    //    public CoffeeSize Size
    //    {
    //        get { return size; }
    //    }
    //}

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Coffee normalCoffee = new Coffee(CoffeeSize.Normal);
    //        Coffee doubleCoffee = new Coffee(CoffeeSize.Double);
    //        Console.WriteLine("The {0} coffee is {1} ml.",
    //        normalCoffee.Size, (int)normalCoffee.Size);
    //        // The Normal coffee is 150 ml.

    //        Console.WriteLine("The {0} coffee is {1} ml.",
    //        doubleCoffee.Size, (int)doubleCoffee.Size);
    //        // The Double coffee is 300 ml.
    //    }
    //}
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public class EnumConversionExample
    {
        public static void Main()
        {
            Season a = Season.Autumn;
            Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2

            var b = (Season)1;
            Console.WriteLine(b);  // output: Summer

            var c = (Season)4;
            Console.WriteLine(c);  // output: 4
        }
    }
}
