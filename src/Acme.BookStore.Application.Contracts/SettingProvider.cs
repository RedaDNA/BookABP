using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Settings;

namespace Acme.BookStore
{
    public class SettingProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition("MaxBooksNumber", "5"));
        }
    }
}