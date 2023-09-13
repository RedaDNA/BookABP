using Acme.BookStore.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.FeatureManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Acme.BookStore.Features
{   
    public class MyService : BookStoreAppService, ITransientDependency
    {
        private readonly IFeatureManager _featureManager;
        private readonly ISettingProvider _settingProvider;
        private readonly ISettingManager _settingManager;


        public MyService(IFeatureManager featureManager, ISettingProvider settingProvider
            , ISettingManager settingManager)
        {
            _featureManager = featureManager;
            _settingProvider = settingProvider;
            _settingManager= settingManager;
    }
         
        public async Task EnablePdfReporting(Guid tenantId)
        {
            await _featureManager.SetForTenantAsync(
                tenantId,
                "ApplicationFeatures.NewFeature",
                true.ToString()
            );
        }
        public async Task<int> GetMaxBookCountAsync()
        {
            //Get a value as string.
            string MaxBooksNumber = await _settingProvider.GetOrNullAsync(BookStoreSettings.MaxBookCount);
            if (int.TryParse(MaxBooksNumber, out int maxBooksPerAuthor))
            {
                return maxBooksPerAuthor;
            }
            return -1;
            }
        public async Task<int> GetMaxBookCountSettingManagerAsync()
        {
            //Get a value as string.
          //  var value1 = await _settingManager.GetSettingValueAsync<bool>("PassiveUsersCanNotLogin");

            string MaxBooksNumber = await _settingManager.GetOrNullGlobalAsync(  BookStoreSettings.MaxBookCount);
            if (int.TryParse(MaxBooksNumber, out int maxBooksPerAuthor))
            {
                return maxBooksPerAuthor;
            }
            return -1;
        }
        public async Task SetMaxBookCountAsync(String newMaxCountValue)
        {
            //Get a value as string.
          _settingManager.SetGlobalAsync(BookStoreSettings.MaxBookCount, newMaxCountValue);
           
        }
        public async Task SetMaxBookCountForTenantAsync(String newMaxCountValue,Guid tenantId)
        {
            //Get a value as string.
            _settingManager.SetForTenantAsync(tenantId, BookStoreSettings.MaxBookCount, newMaxCountValue);

        }

        /*
        public async Task<String> FooAsync()
        {
            //Get a value as string.
            string MaxBooksNumber = await _settingProvider.(BookStoreSettings.MaxBookCount);
            return MaxBooksNumber;

        }
        */
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
