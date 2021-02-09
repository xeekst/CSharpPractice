using System;
using System.Collections.Generic;
using Novels.Models;
using Xamarin.Forms;

namespace Novels.Views
{
    public partial class NovelDetailPage : ContentPage
    {
        private NovelDetailViewModel _novel;
        public string SomeLongText { get; } = "The girl was one of those pretty and charming young creatures who sometimes are born, as if by a slip of fate, into a family of clerks. She had no dowry, no expectations, no way of being known, understood, loved, married by any rich and distinguished man; so she let herself be married to a little clerk of the Ministry of Public Instruction.";

        public NovelDetailPage(NovelDetailViewModel novel)
        {
            InitializeComponent();
            //TODO 后台获取
           
            _novel = novel;
            absLayout.BindingContext = new NovelDetailViewModel()
            {
                Title = "The Two Secret History of Janpan's",
                SubTitle="by the go??!!! btc just gogogo",
                Index = 0,
                Content = "    " + SomeLongText + SomeLongText + SomeLongText + SomeLongText
            };
            
            //label.BindingContext(Label.TextProperty,new NovelDetailContent() { Content = "advafaf"});
            //label.SetBinding(Label.TextProperty,new Binding()) = SomeLongText;
            //listView.ItemsSource = novel.Contents;
        }

        void shrinkBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            shrink.IsVisible = false;
            expland.IsVisible = true;
        }

        void explandBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            shrink.IsVisible = true;
            expland.IsVisible = false;
        }

        void prevBtn_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        void nextBtn_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
