namespace Acme.BookStore.Settings;

public static class BookStoreSettings
{
   
    public const int MaxBooksNumber = 5;
    private const string Prefix = "BookStore";

    public const string MaxBookCount = Prefix + ".MaxBookCount";
    //Add your own setting names here. Example:
    //public const string MySetting1 = Prefix + ".MySetting1";
}
