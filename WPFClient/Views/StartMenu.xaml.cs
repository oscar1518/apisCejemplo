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
using System.Windows.Shapes;
using WPFClient.Views;

namespace WPFClient.ViewModel
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Window
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditArtist artista = new EditArtist();
            artista.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EditAlbumView album = new EditAlbumView();
            album.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EditSongView album = new EditSongView();
            album.ShowDialog();
        }
    }
}