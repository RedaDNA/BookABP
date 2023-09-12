using Volo.Abp.Features;

namespace Acme.BookStore
{
    public class MyFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var myGroup = context.AddGroup("MyNewApp");

            myGroup.AddFeature("MyNewApp.Reporting", defaultValue: "false");
          
        }
    }
}
