using apiPrueba.DTOs;
using apiPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Builders
{
    public class EntityBuilder
    {
        public static Song BuildEntity(SongDTO song)
        {
            //SongDTO songDto = new SongDTO();
            //songDto.Id = song.Id;
            //songDto.Name = song.Name;
            //songDto.PublishDate = song.PublishDate;

            //return songDto;

            return new Song()
            {
                Id = song.Id,
                Name = song.Name,
                PublishDate = song.PublishDate
            };
        }

        public static Artist BuildEntity(ArtistDTO artistDTO)
        {
            Artist artist = new Artist();
            artist.Id = artistDTO.Id;
            artist.Name = artistDTO.Name;
            artist.Age = artistDTO.Age;
            artist.Genre = artistDTO.Genre;

            foreach (AlbumDTO albumDTO in artistDTO.Albums)
            {
                //artist.Albums.Add(BuildEntity(songDTO));
            }

            return artist;

        }


        public static Artist BuildEntity(CreateArtistDTO createArtistDTO)
        {
            Artist artist = new Artist();
            artist.Name = createArtistDTO.Name;
            artist.Age = createArtistDTO.Age;
            artist.Genre = createArtistDTO.Genre;

            return artist;

        }

        public static Song BuildEntity(CreateSongDTO createSongDTO)
        {
            Song song = new Song();
            song.Name = createSongDTO.Name;
            song.AlbumId = createSongDTO.AlbumId;
            song.PublishDate = createSongDTO.PublishDate;

            return song;

        }

        public static Album BuildEntity(CreateAlbumDTO createAlbumDTO)
        {
            Album album = new Album();
            album.Name = createAlbumDTO.Name;
            album.ArtistId = createAlbumDTO.ArtistId;

            return album;

        }
    }
}
