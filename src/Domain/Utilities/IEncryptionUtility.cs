namespace LunchPicker.Domain.Utilities
{
    public interface IEncryptionUtility
    {
        string Encrypt(string toEncrypt, bool useHasing);
        string Decrypt(string toDecrypt, bool useHasing);
    }
}
