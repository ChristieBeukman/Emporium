using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Emporium.Services;
using Emporium.Model;

namespace Emporium.View.Configuration
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : UserControl
    {
        public ConfigurationView()
        {
            InitializeComponent();
            _ser = new DataAccess();
        }

        IDataAccess _ser;
        private void chkRefine_Checked(object sender, RoutedEventArgs e)
        {
            if (chkRefine.IsChecked == false)
            {
                expRefine.IsExpanded = false;
            }
        }
        private BitmapImage NewImage;
        private string fullpath;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog FileDialog = new System.Windows.Forms.OpenFileDialog();
            FileDialog.Title = "Select Image";
            FileDialog.InitialDirectory = "";
            FileDialog.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png";
            FileDialog.FilterIndex = 1;

            if (FileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = FileDialog.FileName;
                fullpath = filename;
                string fileExt = GetFileNameNoExt(filename.Trim());
                BitmapImage IMG = new BitmapImage(new Uri(filename.Trim()));
                img.Source = IMG;
            }
            else
            {
                MessageBox.Show("Select File");
            }

        }

        public string GetFileNameNoExt(string FilePathFileName)
        {
            return System.IO.Path.GetFileNameWithoutExtension(FilePathFileName);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FileStream Stream = new FileStream(fullpath, FileMode.Open, FileAccess.Read);
            StreamReader Reader = new StreamReader(Stream);
            Byte[] ImgData = new Byte[Stream.Length - 1];
            Stream.Read(ImgData, 0, (int)Stream.Length - 1);
            test t = new test();
            t.image = ImgData;
            _ser.Add(t);
            MessageBox.Show("");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            test t = new test();
            t = _ser.sele();
            byte[] data = t.image;
            MemoryStream strm = new MemoryStream();
            strm.Write(data, 0, data.Length);
            strm.Position = 0;
            System.Drawing.Image imge = System.Drawing.Image.FromStream(strm);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            MemoryStream ms = new MemoryStream();
            imge.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            img.Source = bi;

        }
    }
}
