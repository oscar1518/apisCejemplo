using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFClient.Models;
using WPFClient.Services;

namespace WPFClient.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public Visibility ArtistIdTextBoxVisibility { get; set; } = Visibility.Collapsed;

        public ObservableCollection<Artist> Artists { get; set; } = new ObservableCollection<Artist>();

        private Artist _selectedArtist;
        public Artist SelectedArtist
        {
            get
            {
                return _selectedArtist;
            }
            set
            {
                Set(ref _selectedArtist, value);
            }
        }

        private Album _selectedAlbum;
        public Album SelectedAlbum
        {
            get
            {
                return _selectedAlbum;
            }
            set
            {
                Set(ref _selectedAlbum, value);
            }
        }

        //SelectedItem="{Binding SelectedAlbum}" DisplayMemberPath="AlbumsNames" 
        ObservableCollection<string> _nombreAlbums = new ObservableCollection<string>();
        public ObservableCollection<string> AlbumsCB
        {
            get
            {

                if (SelectedArtist != null)
                {

                    _nombreAlbums.Clear();
                    foreach (String albums in SelectedArtist.Albums.Select(x => x.Name))
                    {
                        _nombreAlbums.Add(albums);
                    }


                }
                return _nombreAlbums;
            }

            set
            {
            }
        }





        private string _artistIdStr;
        public string ArtistIdStr
        {
            get
            {
                return _artistIdStr;
            }
            set
            {
                Set(ref _artistIdStr, value);
            }
        }

        private string _artistName;
        public string ArtistName
        {
            get
            {
                return _artistName;
            }
            set
            {
                Set(ref _artistName, value);
            }
        }

        private string _AgeStr;
        public string AgeStr
        {
            get
            {
                return _AgeStr;
            }
            set
            {
                Set(ref _AgeStr, value);
            }
        }

        private string _Genre;
        public string Genre
        {
            get
            {
                return _Genre;
            }
            set
            {
                Set(ref _Genre, value);
            }
        }




        public ICommand getAll {
            get
            {
                return new RelayCommand(
                    () => GetAllArtists(),
                    () => true
                ) ;
            }
        }
        public ICommand getId
        {
            get
            {
                return new RelayCommand(
                    () => {
                        int artistId = Convert.ToInt32(ArtistIdStr);
                        GetById(artistId);
                    },
                    () => true
                );
            }
        }
        public ICommand getName
        {
            get
            {
                return new RelayCommand(
                    () => {
                        string artistName =_artistName;
                        GetByName(artistName);
                    },
                    () => true
                );
            }
        }
        public ICommand post
        {
            get
            {
                return new RelayCommand(
                    async () => {
                        string postGenre = _Genre;
                        string postAge = _AgeStr;
                        string postArtist = _artistName;
                        await ArtistService.post(postArtist, Convert.ToInt32(postAge), postGenre);
                        // Post(PostArtist, Convert.ToInt32(postAge) , postGenre);
                    },
                    () => true
                );
            }
        }

        public ICommand put
        {
            get
            {
                return new RelayCommand(
                    async () => {
                        await ArtistService.Put(Convert.ToInt32(ArtistIdStr), ArtistName, Convert.ToInt32(AgeStr), Genre);
                        // Post(PostArtist, Convert.ToInt32(postAge) , postGenre);
                    },
                    () => true
                );
            }
        }

        public ICommand delete
        {
            get
            {
                return new RelayCommand(
                    async () => {
                        await ArtistService.Delete(Convert.ToInt32(ArtistIdStr));
                        // Post(PostArtist, Convert.ToInt32(postAge) , postGenre);
                    },
                    () => true
                );
            }
        }

        public async void GetAllArtists()
        {

            List<Artist> artists = await ArtistService.getAll();
            //List<string> listArtist = 

            Artists.Clear();
            
            foreach (Artist artist in artists)
            {
                Artists.Add(artist);

            }
        }
        public async void GetById(int id)
        {
            Artist artists = await ArtistService.getById(id);
            //List<string> listArtist = 

            Artists.Clear();

            Artists.Add(artists);
        }

        public async void GetByName(string name)
        {
            Artist artists = await ArtistService.getByName(name);
            //List<string> listArtist = 

            Artists.Clear();

            Artists.Add(artists);
        }

        public void ActivarComboBox1()
        {

        }

        public MainViewModel()
        {


        }
    }
}