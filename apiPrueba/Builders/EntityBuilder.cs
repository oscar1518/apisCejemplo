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
        public Song BuildEntity(SongDTO song)
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

        public Artist BuildEntity(ArtistDTO artistDTO)
        {
            Artist artist = new Artist();
            artist.Id = artistDTO.Id;
            artist.Name = artistDTO.Name;
            artist.Age = artistDTO.Age;
            artist.Genre = artistDTO.Genre;

            foreach (SongDTO songDTO in artistDTO.Songs)
            {
                artist.Songs.Add(BuildEntity(songDTO));
            }

            return artist;

        }

    }
}
