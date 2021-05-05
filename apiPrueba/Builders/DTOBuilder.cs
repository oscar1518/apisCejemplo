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
        public SongDTO BuildDTO(Song song)
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
                PublishDate = song.PublishDate
            };


        }

        public ArtistDTO BuildDTO(Artist artist)
        {
            ArtistDTO artistDTO = new ArtistDTO();
            artistDTO.Id = artist.Id;
            artistDTO.Name = artist.Name;
            artistDTO.Age = artist.Age;
            artistDTO.Genre = artist.Genre;

            foreach (Song song in artist.Songs)
            { 
                artistDTO.Songs.Add(BuildDTO(song));
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

    }
}
