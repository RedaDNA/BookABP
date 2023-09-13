
using Volo.Abp.Settings;
using Volo.Abp.Localization;

namespace Acme.BookStore.Settings;
 
public class BookStoreSettingDefinitionProvider : SettingDefinitionProvider
{
    public const int DefaultMaxBooksPerAuthor = 5;
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookStoreSettings.MySetting1));
        /*  context.Add(
              new SettingDefinition("Smtp.Host", "127.0.0.1"),
              new SettingDefinition("Smtp.Port", "25"),
              new SettingDefinition("Smtp.UserName"),
              new SettingDefinition("Smtp.Password", isEncrypted: true),
              new SettingDefinition("Smtp.EnableSsl", "false")
          );
        
            
        {
            var maxBooksPerAuthorSetting = context.GetOrNull("App.Author.MaxBooks");
            if (maxBooksPerAuthorSetting == null)
            {
                maxBooksPerAuthorSetting = new SettingDefinition(
                    name: "App.Author.MaxBooks",
                    defaultValue: DefaultMaxBooksPerAuthor.ToString(),
                      //displayName: new LocalizableString.Create<LocalizationResource>("MaxBooksPerAuthorCount")
                      displayName: LocalizableString
                                 .Create<LocalizationResource>("MaxBooksPerAuthorCount")

                 );

                context.Add(maxBooksPerAuthorSetting);
            }
        }*/
    }



}
