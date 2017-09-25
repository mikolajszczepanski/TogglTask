namespace TogglTask
{
    public interface IVatValidator
    {
        bool Validate(string vatWithCountryCode);
    }
}