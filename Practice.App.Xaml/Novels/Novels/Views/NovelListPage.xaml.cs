using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Novels.Views
{
    public partial class NovelListPage : ContentPage
    {
        public NovelListPage()
        {
            InitializeComponent();
            listView.ItemsSource = new[] { "a", "b", "c" };
        }

        void OnItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
            DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        void OnCellClicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
