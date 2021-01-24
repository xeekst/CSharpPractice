using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Novels.Models;
using Xamarin.Forms;

namespace Novels.Views
{
    public partial class NovelListPage : ContentPage
    {
        public ObservableCollection<NovelListItemViewModel> NovelItems { get; set; }
        private bool _isLoadData = false;

        public NovelListPage()
        {
            InitializeComponent();
            NovelItems = new ObservableCollection<NovelListItemViewModel>();
            listView.ItemsSource = NovelItems;
            InitData();
        }

        private void InitData()
        {
            for (int i = 0; i < 5; i++)
            {
                NovelItems.Add(new NovelListItemViewModel()
                {
                    Author = "苗炜",
                    Title = "《文学体验三十讲》",
                    Language = "中",
                    IconSource = "https://img2.doubanio.com/view/subject/l/public/s33769653.jpg"
                });
                NovelItems.Add(new NovelListItemViewModel()
                {
                    Title = "《阿兰的初恋》",
                    Author = "作者: [法] 埃曼努埃尔·吉贝尔",
                    IconSource = "https://img2.doubanio.com/view/subject/l/public/s33783223.jpg",
                    Language = "法"
                });
            }
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

        /// <summary>
        /// 滚动到了底部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ScrollView_Scrolled(System.Object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
            ScrollView scrollView = sender as ScrollView;
            double scrollingSpace = scrollView.Content.Height - scrollView.Height;

            if (scrollingSpace <= e.ScrollY && !_isLoadData)
            {
                //DisplayAlert("Info", e.ScrollY.ToString(), "OK");
                AddData();
            }
             
        }
        void AddData()
        {
            _isLoadData = true;
            for (int i = 0; i < 1; i++)
            {
                NovelItems.Add(new NovelListItemViewModel()
                {
                    Author = "苗炜3",
                    Title = "《文学体验三十讲》",
                    Language = "中",
                    IconSource = "https://img2.doubanio.com/view/subject/l/public/s33769653.jpg"
                });
                NovelItems.Add(new NovelListItemViewModel()
                {
                    Title = "《阿兰的初恋》3",
                    Author = "作者: [法] 埃曼努埃尔·吉贝尔",
                    IconSource = "https://img2.doubanio.com/view/subject/l/public/s33783223.jpg",
                    Language = "法"
                });
            }
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(3000);
                _isLoadData = false;
            });
        }
    }
}
