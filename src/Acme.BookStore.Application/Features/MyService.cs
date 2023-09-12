using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.FeatureManagement;

namespace Acme.BookStore.Features
{
    public class MyService : ITransientDependency
    {
        private readonly IFeatureManager _featureManager;

        public MyService(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }
        public async Task EnablePdfReporting(Guid tenantId)
        {
            await _featureManager.SetForTenantAsync(
                tenantId,
                "MyApp.PdfReporting",
                true.ToString()
            );
        }
    }
}
