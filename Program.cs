namespace Invoice
{
   class Program
   {
      public static void Main(string[] args)
      {

         int invoice;
         bool isContinue = true;

         while (isContinue)
         {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine($"{"GENERATE INVOICE",28}");
            Console.WriteLine("=======================================");

            Console.Write("\nMasukan Invoice: ");
            while (!Int32.TryParse(Console.ReadLine(), out invoice))
               Console.Write("Invalid input! Masukan invoice berupa angka: ");

            Console.WriteLine($"No Invoice: {generateInvoice(invoice)}");

            isContinue = getYesOrNo("Coba kembali");
         }
      }

      static string generateInvoice(int invoice)
      {
         DateTime date = DateTime.Now.AddDays(3);

         // get month 2 digits
         string month = Convert.ToString(date.Month);
         month = month.Length < 2 ? "0" + month : month;

         // get dayOfWeek and convert to 2 characters with uppercase
         string dayOfWeek = Convert.ToString(date.DayOfWeek).Substring(0, 2).ToUpper();

         // get day and convert to romawi
         string day = ToRoman(date.Day);

         // get year and convert to romawi
         string year = Convert.ToString(date.Year);
         string yearRoman = ToRoman(Convert.ToInt32(Convert.ToString(date.Year).Substring(2, 2)));

         // OUTPUT : INV/202203/FR/XI/XXII/10984
         string result = "INV/" + (year + month) + "/" + dayOfWeek + "/" + day + "/" + yearRoman + "/" + (invoice + 1);

         return result;
      }

      static string ToRoman(int number)
      {
         if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
         if (number < 1) return string.Empty;
         if (number >= 1000) return "M" + ToRoman(number - 1000);
         if (number >= 900) return "CM" + ToRoman(number - 900);
         if (number >= 500) return "D" + ToRoman(number - 500);
         if (number >= 400) return "CD" + ToRoman(number - 400);
         if (number >= 100) return "C" + ToRoman(number - 100);
         if (number >= 90) return "XC" + ToRoman(number - 90);
         if (number >= 50) return "L" + ToRoman(number - 50);
         if (number >= 40) return "XL" + ToRoman(number - 40);
         if (number >= 10) return "X" + ToRoman(number - 10);
         if (number >= 9) return "IX" + ToRoman(number - 9);
         if (number >= 5) return "V" + ToRoman(number - 5);
         if (number >= 4) return "IV" + ToRoman(number - 4);
         if (number >= 1) return "I" + ToRoman(number - 1);
         throw new ArgumentOutOfRangeException("something bad happened");
      }

      static bool getYesOrNo(string message)
      {
         Console.Write($"\n{message} (y/n) : ");
         string? pilihanUser = Console.ReadLine();
         while (pilihanUser != "y" && pilihanUser != "n")
         {
            Console.WriteLine("Pilihan anda bukan y atau n");
            Console.Write($"\n{message} (y/n) : ");
            pilihanUser = Console.ReadLine();
         }
         return pilihanUser.Equals("y");

      }
   }
}