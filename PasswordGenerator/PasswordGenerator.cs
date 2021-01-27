using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {
        // Instantiering af classer
        Random rnd = new Random();
        PasswordLength passwordLength = new PasswordLength();

        // Arrays til password
        string[] talArray = new string[] { "1", "2","3", "4", "5", "6", "7", "8", "9", "0"};
        string[] uppercaseArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string[] lowercaseArray = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        string[] specialArray = new string[] {"!","@","#","$","€","&"};

        // List hvor jeg gemmer alle værdierne til passwordet
        List<string> GeneratedPasword = new List<string>();

        // Her kalder jeg på alle metoderne til programmet 
        public void PasswordGenerateStart()
        {
            NumberOfCharacters();
            NumberOfNumbers();
            NumberOfSpecials();
            NumberOfUppercase();
            NumberOfLowercase();
        }

        // Indtast ønskede længde til passwordet
        public void NumberOfCharacters()
        {
            Console.WriteLine("Indtast det ønskede længde af kodeordet");
            passwordLength.pwLength = Convert.ToInt32(Console.ReadLine());
        }

        // Indtast antal tal til passwordet
        public void NumberOfNumbers()
        {
            Console.Clear();
            string passwordTal = "";
            int passwordTal2int = 0;
            bool isInt = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Du har {0} karakter tilbage at bruge på kodeordet ud fra dit valgte længde\n", passwordLength.pwLength);
                Console.WriteLine("Hvor mange tal vil du have i koden?");
                passwordTal = Console.ReadLine();
                isInt = int.TryParse(passwordTal, out passwordTal2int);
            }
            while (!isInt);
            
            if(passwordTal2int > passwordLength.pwLength)
            {
                NumberOfNumbers();
            }
            else if (passwordTal2int == passwordLength.pwLength)
            {
                Console.Clear();
                Console.WriteLine("Dit kodeord er:\n");
                for(int i = 0; i < passwordTal2int; i++)
                {
                    int randomTal = rnd.Next(1, 10);
                    Console.Write(talArray[randomTal]);
                }
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                for (int i = 0; i < passwordTal2int; i++)
                {
                    int randomTal = rnd.Next(0, 10);
                    GeneratedPasword.Add(talArray[randomTal]);
                }
            }
            passwordLength.pwLength -= passwordTal2int;

            Console.WriteLine("Du har valgt {0} tal du har nu {1} karakter tilbage\n", passwordTal, passwordLength.pwLength);
        }

        // Indtast antal speciele tegn til passwordet
        public void NumberOfSpecials()
        {
            string passwordSpecialtegn = "";
            int passwordSpecialtegn2int = 0;
            bool isInt1 = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Du har {0} karakter tilbage at bruge på kodeordet ud fra dit valgte længde\n", passwordLength.pwLength);
                Console.WriteLine("Hvor mange Special tegn vil du have i koden?");
                passwordSpecialtegn = Console.ReadLine();
                isInt1 = int.TryParse(passwordSpecialtegn, out passwordSpecialtegn2int);
            }
            while (!isInt1);


            if (passwordSpecialtegn2int > passwordLength.pwLength)
            {
                NumberOfSpecials();
            }
            else if (passwordSpecialtegn2int == passwordLength.pwLength)
            {
                Console.Clear();
                for (int e = 0; e < passwordSpecialtegn2int; e++)
                {
                    int randomTal = rnd.Next(1, 6);
                    GeneratedPasword.Add(specialArray[randomTal]);
                }
                var shuffled = GeneratedPasword.OrderBy(x => Guid.NewGuid()).ToList();
                Console.WriteLine("Dit kodeord er:\n");
                foreach (string e in shuffled)
                {
                    Console.Write(e);
                }
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                for (int e = 0; e < passwordSpecialtegn2int; e++)
                {
                    int randomTal = rnd.Next(1, 6);
                    GeneratedPasword.Add(specialArray[randomTal]);
                }
            }
            passwordLength.pwLength -= passwordSpecialtegn2int;
            Console.WriteLine("Du har valgt {0} Special tegn du har nu {1} karakter tilbage\n", passwordSpecialtegn2int, passwordLength.pwLength);
        }

        // Indtast antal Store bogstaver til passwordet
        public void NumberOfUppercase()
        {
            string passwordStorbogstav = "";
            int passwordStorbogstav2int = 0;
            bool isInt2 = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Du har {0} karakter tilbage at bruge på kodeordet ud fra dit valgte længde\n", passwordLength.pwLength);
                Console.WriteLine("Hvor mange Store bogstaver vil du have i koden?");
                passwordStorbogstav = Console.ReadLine();
                isInt2 = int.TryParse(passwordStorbogstav, out passwordStorbogstav2int);
            }
            while (!isInt2);



            if (passwordStorbogstav2int > passwordLength.pwLength)
            {
                NumberOfUppercase();
            }
            else if (passwordStorbogstav2int == passwordLength.pwLength)
            {
                Console.Clear();
                for (int c = 0; c < passwordStorbogstav2int; c++)
                {
                    int randomTal = rnd.Next(1, 26);
                    GeneratedPasword.Add(uppercaseArray[randomTal]);
                }
                var shuffled = GeneratedPasword.OrderBy(x => Guid.NewGuid()).ToList();
                Console.WriteLine("Dit kodeord er:\n");
                foreach (string e in shuffled)
                {
                    Console.Write(e);
                }
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                for (int c = 0; c < passwordStorbogstav2int; c++)
                {
                    int randomTal = rnd.Next(1, 26);
                    GeneratedPasword.Add(uppercaseArray[randomTal]);
                }
            }
            passwordLength.pwLength -= passwordStorbogstav2int;
            Console.WriteLine("Du har valgt {0} Store bogstaver du har nu {1} karakter tilbage", passwordStorbogstav, passwordLength.pwLength);
        }


        // Tager de resterende pladser og laver dem om til Lille bogstaver
        public void NumberOfLowercase()
        {
            Console.Clear();
            Console.WriteLine("Dine resterende karaktere er nu blevet lavet om til Lille bogstaver\n");
            Console.WriteLine("Dit kodeord er:\n");
            if(passwordLength.pwLength > 0)
            {
                for (int c = 0; c < passwordLength.pwLength; c++)
                {
                    int randomTal = rnd.Next(1, 26);
                    GeneratedPasword.Add(lowercaseArray[randomTal]);
                }
                var shuffled = GeneratedPasword.OrderBy(x => Guid.NewGuid()).ToList();
                foreach (string e in shuffled)
                {
                    Console.Write(e);
                }
                Console.ReadLine();
            }
        }
    }
}
