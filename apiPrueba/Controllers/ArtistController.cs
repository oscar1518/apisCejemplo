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
    public class ArtistController : Controller
    {
        private AppDbContext _appContext;

        public ArtistController(AppDbContext appContext)
        {
            _appContext = appContext;
        }


        [HttpGet("GetAll")]
        public async Task<List<ArtistDTO>> GetAll()
        {

            List<Artist> artists = await _appContext.Artists.Include(artist => artist.Albums).ToListAsync();

            List<ArtistDTO> dtoArtists = new List<ArtistDTO>();

            foreach (Artist artist in artists)
            {
                dtoArtists.Add(DTOBuilder.BuildArtistDTO(artist));
            }

            return dtoArtists;

            // METODO PARA DEVOLVER LISTA ARTISTA RAPIDO ( HAY QUE CAMBIAR EN PUBLIC LIST EL TIPO DE LISTA A ARTIST TAMBIÉN).
            //return _appContext.Artists.ToList();




            // OTRO METODO PARA DEVOLVER LA LISTRA DE ARTISTAS
            //var artist = (from a in _appContext.Artists select a
            //return artist.ToList
        }

        [HttpGet("GetByName/{name}")]
        public async Task<ArtistDTO> GetByName(String name)
        {

            Artist artists = await _appContext.Artists.Include(artist => artist.Albums).FirstOrDefaultAsync(artist => artist.Name == name);

            return DTOBuilder.BuildArtistDTO(artists);

        }

        // METODO ANTIGUO PARA EXTRAER EL ARTIST BY NAME
        //public Artist GetByName(String name)
        //{

        //    return _appContext.Artists.FirstOrDefault(artist => artist.Name == name);

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
        public async Task<ArtistDTO> GetById(int id)
        {
            //var artists = _appContext.Artists.Include(artist => artist.Songs).ToList();
            Artist artist = await _appContext.Artists.Include(a => a.Albums).FirstOrDefaultAsync(a => a.Id == id);

            return DTOBuilder.BuildArtistDTO(artist);

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

        //GET ARTIST BY ID MÉTODO ANTIGUO
        //public Artist GetById(int id)
        //{
        //    //var artists = _appContext.Artists.Include(artist => artist.Songs).ToList();

        //    return _appContext.Artists.Include(artist => artist.Songs).FirstOrDefault(artist => artist.Id == id);

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
        public async Task<bool> AddArtist(CreateArtistDTO CreateartistDTO)
        {
            
            _appContext.Artists.Add(EntityBuilder.BuildEntity(CreateartistDTO));
            await _appContext.SaveChangesAsync();
            return true;

        }

        [HttpPut]
        public async Task<IActionResult> AlterArtist(UpdateArtistDTO updateArtistDTO)
        {
            // var artist = GetById(updateArtistDTO.Id);
            Artist artist = _appContext.Artists.Include(a => a.Albums).FirstOrDefault(a => a.Id == updateArtistDTO.Id);

            if (artist == null)
            {
                return NotFound();
            }
            artist.Name = updateArtistDTO.Name;
            artist.Age = updateArtistDTO.Age;
            artist.Genre = updateArtistDTO.Genre;

            _appContext.Update(artist);
            await _appContext.SaveChangesAsync();

            return Ok();

            //if (updateArtistDTO.Name != null && updateArtistDTO.Name != "")
            //{
            //    artist.Name = updateArtistDTO.Name;
            //}

            //if (updateArtistDTO.Age != 0)
            //{
            //    artist.Age = updateArtistDTO.Age;
            //}

            //if (updateArtistDTO.Genre != null && updateArtistDTO.Genre != "")
            //{
            //    artist.Genre = updateArtistDTO.Genre;
            //}
        }

        //Antiguo metodo put
        //[HttpPut]
        //public void AlterArtist(Artist artist)
        //{

        //    _appContext.Update(artist);
        //    _appContext.SaveChanges();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            Artist artist = _appContext.Artists.Include(a => a.Albums).FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            _appContext.Remove(_appContext.Artists.Single(a => a.Id == id));
            await _appContext.SaveChangesAsync();
            return Ok();
        }


    }
}