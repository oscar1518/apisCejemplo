using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiPrueba.Context;
using apiPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiPrueba.Controllers
{
    [Route("apiPrueba/[controller]")]
    [ApiController]
    public class ArtistController : Controller
    {
        private AppDbContext _appContext;

        public ArtistController(AppDbContext appContext)
        {
            _appContext = appContext;
        }


        [HttpGet("GetAll")]
        public List<Artist> GetAll()
        {



            return _appContext.Artists.ToList();


            //var artist = (from a in _appContext.Artists select a);

            //return artist.ToList();

        }

        [HttpGet("GetByName/{name}")]
        public Artist GetByName(String name)
        {

            return _appContext.Artists.FirstOrDefault(artist => artist.Name == name);

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
        public Artist GetById(int id)
        {
            //var artists = _appContext.Artists.Include(artist => artist.Songs).ToList();

            return _appContext.Artists.Include(artist => artist.Songs).FirstOrDefault(artist => artist.Id == id);

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
        public bool AddArtist(Artist artist)
        {
            _appContext.Artists.Add(artist);
            _appContext.SaveChanges();
            return true;

        }

        [HttpPut]
        public void AlterArtist(Artist artist)
        {

            _appContext.Update(artist);
            _appContext.SaveChanges();
        }


        [HttpDelete]
        public bool DeleteArtist(int id)
        {

            _appContext.Remove(_appContext.Artists.Single(artist => artist.Id == id));
            _appContext.SaveChanges();
            return true;
        }


    }
}