namespace ConsoleApp1
{
    using System;

    namespace PowerSwitchApp
    {
        // 1. GRÄNSSNITT (INTERFACE)
        // Definierar vad som krävs för att en enhet ska kunna styras av brytaren
        public interface ISwitchable
        {
            bool IsOn { get; }
            void TurnOn();
            void TurnOff();
        }

        // 2. ENHETEN (KLASS)
        // En specifik enhet (en lampa) som implementerar gränssnittet
        public class LightBulb : ISwitchable
        {
            public bool IsOn { get; private set; } = false;

            public void TurnOn()
            {
                if (!IsOn)
                {
                    IsOn = true;
                    Console.WriteLine("Lampan lyser nu! 💡");
                }
            }

            public void TurnOff()
            {
                if (IsOn)
                {
                    IsOn = false;
                    Console.WriteLine("Lampan är släckt. 🌑");
                }
            }
        }

        // 3. STRÖMBRYTAREN (KLASS)
        // Tar emot valfri ISwitchable-enhet och växlar dess strömstatus
        public class PowerSwitch
        {
            private readonly ISwitchable _device;

            public PowerSwitch(ISwitchable device)
            {
                _device = device ?? throw new ArgumentNullException(nameof(device));
            }

            public void Toggle()
            {
                if (_device.IsOn)
                {
                    _device.TurnOff();
                }
                else
                {
                    _device.TurnOn();
                }
            }
        }

        // 4. PROGRAMMETS STARTPUNKT
        // Här kopplas allt samman och körs
        class Program
        {
            static void Main(string[] args)
            {
                // Skapa enheten
                ISwitchable lampa = new LightBulb();

                // Skapa strömbrytaren och skicka in lampan i den
                PowerSwitch strombrytare = new PowerSwitch(lampa);

                // Testa att använda strömbrytaren
                Console.WriteLine("--- Klick 1 ---");
                strombrytare.Toggle(); // Tänder lampan

                Console.WriteLine("\n--- Klick 2 ---");
                strombrytare.Toggle(); // Släcker lampan

                Console.ReadLine(); // Håller konsolfönstret öppet
            }
        }
    }

}
