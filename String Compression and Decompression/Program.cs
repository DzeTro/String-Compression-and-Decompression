using System.Text;

string KompromierteDaten = "";
int anzahl = 0;
int index = 0;
int i = 0;


Console.WriteLine("Bitte die Buchstaben eingeben: ");
string BildDaten = Console.ReadLine();

while (index < BilDaten.GetLenght())
{
    anzahl = 0;
    i = index;
    while (i < BildDaten.GetLenght() && BildDaten[i] == BildDaten[index])
    {
        i = i++;
        anzahl = anzahl++;
    }
}

if (anzahl > 3)
{
    KompromierteDaten.Add("§");
    KompromierteDaten.Add(anzahl);
    KompromierteDaten.Add(BildDaten[index]);
    index = index + anzahl;
}
else
{
    i = 0;
    while (i < anzahl)
    {
        KompromierteDaten.Add(BildDaten[index]);
        i = i++;
    }
    index = index + anzahl;
}