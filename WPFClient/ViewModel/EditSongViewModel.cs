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
    public class EditSongViewModel : ViewModelBase
    {
        public Visibility ArtistIdTextBoxVisibility { get; set; } = Visibility.Collapsed;

        public ObservableCollection<Album> Albums { get; set; } = new ObservableCollection<Album>();
        public ObservableCollection<Artist> Artists { get; set; } = new ObservableCollection<Artist>();
        public ObservableCollection<Song> Songs { get; set; } = new ObservableCollection<Song>();

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

        private string _AlbumId;
        public string AlbumtId
        {
            get
            {
                return _AlbumId;
            }
            set
            {
                Set(ref _AlbumId, value);
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

        private string _puiblishDate;
        public string PublishDate
        {
            get
            {
                return _puiblishDate;
            }
            set
            {
                Set(ref _puiblishDate, value);
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


            

        public ICommand getAll
        {
            get
            {
                return new RelayCommand(
                    () => GetAllArtists(),
                    () => true
                );
            }
        }

        public ICommand getId
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        int Id = Convert.ToInt32(IdStr);
                        GetById(Id);
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
                        await SongService.post(Convert.ToInt32(AlbumtId) ,Name, PublishDate);
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
                        await SongService.Put(Convert.ToInt32(IdStr), Name, Convert.ToInt32(AlbumtId), PublishDate);
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
                        await SongService.Delete(Convert.ToInt32(IdStr));
                    },
                    () => true
                );
            }
        }

        public async void GetAllArtists()
        {

            List<Song> songs = await SongService.getAll();

            Songs.Clear();
            foreach (Song song in songs)
            {
                Songs.Add(song);
            }
        }

        public async void GetById(int id)
        {
            Song song = await SongService.getById(id);
            //List<string> listArtist = 

            Songs.Clear();

            Songs.Add(song);
        }

        public async void GetByName(string name)
        {
            Song song = await SongService.getByName(name);

            Songs.Clear();

            Songs.Add(song);
        }

        public EditSongViewModel()
        {

        }
    }
}
