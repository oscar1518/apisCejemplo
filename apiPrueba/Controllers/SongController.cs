using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiPrueba.Builders;
using apiPrueba.Context;
using apiPrueba.DTOs;
using apiPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiPrueba.Controllers
{
    [Route("apiPrueba/[controller]")]
    [ApiController]
    public class SongController : Controller
    {
        private AppDbContext _appContext;

        public SongController(AppDbContext appContext)
        {
            _appContext = appContext;
        }



        [HttpGet("GetAll")]
        public async Task<List<SongDTO>> GetAll()
        {

            var songs = await _appContext.Songs.Include(song => song.Album).Include(song => song.Album.Artist).ToListAsync();

            List<SongDTO> songDTO = new List<SongDTO>();

            foreach (Song song in songs)
            {
                songDTO.Add(DTOBuilder.BuildSongDTO(song));
            }


            return songDTO;


            //var artist = (from a in _appContext.Artists select a);
            //return artist.ToList();

        }

        [HttpGet("GetByName/{name}")]
        public async Task<SongDTO> GetByName(String name)
        {
            Song songs = await _appContext.Songs.Include(song => song.Album).Include(song => song.Album.Artist).FirstOrDefaultAsync(song => song.Name == name);



            return DTOBuilder.BuildSongDTO(songs);

            // var artists =  _appContext.Artists;

            //foreach (var artist in artists)
            //{
            //    if (artist.Name == name)
            //    {
            //        return artist;
            //    }
            //}

            //return null;
        }

        // METODO ANTIGUO PARA GET BY NAME
        //public Song GetByName(String name)
        //{

        //    return _appContext.Songs.FirstOrDefault(song => song.Name == name);

        //    // var artists =  _appContext.Artists;

        //    //foreach (var artist in artists)
        //    //{
        //    //    if (artist.Name == name)
        //    //    {
        //    //        return artist;
        //    //    }
        //    //}

        //    //return null;
        //}

        [HttpGet("GetById/{id}")]
        public async Task<SongDTO> GetById(int id)
        {

            Song songs = await _appContext.Songs.Include(song => song.Album).Include(song => song.Album.Artist).FirstOrDefaultAsync(song => song.Id == id);

            return DTOBuilder.BuildSongDTO(songs);

            // var artists =  _appContext.Artists;

            //foreach (var artist in artists)
            //{
            //    if (artist.Name == name)
            //    {
            //        return artist;
            //    }
            //}

            //return null;
        }

        //Metodo GET BY ID ANTIGUO
        //public Song GetById(int id)
        //{

        //    return _appContext.Songs.FirstOrDefault(song => song.Id == id);

        //    // var artists =  _appContext.Artists;

        //    //foreach (var artist in artists)
        //    //{
        //    //    if (artist.Name == name)
        //    //    {
        //    //        return artist;
        //    //    }
        //    //}

        //    //return null;
        //}

        [HttpPost]
        public async Task<bool> AddSong(CreateSongDTO createSongDTO)
        {
            _appContext.Songs.Add(EntityBuilder.BuildEntity(createSongDTO));
            await _appContext.SaveChangesAsync();
            return true;

        }

        //Antiguo METODO POST
        //[HttpPost]
        //public bool AddSong(Song song)
        //{
        //    _appContext.Songs.Add(song);
        //    _appContext.SaveChanges();
        //    return true;

        //}


        [HttpPut]
        public async Task AlterSong(UpdateSongDTO updateSongDTO)
        {

            Song song = _appContext.Songs.Include(a => a.Album).FirstOrDefault(a => a.Id == updateSongDTO.Id);

            song.Name = updateSongDTO.Name;
            song.Id = updateSongDTO.Id;
            song.PublishDate = updateSongDTO.PublishDate;
            song.AlbumId = updateSongDTO.AlbumId;

            _appContext.Update(song);
            await _appContext.SaveChangesAsync();

        }


        [HttpDelete("{id}")]
        public async Task<bool> DeleteSong(int id)
        {

            _appContext.Remove(_appContext.Songs.Single(song => song.Id == id));
            await _appContext.SaveChangesAsync();
            return true;
        }


    }
}