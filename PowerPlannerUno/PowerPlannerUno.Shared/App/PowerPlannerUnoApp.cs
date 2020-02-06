using BareMvvm.Core.App;
using PowerPlannerAppDataLibrary.App;
using PowerPlannerAppDataLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace PowerPlannerUno.Shared.App
{
    public class PowerPlannerUnoApp : PowerPlannerApp
    {
        public PowerPlannerUnoApp()
        {
            // Use popup style for configuring class grades
            PowerPlannerAppDataLibrary.ViewModels.MainWindow.Settings.Grades.ConfigureClassGradesViewModel.UsePopups = true;

            PowerPlannerAppDataLibrary.SyncLayer.SyncExtensions.GetAppName = delegate { return "Power Planner for Windows 10"; };
            PowerPlannerAppDataLibrary.SyncLayer.SyncExtensions.GetPlatform = delegate
            {
                return "Windows 10";
            };
        }

        public static new PowerPlannerUnoApp Current
        {
            get { return PortableApp.Current as PowerPlannerUnoApp; }
        }

        protected override async Task InitializeAsyncOverride()
        {
            //InitializeUWP.Initialize();

            // Extensions are registered with InitializeUWP.Initialize, since they're also needed from the background task

            try
            {
                try
                {
                    //await BackgroundExecutionManager.RequestAccessAsync();
                }

                catch (Exception ex)
                {
                    TelemetryExtension.Current?.TrackException(ex);
                }
            }
            catch (Exception ex)
            {
                TelemetryExtension.Current?.TrackException(ex);
            }

            await base.InitializeAsyncOverride();
        }
    }
}
