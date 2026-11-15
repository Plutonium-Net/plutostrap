using PlutoStrap.UI.ViewModels.Settings;

namespace PlutoStrap.UI.Elements.Settings.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage
    {
        public HomePage()
        {
            DataContext = new HomeViewModel();
            InitializeComponent();
        }
    }
}
