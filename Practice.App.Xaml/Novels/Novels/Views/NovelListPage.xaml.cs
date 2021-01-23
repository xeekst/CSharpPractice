using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Novels.Models;
using Xamarin.Forms;

namespace Novels.Views
{
    public partial class NovelListPage : ContentPage
    {
        public ObservableCollection<NovelListItemViewModel> NovelItems { get; set; }

        public NovelListPage()
        {
            InitializeComponent();
            NovelItems = new ObservableCollection<NovelListItemViewModel>();
            NovelItems.Add(new NovelListItemViewModel()
            {
                Author = "苗炜",
                Title = "《文学体验三十讲》",
                Language = "中",
                IconSource = "https://img2.doubanio.com/view/subject/l/public/s33769653.jpg"

            }) ;
            //listView.ItemsSource = NovelItems;
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

        void listView_Scrolled(System.Object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
        }
    }
}
