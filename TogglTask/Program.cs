using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace TogglTask
{
    class Program
    {
        private static readonly IVatValidator VatValidator = new VatValidator();

        public static void Main(string[] args)
        {
            string inputVat;
            if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                Console.Write("Enter VAT in order to validate: ");
                inputVat = Console.ReadLine();
            }
            else
            {
                inputVat = args[0];
            }

            try
            {
                if (VatValidator.Validate(inputVat))
                {
                    Console.WriteLine("Valid");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
            catch (SoapException)
            {
                Console.WriteLine("Exception/error");
            }
        }
    }
}
