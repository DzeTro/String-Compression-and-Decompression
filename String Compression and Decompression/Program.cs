using System.Text;

namespace CompressDecompress
{
    public class Programm
    {
        static void Main(string[] args)
        {
            // Haupteinstigspunkt

            // Eingabe
            Console.WriteLine("Bitte die Buchstaben eingeben: ");
            string eingabeString = Console.ReadLine();
            var ausgabeString = string.Empty;
            var isComporessed = eingabeString.Contains(ComporessionChar);
            if (isComporessed)
            {
                // Compression
                ausgabeString = Decompress(eingabeString);
            }
            else
            {
                ausgabeString = Compression(eingabeString);
            }
            // Asugabe
            Console.WriteLine(ausgabeString);
            Console.ReadKey();

        }

        public static char ComporessionChar { get => '§'; }

        public static string Compression(string plainText)
        {

            char[] bildDaten = plainText.ToCharArray();

            // char [] kompromierteDaten = new char [0];
            string compressedString = String.Empty;
            int index = 0;
            int i = 0;

            while (index < bildDaten.Length)
            {
                int anzahl = 0;
                i = index;
                while (i < bildDaten.Length && bildDaten[i] == bildDaten[index])
                {
                    i++;
                    anzahl++;
                }

                if (anzahl > 3)
                {
                    compressedString += ComporessionChar;
                    compressedString += anzahl.ToString();
                    compressedString += bildDaten[index].ToString();
                    index = index + anzahl;
                }
                else
                {
                    i = 0;
                    while (i < anzahl)
                    {
                        compressedString += bildDaten[index];
                        i++;
                    }
                    index = index + anzahl;
                }
            }

            return compressedString;
        }

        public static string Decompress(string compressedString)
        {
            string decompressedString = string.Empty;
            int index = 0;

            while (index < compressedString.Length)
            {
                if (compressedString[index] == ComporessionChar)
                {
                    index++;
                    var tempAnzahl = string.Empty;
                    while (int.TryParse(compressedString[index].ToString(), out int zahl))
                    {
                        tempAnzahl += zahl;
                        index++;
                    }
                    if (int.TryParse(tempAnzahl, out int repeat))
                    {
                        var zeichen = compressedString[index].ToString();
                        for (int i = 0; i < repeat; i++)
                        {
                            decompressedString += zeichen;
                        }
                    }
                }
                else
                {
                    var zeichen = compressedString[index].ToString();
                    decompressedString += zeichen;
                }
                index++;
            }
            return decompressedString;
        }
    }
}