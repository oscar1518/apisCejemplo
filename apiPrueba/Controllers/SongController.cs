using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiPrueba.Context;
using apiPrueba.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiPrueba.Controllers
{
    [Route("apiPrueba/[controller]")]
    [ApiController]
    public class SongController : Controller
    {
        private AppDbContext _appContext;

        public SongController (AppDbContext appContext)
        {
            _appContext = appContext;
        }


        [HttpGet("GetAll")]
        public List<Song> GetAll()
        {

            return _appContext.Songs.ToList();


            //var artist = (from a in _appContext.Artists select a);

            //return artist.ToList();

        }

        [HttpGet("GetByName/{name}")]
        public Song GetByName(String name)
        {

            return _appContext.Songs.FirstOrDefault(song => song.Name == name);

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

        [HttpGet("GetById/{id}")]
        public Song GetById(int id)
        {

            return _appContext.Songs.FirstOrDefault(song => song.Id == id);

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

        [HttpPost]
        public bool AddSong(Song song)
        {
            _appContext.Songs.Add(song);
            _appContext.SaveChanges();
            return true;

        }

        [HttpPut]
        public void AlterSong(Song song)
        {

            _appContext.Update(song);
            _appContext.SaveChanges();
        }


        [HttpDelete]
        public bool DeleteSong(int id)
        {

            _appContext.Remove(_appContext.Songs.Single(song => song.Id == id));
            _appContext.SaveChanges();
            return true;
        }


    }
}