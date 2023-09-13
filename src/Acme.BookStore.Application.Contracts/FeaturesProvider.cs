using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Features;

namespace Acme.BookStore
{
    public class FeaturesProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var myGroup = context.AddGroup("ApplicationFeatures");

            myGroup.AddFeature("ApplicationFeatures.NewFeature",defaultValue: "false");
        }
    }
}
