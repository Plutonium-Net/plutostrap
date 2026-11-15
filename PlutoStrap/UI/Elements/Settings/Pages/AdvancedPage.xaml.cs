using PlutoStrap.UI.ViewModels.Settings;

namespace PlutoStrap.UI.Elements.Settings.Pages
{
    /// <summary>
    /// Interaction logic for AdvancedPage.xaml
    /// </summary>
    public partial class AdvancedPage
    {
        public AdvancedPage()
        {
            DataContext = new AdvancedViewModel();
            InitializeComponent();
        }
    }
}
