using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Novels.Models;
using Xamarin.Forms;

namespace Novels.Views
{
    public partial class LeftMenuPage : ContentPage
    {
        public LeftMenuPage()
        {
            InitializeComponent();
            
            //DisplayAlert("Alert", "You have been alerted", "OK");
        }

        void Image_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
        }

        async void Label_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
            string action = await DisplayActionSheet("ActionSheet: SavePhoto?", "Cancel", "Delete", "Photo Roll", "Email");
            //Debug.WriteLine("Action: " + action);
        }
    }
}
