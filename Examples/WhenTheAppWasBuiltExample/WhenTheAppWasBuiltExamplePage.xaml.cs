using Xamarin.Forms;

namespace WhenTheAppWasBuiltExample
{
    public partial class WhenTheAppWasBuiltExamplePage : ContentPage
    {
        public WhenTheAppWasBuiltExamplePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            // You can also force the alert whenever you want!
            DevsDNA.WhenTheAppWasBuiltCore.DisplayBuildDateAlert();
        }
    }
}
