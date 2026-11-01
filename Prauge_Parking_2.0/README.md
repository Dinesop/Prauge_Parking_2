Inlämningsuppgift 2

### Krav på systemet
 - [x] Ta emot fordon.
 - [x] Tala om vilken parkeringsplats fordonet ska parkeras på.
 - [x] Manuellt flytta fordon.
 - [x] Hämta ut fordon och ta bort det ur systemet.
 - [x] Söka efter fordon.
 - [x] Spara data som uppdateras varje gång det sker en förändring i p-huset och som läses in när programmet startar.
 - [x] Karta av Phuset som ska vara läsbar en bit från skärmen
 - [x] Prislista i form av en textfil och kan vid behov läsas in på nytt via ett menyval. Filen ska enkelt gå att ändra på även utan kunskap.
	- [x] Bil 20 CZK/h
	- [x] MC 10 CZK/h
	- [x] 10 min gratis
 - [x] Konfigurationsfil för antal p-platser, fordonstyp och antal fordon per p-plats
 - [x] Systemet ska ha ett grafiskt användargränssnitt med Spectre Console.

### Tekniska krav
 - [x] Minst 5 klasser: Vehicle, Car, MC, ParkingSpot, ParkingGarage
 - [x] Klassbibliotek för dataåtkomst
 - [x] Testköra på en annan dator.
 - [x] Data om de parkerade fordonen lagras i en json fil och uppdateras varje gång det sker en förändring i P-huset. 

### För VG 
 - [x] Minst två gränssnitt (interface) i systemet. Det kan till exempel vara IVehicle och IParkingSpot. Kodning skall primärt göras mot dessa gränssnitt och inte de konkreta klasserna.
 - [x] Bussar ( storlek 16, endast 50 första p-platserna)
 - [x] Cyklar ( 0.25 bilar)
 - [x] Fordonstyp och deras storlek sparas i konfig filen
 - [x] Timtaxa för cyklar och bussar CZK 5/timma, för bussar är det CZK 80.
 - [x] Automatiskt skapad fil som fylls med testdata
 - [x] Ändra konfigurationsfilen med säkert användarinput


##### Personlig reflektion 
 - [x] Skapa en personlig reflektion över kursen och projektet på ca 3 sidor. 