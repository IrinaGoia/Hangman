using System;
using System.Diagnostics;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Programmieren Sie das Spiel Hangman in einer Konsolenanwendung. Erstellen Sie hierzu eine Liste mit min. 5 Wörtern, aus dieser Liste soll via Zufallszahl eines der Wörter ausgewählt werden welches dann vom benutzer erraten werden muss.
            Dem User werden _ oder * für jedes Zeichen im wort angezeigt, errät er ein zeichen soll das entsprechende Zeichen als buchstabe angezeigt werden, der rest des wortes weiterhin als * oder _ . Hat der User das Wort nach 8 Versuchen nicht erraten, gilt das Spiel als verloren.
            Es reicht aus hier einen Zähler anzuzeigen, das Galgenmännchen muss nicht Grafisch dargestellt werden. Zusatzaufgabe: Stellen Sie das Galgenmännchen Grafisch als ASCII zeichnung dar =)*/

            string[] hangman = new string[9];
            hangman[0] = "               |              ";
            hangman[1] = "               |              ";
            hangman[2] = "               |              ";
            hangman[3] = "               O              ";
            hangman[4] = "              /|\\            ";
            hangman[5] = "               |              ";
            hangman[6] = "               |              ";
            hangman[7] = "              / \\            ";
            hangman[8] = "           GAME OVER          ";


            string[] wörterliste = new string[10];
            wörterliste[0] = "ort";
            wörterliste[1] = "ei";
            wörterliste[2] = "computer";
            wörterliste[3] = "lied";
            wörterliste[4] = "apfel";
            wörterliste[5] = "auto";
            wörterliste[6] = "stift";
            wörterliste[7] = "hund";
            wörterliste[8] = "schule";
            wörterliste[9] = "katze";
            Random rand = new Random();
            int i = rand.Next(0, 9);
            string wort = wörterliste[i];
            char[] buchstabe = new char[wort.Length];
            int fehlerZahl = 0;


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("******************************");
            Console.WriteLine("            HANGMAN           ");
            Console.WriteLine("******************************");

            for (int b = 0; b < wort.Length; b++)
            {
                buchstabe[b] = '*';
            }

            while (true)
            {
                bool richtigeBuchstabe = false;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Bitte eine Buchstabe eingeben");
                Console.WriteLine("******************************");

                char playerGuess = Convert.ToChar(Console.ReadLine().ToLower());

                for (int j = 0; j < wort.Length; j++) //проверяет, есть ли такая буква
                {
                    if (playerGuess == wort[j])
                    {
                        buchstabe[j] = playerGuess;
                        richtigeBuchstabe = true;     //такая буква есть
                    }
                }
               

                if (richtigeBuchstabe)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("******************************");
                    Console.WriteLine("            HANGMAN           ");
                    Console.WriteLine("******************************");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(buchstabe);
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("***      Ja! Richtig!     ***");
                    Console.ResetColor();
                    Console.WriteLine("");
                    string buchStr = new string(buchstabe);
                    if (buchStr == wort)             // сравнивает всё слово
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("******************************");
                        Console.WriteLine("***    Du hast gewonnen    ***");
                        Console.WriteLine("***                        ***");
                        Console.WriteLine("***  press any key to Exit ***");
                        Console.WriteLine("******************************");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    }
                }
                else // не угадали букву
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("******************************");
                    Console.WriteLine("            HANGMAN           ");
                    Console.WriteLine("******************************");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(buchstabe);
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Der Buchstabe ist nicht erraten");
                    Console.ResetColor();

                    fehlerZahl++;   

                    if (fehlerZahl > 7) //по колличесву ошибок узнаёт, что игра закончена
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int k = 0; k < 9; k++) //рисует чел GAME OVER
                        {
                            Console.WriteLine(hangman[k]);
                        }

                        Console.WriteLine("");
                        Console.WriteLine("******************************");
                        Console.WriteLine("*** press any key to Exit  ***");
                        Console.WriteLine("******************************");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    }
                }
                for (int k = 0; k < fehlerZahl; k++) //рисует часть чел
                {
                    Console.WriteLine(hangman[k]);
                }
                for (int k = fehlerZahl; k < 9; k++) // пустые строчки под чел
                {
               
                    Console.WriteLine("");
                }

            }


            Environment.Exit(0);



        }
    }
}
