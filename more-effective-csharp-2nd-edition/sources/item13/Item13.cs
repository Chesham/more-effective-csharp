using System;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("more-effective-csharp-2nd-edition")]

namespace item13
{
    public class PhoneValidator
    {
        public bool ValidareNumber(string PhoneNumber)
        {
            if (PhoneNumber.Length == 10)
                return true;
            else
                return false;
        }

        public IPhoneValidator CreatValidator(PhoneTypes type)
        {
            switch (type)
            {
                case PhoneTypes.TW:
                    return new TWPhoneValidator();
                case PhoneTypes.US:
                    return new InternationalPhoneValidator();
                case PhoneTypes.Unknown:
                default:
                    return new InternationalPhoneValidator();
            }
        }
    }

    public enum PhoneTypes
    {
        TW,
        US,
        Unknown
    }

    public interface IPhoneValidator
    {
        bool ValidareNumber(string PhoneNumber);
    }

    internal class TWPhoneValidator : IPhoneValidator
    {
        public bool ValidareNumber(string PhoneNumber)
        {
            if (PhoneNumber.Length == 10)
                return true;
            else
                return false;
        }
    }

    internal class InternationalPhoneValidator : IPhoneValidator
    {
        public bool ValidareNumber(string PhoneNumber)
        {
            if (PhoneNumber.Length == 12)
                return true;
            else
                return false;
        }
    }
}
