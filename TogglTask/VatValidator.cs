using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using TogglTask.VatService;

namespace TogglTask
{
    public class VatValidator : IVatValidator
    {
        private const int VatNumberMinLength = 3;
        private const string VatRegexCountryCodePattern = "[A-Z]{2}";

        private readonly checkVatService _vatService;

        public VatValidator()
        {
            _vatService = new checkVatService();
        }

        public bool Validate(string vatWithCountryCode)
        {
            if (vatWithCountryCode.Length < VatNumberMinLength)
            {
                return false;
            }

            var regexCountryCode = new Regex(VatRegexCountryCodePattern);
            var countryCodeMatch = regexCountryCode.Match(vatWithCountryCode);

            if (!countryCodeMatch.Success)
            {
                return false;
            }

            var vatNumber = vatWithCountryCode.Substring(2);

            return Validate(countryCodeMatch.Value, vatNumber);
        }

        private bool Validate(string countryCode, string vatNumber)
        {
            string address;
            string name;
            bool valid;
            _vatService.checkVat(ref countryCode, ref vatNumber, out valid, out name, out address);

            return valid;
        }
    }
}
