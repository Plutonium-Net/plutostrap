using System.Windows.Input;

using CommunityToolkit.Mvvm.Input;

namespace PlutoStrap.UI.ViewModels.Settings
{
    public class BehaviourViewModel : NotifyPropertyChangedViewModel
    {
        public string VersionsFolder => Paths.Versions;

        public ICommand OpenVersionsFolderCommand => new RelayCommand(OpenVersionsFolder);

        private static void OpenVersionsFolder()
        {
            const string LOG_IDENT = "BehaviourViewModel::OpenVersionsFolder";

            try
            {
                Directory.CreateDirectory(Paths.Versions);
                Process.Start("explorer.exe", Paths.Versions);
            }
            catch (Exception ex)
            {
                App.Logger.WriteException(LOG_IDENT, ex);
            }
        }

        public bool ConfirmLaunches
        {
            get => App.Settings.Prop.ConfirmLaunches;
            set => App.Settings.Prop.ConfirmLaunches = value;
        }

        public bool BackgroundUpdates
        {
            get => App.Settings.Prop.BackgroundUpdatesEnabled;
            set => App.Settings.Prop.BackgroundUpdatesEnabled = value;
        }

        public bool IsRobloxInstallationMissing => !App.IsPlayerInstalled && !App.IsStudioInstalled;

        public bool ForceRobloxReinstallation
        {
            get => App.State.Prop.ForceReinstall || IsRobloxInstallationMissing;
            set => App.State.Prop.ForceReinstall = value;
        }
    }
}
