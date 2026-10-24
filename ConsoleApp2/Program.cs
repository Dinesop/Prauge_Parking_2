namespace ConsoleApp2
{
    public class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return "Hello! My name is " + Name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 3;
            Person[] persons = new Person[total];

            for (int i = 0; i < total; i++)
            {
                persons[i] = new Person()
                {
                    Name = Console.ReadLine()
                };
            }
        }
    }
}
