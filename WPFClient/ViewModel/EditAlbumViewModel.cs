using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFClient.Models;
using WPFClient.Services;

namespace WPFClient.ViewModel
{

    public class EditAlbumViewModel : ViewModelBase
    {
        public Visibility ArtistIdTextBoxVisibility { get; set; } = Visibility.Collapsed;

        public ObservableCollection<Album> Albums { get; set; } = new ObservableCollection<Album>();
        public ObservableCollection<Artist> Artists { get; set; } = new ObservableCollection<Artist>();

        private string _IdStr;
        public string IdStr
        {
            get
            {
                return _IdStr;
            }
            set
            {
                Set(ref _IdStr, value);
            }
        }

        private string _ArtistId;
        public string ArtistId
        {
            get
            {
                return _ArtistId;
            }
            set
            {
                Set(ref _ArtistId, value);
            }
        }
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                Set(ref _Name, value);
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
                    () =>
                    {
                        int artistId = Convert.ToInt32(IdStr);
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
                    () =>
                    {
                        GetByName(Name);
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
                    async () =>
                    {
                        await AlbumService.post(Name, Convert.ToInt32(ArtistId));
                        // Post(PostArtist, Convert.ToInt32() , postGenre);
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
                    async () =>
                    {
                        await AlbumService.Put(Convert.ToInt32(IdStr), Name, Convert.ToInt32(ArtistId));
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
                    async () =>
                    {
                        await AlbumService.Delete(Convert.ToInt32(IdStr));
                    },
                    () => true
                );
            }
        }

        public async void GetAllArtists()
        {

            List<Album> albums = await AlbumService.getAll();
            //List<string> listArtist = 

            Albums.Clear();
            foreach (Album album in albums)
            {
                Albums.Add(album);

            }
        }
        public async void GetById(int id)
        {
            Album album = await AlbumService.getById(id);
            //List<string> listArtist = 

            Albums.Clear();

            Albums.Add(album);
        }

        public async void GetByName(string name)
        {
            Album album = await AlbumService.getByName(name);
            //List<string> listArtist = 

            Albums.Clear();

            Albums.Add(album);
        }



        public EditAlbumViewModel()
        {


        }
    }
}