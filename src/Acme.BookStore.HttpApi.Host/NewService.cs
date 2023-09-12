using System.Threading.Tasks;
using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.FeatureManagement;

namespace Acme.BookStore
{
    public class NewService : BookStoreAppService, ITransientDependency
    {
        private readonly IFeatureManager _featureManager;

        public NewService(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }
        public async Task EnablePdfReporting(Guid tenantId)
        {
            await _featureManager.SetForTenantAsync(
                tenantId,
                "MyNewApp.Reporting",
                true.ToString()
            );
        }
    } 
    
}
