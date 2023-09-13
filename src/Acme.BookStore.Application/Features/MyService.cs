using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Settings;

namespace Acme.BookStore.Features
{   
    public class MyService : BookStoreAppService, ITransientDependency
    {
        private readonly IFeatureManager _featureManager;
        private readonly ISettingProvider _settingProvider;


        public MyService(IFeatureManager featureManager, ISettingProvider settingProvider)
        {
            _featureManager = featureManager;
            _settingProvider = settingProvider;
        
    }
         
        public async Task EnablePdfReporting(Guid tenantId)
        {
            await _featureManager.SetForTenantAsync(
                tenantId,
                "ApplicationFeatures.NewFeature",
                true.ToString()
            );
        }
        public async Task<String> FooAsync()
        {
            //Get a value as string.
            string MaxBooksNumber = await _settingProvider.GetOrNullAsync("MaxBooksNumber");
            return MaxBooksNumber;

            }

            public async Task test(Guid tenantId)
        {
            
            await _featureManager.SetForTenantAsync(
                tenantId,
                "ApplicationFeatures.NewFeature",
                true.ToString()
            );
            
        }
         
    }
}
