using System;
using System.Collections.Generic;
using Novels.Models;
using Xamarin.Forms;

namespace Novels.Views
{
    public partial class NovelDetailPage : ContentPage
    {
        private NovelDetailViewModel _novel;

        public NovelDetailPage(NovelDetailViewModel novel)
        {
            InitializeComponent();
            //TODO 后台获取
            _novel = novel;
        }
    }
}
