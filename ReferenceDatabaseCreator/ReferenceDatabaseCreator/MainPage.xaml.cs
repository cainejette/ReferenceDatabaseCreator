﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ReferenceDatabaseCreator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SQLiteConnection _db; 
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void createDatabase_Click(object sender, RoutedEventArgs e)
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync("WorkoutPlans.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, "Insanity");
            
        }

        private async void readFile_Click(object sender, RoutedEventArgs e)
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync("workouts.txt");
            string result = await FileIO.ReadTextAsync(file);
            textBlock.Text = result;
        }
    }
}
