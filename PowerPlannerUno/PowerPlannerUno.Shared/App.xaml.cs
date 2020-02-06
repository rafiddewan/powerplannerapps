using Microsoft.Extensions.Logging;
using PowerPlannerAppDataLibrary.App;
using PowerPlannerAppDataLibrary.Extensions;
using PowerPlannerAppDataLibrary.ViewModels.MainWindow;
using PowerPlannerAppDataLibrary.ViewModels.MainWindow.MainScreen.Schedule;
using PowerPlannerAppDataLibrary.Windows;
using PowerPlannerUno.Shared.App;
using PowerPlannerUno.Shared.Interfaces;
using PowerPlannerUno.Shared.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PowerPlannerUno
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : NativeUnoApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            ConfigureFilters(global::Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory);

            this.InitializeComponent();
        }

        public override Type GetPortableAppType()
        {
            return typeof(PowerPlannerUnoApp);
        }

        public override Dictionary<Type, Type> GetViewModelToViewMappings()
        {
            return new Dictionary<Type, Type>()
            {
                // Welcome views
                //{ typeof(ExistingUserViewModel), typeof(ExistingUserView) },
                //{ typeof(ConnectAccountViewModel), typeof(ConnectAccountView) },

                // Main views
                //{ typeof(InitialSyncViewModel), typeof(InitialSyncView) },
                //{ typeof(AddClassTimeViewModel), typeof(AddClassTimeView) },
                //{ typeof(AddClassViewModel), typeof(AddClassView) },
                //{ typeof(AddGradeViewModel), typeof(AddGradeView) },
                //{ typeof(AddHolidayViewModel), typeof(AddHolidayView) },
                //{ typeof(AddHomeworkViewModel), typeof(AddHomeworkView) },
                //{ typeof(AddSemesterViewModel), typeof(AddSemesterView) },
                //{ typeof(AddYearViewModel), typeof(AddYearView) },
                //{ typeof(AgendaViewModel), typeof(AgendaView) },
                //{ typeof(CalendarViewModel), typeof(CalendarMainView) },
                //{ typeof(ClassesViewModel), typeof(ClassesView) },
                //{ typeof(ClassViewModel), typeof(ClassView) },
                //{ typeof(ClassWhatIfViewModel), typeof(ClassWhatIfView) },
                //{ typeof(CreateAccountViewModel), typeof(CreateAccountView) },
                //{ typeof(EditClassDetailsViewModel), typeof(EditClassDetailsView) },
                //{ typeof(ForgotUsernameViewModel), typeof(ForgotUsernameView) },
                //{ typeof(LoginViewModel), typeof(LoginView) },
                //{ typeof(DayViewModel), typeof(MainContentDayView) },
                //{ typeof(MainScreenViewModel), typeof(MainScreenView) },
                //{ typeof(PremiumVersionViewModel), typeof(PremiumVersionView) },
                //{ typeof(PromoOtherPlatformsViewModel), typeof(PromoOtherPlatformsView) },
                //{ typeof(QuickAddViewModel), typeof(QuickAddView) },
                //{ typeof(RecoveredUsernamesViewModel), typeof(RecoveredUsernamesView) },
                //{ typeof(ResetPasswordViewModel), typeof(ResetPasswordView) },
                //{ typeof(SaveGradeScaleViewModel), typeof(SaveGradeScaleView) },
                { typeof(ScheduleViewModel), typeof(ScheduleView) },
                //{ typeof(ExportSchedulePopupViewModel), typeof(ExportSchedulePopupView) },
                //{ typeof(SettingsListViewModel), typeof(SettingsListView) },
                //{ typeof(SyncErrorsViewModel), typeof(SyncErrorsView) },
                //{ typeof(UpdateCredentialsViewModel), typeof(UpdateCredentialsView) },
                //{ typeof(ViewGradeViewModel), typeof(ViewGradeView) },
                //{ typeof(ViewHomeworkViewModel), typeof(ViewHomeworkView) },
                //{ typeof(ShowImagesViewModel), typeof(ShowImagesView) },
                //{ typeof(WelcomeViewModel), typeof(WelcomeView) },
                //{ typeof(YearsViewModel), typeof(YearsView) },

                // Settings views
                //{ typeof(AboutViewModel), typeof(AboutView) },
                //{ typeof(TileSettingsViewModel), typeof(BaseSettingsSplitView) },
                //{ typeof(SyncOptionsViewModel), typeof(BaseSettingsSplitView) },
                //{ typeof(CalendarIntegrationViewModel), typeof(BaseSettingsSplitView) },
                //{ typeof(CalendarIntegrationClassesViewModel), typeof(CalendarIntegrationClassesView) },
                //{ typeof(CalendarIntegrationTasksViewModel), typeof(CalendarIntegrationTasksView) },
                //{ typeof(ChangeEmailViewModel), typeof(ChangeEmailView) },
                //{ typeof(ChangePasswordViewModel), typeof(ChangePasswordView) },
                //{ typeof(ChangeUsernameViewModel), typeof(ChangeUsernameView) },
                //{ typeof(ClassTilesViewModel), typeof(ClassTilesView) },
                //{ typeof(ClassTileViewModel), typeof(ClassTileView) },
                //{ typeof(ConfirmIdentityViewModel), typeof(ConfirmIdentityView) },
                //{ typeof(ConvertToOnlineViewModel), typeof(ConvertToOnlineView) },
                //{ typeof(DeleteAccountViewModel), typeof(DeleteAccountView) },
                //{ typeof(ImageUploadOptionsViewModel), typeof(ImageUploadOptionsView) },
                //{ typeof(MainTileViewModel), typeof(MainTileView) },
                //{ typeof(MyAccountViewModel), typeof(MyAccountView) },
                //{ typeof(PushSettingsViewModel), typeof(PushSettingsView) },
                //{ typeof(QuickAddTileViewModel), typeof(QuickAddTileView) },
                //{ typeof(ReminderSettingsViewModel), typeof(ReminderSettingsView) },
                //{ typeof(ScheduleTileViewModel), typeof(ScheduleTileView) },
                //{ typeof(TwoWeekScheduleSettingsViewModel), typeof(TwoWeekScheduleSettingsView) },
                //{ typeof(GoogleCalendarIntegrationViewModel), typeof(GoogleCalendarIntegrationView) },
                //{ typeof(ConfigureClassGradesListViewModel), typeof(ConfigureClassGradesListView) },
                //{ typeof(ConfigureClassCreditsViewModel), typeof(ConfigureClassCreditsView) },
                //{ typeof(ConfigureClassWeightCategoriesViewModel), typeof(ConfigureClassWeightCategoriesView) },
                //{ typeof(ConfigureClassGradeScaleViewModel), typeof(ConfigureClassGradeScaleView) },
                //{ typeof(ConfigureClassAverageGradesViewModel), typeof(ConfigureClassAverageGradesView) },
                //{ typeof(ConfigureClassRoundGradesUpViewModel), typeof(ConfigureClassRoundGradesUpView) },
                //{ typeof(ConfigureClassGpaTypeViewModel), typeof(ConfigureClassGpaTypeView) },
                //{ typeof(ConfigureClassPassingGradeViewModel), typeof(ConfigureClassPassingGradeView) },
                //{ typeof(PromoContributeViewModel), typeof(PromoContributeView) },
                //{ typeof(SuccessfullyCreatedAccountViewModel), typeof(SuccessfullyCreatedAccountView) }
            };
        }
        protected override async System.Threading.Tasks.Task OnLaunchedOrActivated(IActivatedEventArgs e)
        {
            try
            {
                // Wait for initialization to complete, to ensure we don't accidently add multiple windows
                // Although right now we don't even do any async tasks, so this will be useless
                await PowerPlannerApp.InitializeTask;

                MainAppWindow mainAppWindow;

                // If no windows, need to register window
                mainAppWindow = PowerPlannerApp.Current.Windows.OfType<MainAppWindow>().FirstOrDefault();
                if (mainAppWindow == null)
                {
                    // This configures the view models, does NOT call Activate yet
                    var nativeWindow = new NativeUwpAppWindow();
                    mainAppWindow = new MainAppWindow();
                    await PowerPlannerApp.Current.RegisterWindowAsync(mainAppWindow, nativeWindow);

                    //if (PowerPlannerApp.Current.Windows.Count > 1)
                    //{
                    //    throw new Exception("There are more than 1 windows registered");
                    //}
                }


                //Window.Current.Content = new TextBlock()
                //{
                //    Text = "Hello Uno",
                //    Margin = new Thickness(24)
                //};

                if (e is LaunchActivatedEventArgs)
                {
                    await HandleArguments(mainAppWindow, "");
                }

                if (mainAppWindow.GetViewModel().Content == null)
                {
                    await mainAppWindow.GetViewModel().HandleNormalLaunchActivation();
                }

                Window.Current.Activate();
            }

            catch (Exception ex)
            {
                TelemetryExtension.Current?.TrackException(ex);
            }
        }

        private static async System.Threading.Tasks.Task HandleArguments(MainAppWindow mainAppWindow, string arguments)
        {
            try
            {
                MainWindowViewModel viewModel = mainAppWindow.GetViewModel();
                
                if (viewModel.Content == null)
                {
                    await viewModel.HandleNormalLaunchActivation();
                }
            }

            catch (Exception ex)
            {
                TelemetryExtension.Current?.TrackException(ex);
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception($"Failed to load {e.SourcePageType.FullName}: {e.Exception}");
        }


        /// <summary>
        /// Configures global logging
        /// </summary>
        /// <param name="factory"></param>
        static void ConfigureFilters(ILoggerFactory factory)
        {
            factory
                .WithFilter(new FilterLoggerSettings
                    {
                        { "Uno", LogLevel.Warning },
                        { "Windows", LogLevel.Warning },

						// Debug JS interop
						// { "Uno.Foundation.WebAssemblyRuntime", LogLevel.Debug },

						// Generic Xaml events
						// { "Windows.UI.Xaml", LogLevel.Debug },
						// { "Windows.UI.Xaml.VisualStateGroup", LogLevel.Debug },
						// { "Windows.UI.Xaml.StateTriggerBase", LogLevel.Debug },
						// { "Windows.UI.Xaml.UIElement", LogLevel.Debug },

						// Layouter specific messages
						// { "Windows.UI.Xaml.Controls", LogLevel.Debug },
						// { "Windows.UI.Xaml.Controls.Layouter", LogLevel.Debug },
						// { "Windows.UI.Xaml.Controls.Panel", LogLevel.Debug },
						// { "Windows.Storage", LogLevel.Debug },

						// Binding related messages
						// { "Windows.UI.Xaml.Data", LogLevel.Debug },

						// DependencyObject memory references tracking
						// { "ReferenceHolder", LogLevel.Debug },
					}
                )
#if DEBUG
				.AddConsole(LogLevel.Debug);
#else
                .AddConsole(LogLevel.Information);
#endif
        }
    }
}
