using BareMvvm.Core.App;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using ToolsPortable;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace PowerPlannerUno.Shared.Interfaces
{
    public abstract class NativeUnoApplication : Application
    {
        public NativeUnoApplication()
        {
            // Register the view model to view mappings
            foreach (var mapping in GetViewModelToViewMappings())
            {
                ViewModelToViewConverter.AddMapping(mapping.Key, mapping.Value);
            }

            // Register the obtain dispatcher function
            PortableDispatcher.ObtainDispatcherFunction = () => { return new UnoDispatcher(); };

            // Register message dialog
            PortableMessageDialog.Extension = UnoMessageDialog.ShowAsync;

            PortableLocalizedResources.CultureExtension = GetCultureInfo;

            // Initialize the app
            PortableApp.InitializeAsync((PortableApp)Activator.CreateInstance(GetPortableAppType()));
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            OnLaunchedOrActivated(args);
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            OnLaunchedOrActivated(args);
        }

        private async void MyOnLaunchedOrActivated(IActivatedEventArgs args)
        {
            try
            {
                await PortableApp.InitializeTask;
                await OnLaunchedOrActivated(args);
            }

            catch
            {
            }
        }

        protected abstract Task OnLaunchedOrActivated(IActivatedEventArgs args);

        public abstract Dictionary<Type, Type> GetViewModelToViewMappings();

        public abstract Type GetPortableAppType();

        private CultureInfo GetCultureInfo()
        {
            return CultureInfo.CurrentCulture;
        }
    }
}
