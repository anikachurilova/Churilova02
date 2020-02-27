using System.Windows.Controls;
using Churilova02.ViewModels;

namespace Churilova02.Views
{
    /// <summary>
    /// Interaction logic for ViewControl.xaml
    /// </summary>
    public partial class ViewControl : UserControl
    {
        public ViewControl()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
        }
    }
}
