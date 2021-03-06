#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using System;
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

namespace FilteringDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }
        
        void OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as EmployeeInfoViewModel;
            viewModel.filterChanged = OnFilterChanged;
        }

        private void OnFilterChanged()
        {
            var viewModel = this.DataContext as EmployeeInfoViewModel;
            if (sfGrid.View != null)
            {
                sfGrid.View.Filter = viewModel.FilerRecords;
                sfGrid.View.RefreshFilter();
            }
        }
    }
}
