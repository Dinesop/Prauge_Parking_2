namespace _02_Konstruktorer_vid_arv__Djur_och_Katt_;

public class Djur
{
    public string Namn;
    public Djur(string namn)
    {
        Namn = namn;
    }
}

public class Katt : Djur
{
    // Konstruktorn skickar namnet till basklassens konstruktor
    public Katt(string namn) : base(namn)
    {

    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Uppgift 2: konstruktorer vid arv ---\n\n");

        Katt sven = new Katt("Sven");
        Console.WriteLine($"Katten heter {sven.Namn}");




        Console.Write("\n\nTryck på en tangent för att stänga fönstret");
        Console.ReadKey();
    }
}