using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace Acme.BookStore
{
    public class MyFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var myGroup = context.AddGroup("MyApp");

            myGroup.AddFeature(
                "MyApp.PdfReporting",
                defaultValue: "false",
                displayName: LocalizableString
                                 .Create<LocalizationResource>("PdfReporting"),
                valueType: new ToggleStringValueType()
            );

            myGroup.AddFeature(
                "MyApp.MaxProductCount",
                defaultValue: "10",
                displayName: LocalizableString
                                 .Create<LocalizationResource>("MaxProductCount"),
                valueType: new FreeTextStringValueType(
                               new NumericValueValidator(0, 1000000))
            );
        }
    }
}
