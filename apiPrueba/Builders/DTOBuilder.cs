using apiPrueba.DTOs;
using apiPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Builders
{
    public class DTOBuilder
    {
        public static SongDTO BuildSongDTO(Song song)
        {
            //SongDTO songDto = new SongDTO();
            //songDto.Id = song.Id;
            //songDto.Name = song.Name;
            //songDto.PublishDate = song.PublishDate;

            //return songDto;

            return new SongDTO()
            {
                Id = song.Id,
                Name = song.Name,
                PublishDate = song.PublishDate,
                //ArtistName = song.Artist.Name,
                //ArtistAge = song.Artist.Age
                Album = new AlbumDTO
                {
                    Id = song.Album.Id,
                    Name = song.Album.Name,
                }
            };


        }

        public static ArtistDTO BuildArtistDTO(Artist artist)
        {
            ArtistDTO artistDTO = new ArtistDTO();
            artistDTO.Id = artist.Id;
            artistDTO.Name = artist.Name;
            artistDTO.Age = artist.Age;
            artistDTO.Genre = artist.Genre;

            foreach (Album album in artist.Albums)
            { 
               artistDTO.Albums.Add(BuildAlbumDTO(album));
            }

            return artistDTO;


            //return new ArtistDTO()
            //{
            //    Id = artist.Id,
            //    Name = artist.Name,
            //    Age = artist.Age,
            //    Genre = artist.Genre,
            //    Songs = artist.Songs.Select(song => BuildDTO(song)).ToList()
            //};
        }

        public static AlbumDTO BuildAlbumDTO(Album album)
        {
  
            AlbumDTO albumtDTO = new AlbumDTO();
            albumtDTO.Id = album.Id;
            albumtDTO.Name = album.Name;
            albumtDTO.Artist = new ArtistDTO()
            {
                Id = album.Artist.Id,
                Name = album.Artist.Name
                
            };


            foreach (Song song in album.Songs)
            {
                albumtDTO.Songs.Add(BuildSongDTO(song));
            }

            return albumtDTO;

        }

    }
}
