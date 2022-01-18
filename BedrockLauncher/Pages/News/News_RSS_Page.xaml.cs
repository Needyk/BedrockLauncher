﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CodeHollow.FeedReader;
using BedrockLauncher.Classes.Launcher;
using System.Diagnostics;
using BedrockLauncher.Controls.Items;
using System.Net;
using System.Net.Http;
using System.Collections.ObjectModel;
using RestSharp;
using BedrockLauncher.Pages.Common;
using Extensions.HTTP2;

namespace BedrockLauncher.Pages.News
{
    /// <summary>
    /// Interaction logic for News_RSS_Page.xaml
    /// </summary>
    public partial class News_RSS_Page : Page
    {


        private bool hasPreloaded = false;


        public News_RSS_Page(ViewModels.RSSViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(((ViewModels.RSSViewModel)DataContext).UpdateFeed);
        }

        private void Page_Loaded(object sender, EventArgs e)
        {
            if (!hasPreloaded)
            {
                Task.Run(((ViewModels.RSSViewModel)DataContext).UpdateFeed);
                hasPreloaded = true;
            }

        }

        private void OfficalNewsFeed_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (OfficalNewsFeed.SelectedItem != null)
                {
                    var item = OfficalNewsFeed.SelectedItem as NewsItem;
                    item.OpenLink();
                }
            }
        }
    }
}