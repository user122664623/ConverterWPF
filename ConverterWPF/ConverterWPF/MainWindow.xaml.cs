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
using System.IO;
using Microsoft.Win32;
using ConvertApiDotNet;

namespace ConverterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBlock2.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Документ Microsoft Word .docx| *.docx";
            if (openFileDialog.ShowDialog() == true) textBlock1.Text = openFileDialog.FileName;
        }


        private async void Button_Click_2Async(object sender, RoutedEventArgs e)
        {
            await Converter(textBlock1.Text);
        }

        async Task Converter(String path)
        {
            ConvertApi ca = new ConvertApi("pIZZqkiAjyhTYmgd");

            String _path = path;
            String pdfpath = (System.IO.Path.GetDirectoryName(_path) + @"\" + System.IO.Path.GetFileNameWithoutExtension(path) + ".pdf");


            var pdffile = await ca.ConvertAsync("docx", "pdf", new[]
            {
                new ConvertApiFileParam(@_path)
            }
            );

            var pdf = await pdffile.SaveFileAsync(@pdfpath);

            textBlock2.Text = "Файл pdf создан. " + pdfpath;


        }
    }
}
