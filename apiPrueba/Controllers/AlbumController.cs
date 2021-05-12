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
    public class AlbumController : Controller
    {
        private AppDbContext _appContext;

        public AlbumController(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        [HttpGet("GetAll")]
        public async Task<List<AlbumDTO>> GetAll()
        {

            List<Album> albums = await _appContext.Albums.Include(a => a.Artist).Include(a => a.Songs).ToListAsync();

            List<AlbumDTO> albumDTO = new List<AlbumDTO>();

            foreach (Album album in albums)
            {
                albumDTO.Add(DTOBuilder.BuildAlbumDTO(album));
            }

            return albumDTO;

        }
        [HttpGet("GetById/{id}")]
        public async Task<AlbumDTO> GetById(int id) 
        {

            Album album = await _appContext.Albums.Include(a => a.Artist).Include(a => a.Songs).FirstOrDefaultAsync(a => a.Id == id);

            return DTOBuilder.BuildAlbumDTO(album);

        }

        [HttpGet("GetByName/{name}")]
        public async Task<AlbumDTO> GetByName(string name)
        {

            Album album = await _appContext.Albums.Include(a => a.Artist).Include(a => a.Songs).FirstOrDefaultAsync(a => a.Name == name);

            return DTOBuilder.BuildAlbumDTO(album);

        }

        [HttpPost]
        public async  Task<bool>AddAlbum(CreateAlbumDTO CreateAlbumDTO)
        {

            _appContext.Albums.Add(EntityBuilder.BuildEntity(CreateAlbumDTO));
            await _appContext.SaveChangesAsync();
            return true;

        }

        [HttpPut]
        public async Task AlterAlbum(UpdateAlbumDTO updateAlbumDTO)
        {
            // var artist = GetById(updateArtistDTO.Id);
            Album album = _appContext.Albums.Include(a => a.Songs).Include(a => a.Artist).FirstOrDefault(a => a.Id == updateAlbumDTO.Id);

            album.Name = updateAlbumDTO.Name;
            album.ArtistId = updateAlbumDTO.ArtistId;

            _appContext.Update(album);
            await _appContext.SaveChangesAsync();

        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAlbum(int id)
        {

            _appContext.Remove(_appContext.Albums.Single(album => album.Id == id));
            await _appContext.SaveChangesAsync();
            return true;
        }

    }
}
