using System.Windows;
using System.Windows.Input;

using CommunityToolkit.Mvvm.Input;

using PlutoStrap.UI.Elements.Settings;
using PlutoStrap.UI.Elements.Settings.Pages;

namespace PlutoStrap.UI.ViewModels.Settings
{
    public class HomeViewModel : NotifyPropertyChangedViewModel
    {
        public string Version => String.Format(Strings.Menu_About_Version, App.Version);

        public string PlayerStatus => GetStatus(false);

        public string StudioStatus => GetStatus(true);

        public string InstallLocation => Paths.Base;

        public ICommand LaunchPlayerCommand => new RelayCommand(() => Launch(false));

        public ICommand LaunchStudioCommand => new RelayCommand(() => Launch(true));

        public ICommand OpenInstallFolderCommand => new RelayCommand(OpenInstallFolder);

        public ICommand OpenModsCommand => new RelayCommand(() => Navigate(typeof(ModsPage)));

        public ICommand OpenFastFlagsCommand => new RelayCommand(() => Navigate(typeof(FastFlagsPage)));

        public ICommand OpenIntegrationsCommand => new RelayCommand(() => Navigate(typeof(IntegrationsPage)));

        public ICommand OpenAppearanceCommand => new RelayCommand(() => Navigate(typeof(AppearancePage)));

        public ICommand OpenAdvancedCommand => new RelayCommand(() => Navigate(typeof(AdvancedPage)));

        private static string GetStatus(bool studio)
        {
            bool installed = studio ? App.IsStudioInstalled : App.IsPlayerInstalled;

            if (!installed)
                return Strings.Home_NotInstalled;

            string version = Utilities.GetRobloxVersionStr(studio);

            return String.IsNullOrEmpty(version) ? Strings.Home_Installed : String.Format(Strings.Home_VersionFormat, version);
        }

        private static void Launch(bool studio)
        {
            const string LOG_IDENT = "HomeViewModel::Launch";

            if (!File.Exists(Paths.Application))
            {
                Frontend.ShowMessageBox(Strings.Home_LaunchFailed, MessageBoxImage.Error);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Paths.Application,
                    Arguments = studio ? "-studio" : "-player",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                App.Logger.WriteException(LOG_IDENT, ex);
                Frontend.ShowMessageBox($"{Strings.Home_LaunchFailed}\n\n{ex.Message}", MessageBoxImage.Error);
            }
        }

        private static void OpenInstallFolder()
        {
            const string LOG_IDENT = "HomeViewModel::OpenInstallFolder";

            try
            {
                Process.Start("explorer.exe", Paths.Base);
            }
            catch (Exception ex)
            {
                App.Logger.WriteException(LOG_IDENT, ex);
            }
        }

        private static void Navigate(Type pageType) => MainWindow.ActiveWindow?.Navigate(pageType);
    }
}
