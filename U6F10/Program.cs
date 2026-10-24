namespace U6F10
{
    public class Konto
    {
        private string _epost;      // Privat fält (backing field)
        public Konto(string epost)
        {
            Epost = epost;
        }
        public Konto()
        {

        }

        public string Epost
        {
            get { return _epost; }
            set
            {
                // Gör en validering innan värdet sätts
                if (value.Contains("@"))
                {
                    _epost = value;
                }
                else
                {
                    _epost = "ogiltig e-postadress";
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Konto k1 = new Konto();
            k1.Epost = "test@domain.se";
            Console.WriteLine($"Konto 1 epost: {k1.Epost}");

            Konto k2 = new Konto();
            k2.Epost = "feladress.se";
            Console.WriteLine($"Konto 2 epost: {k2.Epost}");

            Konto k3 = new Konto("kalle@gmail.com");
            Console.WriteLine($"Konto 3 epost: {k3.Epost}");

            Konto k4 = new Konto("wrongaddress.com");
            Console.WriteLine($"Konto 4 epost: {k4.Epost}");





            Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
            Console.ReadKey();
        }
    }
}
