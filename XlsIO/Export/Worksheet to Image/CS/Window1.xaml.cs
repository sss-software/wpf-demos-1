#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.XlsIO;
using System.Drawing.Imaging;
using Syncfusion.Windows.Shared;

namespace SheetToImage_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        string fileName;

        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
#if NETCORE
            string file2 = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_button.png";
#else
            string file2 = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_button.png";
#endif
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            // Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2007;

            // An existing workbook is opened.
#if NETCORE
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\WorkSheetToImage.xlsx");
#else
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\WorkSheetToImage.xlsx");
#endif

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets["Pivot Table"];

            sheet.UsedRangeIncludesFormatting = false;
            int lastRow = sheet.UsedRange.LastRow + 1;
            int lastColumn = sheet.UsedRange.LastColumn + 1;


            // Save the image.
            if (this.rBtnBitmap.IsChecked.Value)
            {

                // Convert the worksheet to image
                System.Drawing.Image img = sheet.ConvertToImage(1, 1, lastRow, lastColumn, ImageType.Bitmap, null);

                fileName = "Sample.png";
                img.Save(fileName, ImageFormat.Png);
            }
            else
            {

                // Convert the worksheet to image
                System.Drawing.Image img = sheet.ConvertToImage(1, 1, lastRow, lastColumn, ImageType.Metafile, null);

                fileName = "Sample.emf";
                img.Save(fileName, ImageFormat.Emf);
            }

            //Close the workbook.
            workbook.Close();
            excelEngine.Dispose();

            //Message box confirmation to view the created spreadsheet.
            if (MessageBox.Show("Do you want to view the image?", "Image has been created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
#else
                    Process.Start(fileName);
#endif

                    //Exit
                    this.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
                // Exit
                this.Close();
        }

        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Input_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"..\..\..\..\..\..\..\Common\Data\XlsIO\WorkSheetToImage.xlsx")
            {
                UseShellExecute = true
            };
            process.Start();
#else
            Process.Start(@"..\..\..\..\..\..\Common\Data\XlsIO\WorkSheetToImage.xlsx");
#endif
            //Exit
            this.Close();
        }
    }
}
