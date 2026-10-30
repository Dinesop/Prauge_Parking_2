# Loggbok
## 20/10
Snackade lite med Linnea och försökte få grepp om uppgiften men det känns svårt att binda ihop allting. Började med ett digitalt flödesschema för programmet men det är så bökigt att få till pilar och former att jag ändå lutar åt att köra penna och papper, ska ju inte behöva lägga flera timmar på att få till ett snyggt flödesschema över programmet. 
Ska se om jag lyckas bifoga bilden på vad jag åstakommit hittills och så får vi se vad det blir av det. 
La till ett class diagram och ett class library i projektet nu iaf, så får vi se hur det går med att använda allt. Känns som att jag bara får testa mig fram och hoppas jag förstår på vägen.

Fråga: Är det bara dataåtkomst filer som ska ligga i klassbiblioteket? Eller ska alla klasser ligga där?

Nu bad jag Gemini om hjälp med hur man ska strukturera upp en powerSwitch med klasser och gränssnitt för steget mellan while loop och powerSwitch bool till det var bara för stort just nu. 
Sen bad jag mina klasskamrater om hjälp med hur man ska kunna bryta isär allt och fick tipset att inte göra det än så det kör vi på. 
Fortsätter bygga min meny med nästlade menystrukturer och switch-case strukturer, då jag tänker att det borde gå att bryta isär till objekt
Om jag har en menu klass med property MenuChoice, så blir varje ny menu jag skapar med nyckelordet new ett objekt, med propertyn MenuChoice. Jag trodde för ett ögonblick att egenskapen är objektet, men insåg när jag började skriva ner det här, att så är det ju inte. Återigen, räddad av loggboken!

## 21/10
Okej,  jag får min huvudmeny att funka men sen när jag vill ha en undermeny får jag inte den att hoppa tillbaka till huvudmenyn när jag väljer back. Okej, vi testar tipset att använda TODOs för att hålla koll på allt som behöver fixas och bordlägger den biten för tillfället. 
Jag har fortfarande svårt att greppa hur programmet flödar med klasser så det får vänta. 

## 22/10 
Jag har fortfarande inte en aning om hur jag ska få ihop detta, men menyn funkar även om den bara är ett nästlat kaos. Så strukturerade upp kravspecen i README.md och ska försöka mig på att bygga en Vehicle class. 
Det som alla fordon behöver är ett regnr och en storlek, så vi börjar där och ser om vi kan skapa ett fordon. Jag vet ju att vi behöver ha subklasser som ärver Vehicle men jag kan inte greppa den strukturen än. Behöver också lagra allt i en fil, men det brukar vara väldigt simpelt och det har jag gjort förut så hoppas det ska gå smidigt när jag kommer dit.  
Okej, vi har en fungerande fordonsklass. Nu ska vi skapa en fungerande pHus klass att parkera fordonet i. 

Testade om TODO knepet funkade även här, men tyvärr gjorde det inte det. Får köra manuellt helt enkelt.
TODO: Redo Vehicle class to abstract and create subclass Car and Motorcycle.


Okej, om fordonsklassen hade egenskaper regnr och storlek, vad ska parkingsgarage klassen ha för egenskaper? parkeringsplats ska vara en subklass, så då borde ju egenskaperna vara parkeringsutrymme? varför ska parkeringsplats vara en subklass? är det för att vi vill kunna ha olika parkeringsplatser för olika fordonstyper? då borde ju storlek vara en egenskap som ska finnas med i alla parkeringsplatser. och kanske beläggning?

phus - kapacitet ( antal platser ) och utrymme (antal lediga platser just nu)
pplats - storlek (hur stort fordon får plats) och beläggning (hur stor del av platsen är full)

Det känns konsigt att ha beläggning som en egenskap av pHuset ur programmeringsperspektiv men inte ur ett verklighetsperspektiv. Så vi testar väl det. 

Okej så det jag vill göra är att instantiera x stycken pSpots objekt i mitt pGarage. 
ett nytt pSpot objekt är ParkingSpot namn1 = new ParkingSpot();
Och så vill jag ha det gånger x i mitt PHus. 

Förra uppgiften löste jag det mesta utan hjälp av AI utan höll mig till generiska StackOverflow poster och lite bollande med klasskamrater. Det kommer inte funka denna gång. Får liksom inte grepp om hur jag ska göra, så försöker få AI att förklara hur jag tänka runt att lösa problemet, inte ge mig lösningen.
Nackdelen med AI är att det är svårt att begränsa användandet av det, när man väl börjat. Och jag vet från förra uppgiften och från i allmänhet att ens förståelse inte hänger med när man använder det. Men som allt måste man nog bara hitta en bra balans.
Okej, jag kan nu parkera en bil, det får vara bra nog för idag. Jag hoppas rensa hjärnan lite kanske hjälper. 

## 23/10
- Jag börjar närma mig det jag inte förstår inom OOP, hur objekt och klasser interagerar med varandra. Jag förstår alla bitarna, men kan inte sätta ihop dom. Så bollar lite med Gemini för att hitta vägar framåt.
- Jag älskar inte långa namn men behöver verkligen förstå vad saker gör baserat på deras namn nu så det får bli lite långt.
- Jag ska försöka mig på att splitta ut mina klasser i egna filer nu, för att se om det uppdaterar klassdiagramet, som jag tror att det gör, vilket skulle hjälpa överskådligheten hoppas jag. Börjar också bli mycket text i en fil.
- Klassdiagrammet verkar bara plocka upp arv än så länge, hade hoppats att den skulle plocka upp att jag kallar på ett objekt Vehicle i min parkingspot class, men det var för mycket begärt. Allting funkar ju fortafarande dock så det är ju trevligt i alla fall.
- Okej, vi kan ta emot fordon. Nu ska vi hämta ut dom igen. Då behöver vi ange regnr och hitta det bland våra parkeringsplatser.
- Jag börjar inse att mitt problem består i att jag fortfarande försöker lösa detta ur ett icke-OOP perspektiv eftersom den biten inte klickat ännu. Jag tänker fortfarande på fordonen som strängar i en p-hus lista, inte som egna objekt med egna egenskaper. Men för att hitta ett fordon att plocka ut, måste vi ju hitta objektet med egenskapen LicencePlate som matchar det vi söker efter. När jag kör mitt program parkeras ett Vehicle objekt på en parkingSpot och Egenskapen ParkedVehicle får Egenskaperna LicencePlate och Size eftersom att vi lägger objektet Vehicle i parkingsSpot. Så jag ska inte leta efter fordonet, jag ska leta efter parkeringsplatsen som har egenskapen av att ett fordon med regnr xxx står där. 
- Jag skulle vilja ha en metod som kollar alla parkeringsplatser, nu har jag en foreach loop och ett vilkor i den, och skulle precis göra en ny metod med samma upplägg fast annat vilkor. Då borde det ju gå att bygga en kolla-alla-p-platser metod, men eftersom vilkoret kommer inuti foreach loopen funkar ju inte det. Visst kan man vända på loopen, så att vilkoret kommer utanför och metoden som kollar alla p-platser retunerar något lämpligt... vad skulle det vara då? parkingspot har egenskaperna IsOccupied, ParkedVehicle och ParkingSpotNr. I don't think this is possible to achive. Tried it and asked Gemini about it, and will ask in the Discord about it but every thing I checked lead back to the need to loop through each object.
- Kan söka efter regnr nu, snackade lite med Stig också om strukturer och hur allt hänger ihop. Fick lite tips och tankar om hur man bättre lägger upp sitt förhållande mellan fält och egenskaper. Nu ska jag se om jag kan plocka ut fordon.
- Okej, blev stolt över mig själv för skrev ett plocka ut fordon set av metoder, baserat på att hitta och använda parkeringsplatsens index, så som vi gjorde i PP1. Fick ett index fel och insåg att jag inte alls ska använda index, ska ju använda objekt, och justerade där efter. Nu får vi hoppas att det funkar med!
- Började försöka komma på hur man flyttar ett objekt utan att fastna i index träsket och lyckades byta plats på en parkerad bil men hade då 2 p-platser med samma id. 

## 24/10
- Jag började försöka få till så att LicencePlate och Size bara gick att deklarera vid instantieringen av ett fordons objekt men löste inte det. Fick städat upp lite bland fält och egenskaper dock. Nu ska vi se om allt fortfarande funkar och i så fall ska vi fortsätta försöka flytta ett objekt. 
- Nu kan vi flytta fordon också. 
- Tidsstämpla in och utcheckning - då behöver vi ett till fält kopplat till fordon. Den här gången ska jag komma ihåg att börja med en git gren.
- Börjat titta på meny systemet och inser att Spectre Console kan förenkla koden rejält. Vill också slänga in en enumerator för menyvalen, dels för att det känns lämpligt men också så jag lär mig hur de fungerar.

## 25/10
Jag kan gå in i huvudmenyn, komma vidare till välja fordonmenyn och sen komma tillbaka till huvudmenyn. Blir inte promtad för att ange regnr och ingen bil parkeras så det har vi inte kopplat ihop än. Det är nästa steg.
Testade igen och parkering sker visst, så det är löst, ska bara koppla ihop ange regnr med menyn och parkera bil. 
Har gjort en egen klass för att ange regNr men den metoden är inte anropsbar i meny klassen för att lägga in regNr, för den behöver ju ett objekt. Och istället för att ha ett registereingsnr objekt vill jag nog bara koppla det till egenskapen regNr i min fordonsklass. 

## 26/10
Det könns som att switch-case borde ligga någon annanstans än i menyerna. Oklart var bara... 
Men har fått till att menyer runt att välja fordon och ange regnr. Nu ska vi bara få ihop det med switch-case och praugeParking variabeln. 
TODO: Bryt ut switch-cases från menyklasser och lägg i program.cs for now. 
I program.cs har jag under ChooseVehicleType() 
	case "Car":
		Vehicle car = new Car();
		praugeParking.FindFirstEmptyParkingSpot(car);
där praugeParking inte är åtkombar pga reasons, och det tror jag man kanske kan komma runt om man sparar ner till en fil? så ska sätta mig in i JSON nu.

Eller så blir jag distraherad av menyn, men den är löst nu. Nu ska jag bara fixa så jag kan parkera bilar... 
okej, så när jag väljer menyval bil, så skapar jag ett ny bil objekt som jag sen vill skicka in i mitt parkeringsgarage. Men jag kommer inte åt parkeringsgaraget från min switch case meny. 
Okej, efter att ha bollat med AI föreslog den lite olika lösningar och den jag trodde mest på var att skicka med p-huset in i menyn. Och det funkade... Men hur ser jag till att den är uppdaterad och korrekt genom alla menyval?
somehow it works and I am not questioning it at this point.
Åh nej, har ju choose a vehicle switch som jag tänkt att använda för alla val, men den är ju specifikt för att lägga till in bil nu.
Okej, jag måste skicka tillbaka menyvalet från ChooseAVehicle till min main menu switch och sen gå vidare med add car eller move bicycle etc.
Eh, det blev en lösning, finns garanterat bättre sätt att lösa det på men det funkar. 
Forstätt med att försöka lösa att flytta fordon. 
Just nu försöker jag flytta ett fordon genom att skapa ett nytt fordon för att komma åt ange regnr metoden. men det är ju inte rätt, jag ska ju inte skapa ett nytt objekt, jag ska hitta ett existerande. 
Okej, har hållt på och bollat runt objekt till höger och vänster hela morgonen och jag börjar förstå tjusningen i OOP. Fattar fortfarande inte hur saker hänger ihop och sätter mycket return null; för att det funkar, gör saker till static eller return bool true för att det får det att funka men ingen aning om varför. Men det kommer hoppas jag.
Sitter med att försöka lösa size depenency i parkingsplatsern så man kan parkera olika stora fordon. 
Bollade med Stig, Linnea, AI och i Discorden och kom fram till att ha parkerade fordon som en lista i p-platsen nog var det bästa sättet att lösa det på. 
Size dependent parking är löst. Allt verkar funka med den nya implementeringen. 
När jag bollade med Stig förut använde han en Validator klass som exempel och det blir nog nästa steg för att fixera "Registreringsnumrena är alltid strängar med en maxlängd på 10 tecken". Har ju löst en del av användarvalideringen genom att alltid skicka det via Spectre Consoles Ansi.Console så den validerar ju automatiskt att man anger rätt datatyp mot vad som är specificerat. Det har jag redan testat av misstag när jag hade glömt att ändra en text att fråga om specifik siffra istället för text och jag angav text. 
Okej, jag har en validator som veriferer stränglängd på regnr etc men inget händer om man gör fel utöver ett felmeddelande. Så fixa imorgon!
if (Validator.ValidateLicencePlate(licencePlate)) return licencePlate;
            else return null; // TODO would be nice if null triggered a error message...  - 27/10: later 

## 28/10
Kom på igår kväll när jag skulle sova att vi gjorde egna exceptions i lektion 14, så ska kika på det och se om det är något sådant jag vill implementera istället.
Gav helt upp på exceptions, var slut i huvudet efter lektionen och satte mig för att fixa priser istället

## 29/10
Fortsätter med priserna, efter lite googlande och fipplande med timespan och avrundningar har vi nog en fungerande lösning, lägg på 30 min på parkedDuration så funkar avrundningen som jag vill, närmsta hela timme.
I teorin borde det funka nu. Hade gärna haft en testfunktion up and running som jag kunde testa på, så bökigt med manuella tester. 
För att lösa test tjofset måste jag först fixa file handling. Det har känts svårt och oöverskådligt men verkar också ganska lätt. 
Första hindret är dock att man inte kan deserialize abstracta klasser så Vehicle is getting un-abstracted. Det lär skapa en hel del kaskadfel dock... 
Okej, så jag gjorde egenskaperna Size, VehicleType och Price till virutal istället. Inga errors iaf. 
Testade att deserialize a vehicle nu med den nya setupen och programmet stod ju inte på näsan, men det blev ju inte ett korrekt objekt heller, de virutella egenskaperna lästes inte in.
Så jag kommer behöva veta vilken typ av fordon som ska läsas in eller ut. Men det kanske inte är ett problem iofs, iom att jag tvingar användaren att välja det i varje steg?
okej, vi är tillbaka där vi började, Vehicle är abstract och Size, VehicleType och Price är abstract med. 
Det vi behöver är en fil som styr konfigurationen av p-huset. 

Where we're at: I park cars but the information does not follow back, the spots are just set to full. The ParkedVehicle does not get filled? Or does it not follow back?
## 30/10
I have spent 2 days trying to figure this out. Apparently having no set; in the properties is a big issue when dealing with deserialization of json. So now all properties gets setters.
It is working so now we are tackling the config file. 