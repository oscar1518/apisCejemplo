using ConsoleRestApi.Models;
using ConsoleRestApi.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRestApi
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("¿En que menú quieres entrar?");
            Console.WriteLine("1. Menú Artistas");
            Console.WriteLine("2. Menú Albums");
            Console.WriteLine("3. Menú Canciones");
            int eleccionMenu = Convert.ToInt32(Console.ReadLine());
            if (eleccionMenu == 1)
            {
                menu(0);
            }
            else if (eleccionMenu == 2)
            {
                menuA(0);
            }
            else if (eleccionMenu == 3)
            {
                menuS(0);
            } else
            {
                Console.WriteLine("Hasta luego");
                Console.ReadLine();
            }

            Console.ReadLine();
        }


        static private async void menu(int caso)
        {

            while (caso >= 7 || caso <= 0)
            {
                Console.WriteLine("MENU ARTISTA\n\n");
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1. Ver todos los Artistas");
                Console.WriteLine("2. Ver Artista por id");
                Console.WriteLine("3. Ver Artista por nombre");
                Console.WriteLine("4. Crear nuevo Artista");
                Console.WriteLine("5. Modificar Artista");
                Console.WriteLine("6. Eliminar artista");

                caso = Convert.ToInt32(Console.ReadLine());
            }

            await menuArtista(caso);
        }
        static private async void menuA(int caso)
        {

            while (caso >= 7 || caso <= 0)
            {
                Console.WriteLine("MENU ALBUM\n\n");
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1. Ver todos los Albums");
                Console.WriteLine("2. Ver Album por id");
                Console.WriteLine("3. Ver Album por nombre");
                Console.WriteLine("4. Crear nuevo Album");
                Console.WriteLine("5. Modificar Album");
                Console.WriteLine("6. Eliminar Album");

                caso = Convert.ToInt32(Console.ReadLine());
            }

            await menuAlbum(caso);
        }

        static private async void menuS(int caso)
        {

            while (caso >= 7 || caso <= 0)
            {
                Console.WriteLine("MENU CANCION\n\n");
                Console.WriteLine("Elige una opción:");
                Console.WriteLine("1. Ver todas las Canciones");
                Console.WriteLine("2. Ver Canción por id");
                Console.WriteLine("3. Ver Canción por nombre");
                Console.WriteLine("4. Crear nueva canción");
                Console.WriteLine("5. Modificar Canción");
                Console.WriteLine("6. Eliminar Canción");

                caso = Convert.ToInt32(Console.ReadLine());
            }

            await menuCanción(caso);
        }
        static private async Task menuArtista(int caseSwitch)
        {
            switch (caseSwitch)
            {
                case 1://GETALL
                    ArtistService.getArtistData().Wait();
                    Console.ReadLine();
                    menu(0);
                    break;
                case 2://GET BY ID
                    Console.WriteLine("Introduce el Id del artista");
                    int id = Convert.ToInt32(Console.ReadLine());
                    ArtistService.getArtistId(id);
                    Console.ReadLine();
                    menu(0);
                    break;
                case 3: //GET BY NAME
                    Console.WriteLine("Introduce el Nombre del artista");
                    string name = Console.ReadLine();
                    ArtistService.getArtistName(name);
                    Console.ReadLine();
                    menu(0);
                    break;
                case 4: //POST
                    Console.WriteLine("Introduce el Nombre del artista que quieras agregar:");
                    string namePost = Console.ReadLine();
                    Console.WriteLine("Introduce la edad:");
                    int edadPost = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Introduce el genero:");
                    string generoPost = Console.ReadLine();
                    ArtistService.postArtist(namePost, edadPost, generoPost).Wait();
                    menu(0);
                    break;
                case 5: //PUT
                    Console.WriteLine("Introduce el ID del artista que quieras modificar:");
                    int idPut = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Introduce el Nombre:");
                    string namePut = Console.ReadLine();
                    Console.WriteLine("Introduce la edad:");
                    int edadPut = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Introduce el genero:");
                    string generoPut = Console.ReadLine();
                    ArtistService.putArtist(idPut, namePut, edadPut, generoPut).Wait();
                    Console.ReadLine();
                    menu(0);
                    break;
                case 6://Delete
                    Console.WriteLine("Introduce el ID del artista que quieras ELIMINAR:");
                    int idDEL = Convert.ToInt32(Console.ReadLine());
                    ArtistService.deleteArtist(idDEL).Wait();
                    Console.ReadLine();

                    menu(0);
                    break;
                default:
                    Console.WriteLine("¡¡Hasta luego!!");
                    Console.ReadLine();
                    break;
            }


        }

        static private async Task menuAlbum(int caseSwitch)
        {
            switch (caseSwitch)
            {
                case 1://GETALL
                    AlbumService.getAlbumData();
                    Console.ReadLine();
                    menuA(0);
                    break;
                case 2://GET BY ID
                    Console.WriteLine("Introduce el Id del album");
                    int id = Convert.ToInt32(Console.ReadLine());
                    AlbumService.getAlbumId(id);
                    Console.ReadLine();
                    menuA(0);
                    break;
                case 3: //GET BY NAME
                    Console.WriteLine("Introduce el Nombre del album");
                    string name = Console.ReadLine();
                    AlbumService.getAlbumName(name);
                    Console.ReadLine();
                    menuA(0);
                    break;
                case 4: //POST
                    Console.WriteLine("Introduce el Nombre del album que quieras agregar:");
                    string namePost = Console.ReadLine();
                    Console.WriteLine("Introduce EL Id del Artista:");
                    int idPost = Convert.ToInt32(Console.ReadLine());
                    AlbumService.postAlbum(namePost, idPost).Wait();
                    menuA(0);
                    break;
                case 5: //PUT
                    Console.WriteLine("Introduce el ID del album que quieras modificar:");
                    int idPut = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Introduce el Nombre:");
                    string namePut = Console.ReadLine();
                    Console.WriteLine("Introduce el id del Artista:");
                    int idArtistPut = Convert.ToInt32(Console.ReadLine());
                    AlbumService.putAlbum(idPut, namePut, idArtistPut).Wait();
                    Console.ReadLine();
                    menuA(0);
                    break;
                case 6://Delete
                    Console.WriteLine("Introduce el ID del album que quieras ELIMINAR:");
                    int idDEL = Convert.ToInt32(Console.ReadLine());
                    AlbumService.deleteAlbum(idDEL).Wait();
                    Console.ReadLine();

                    menuA(0);
                    break;
                default:
                    Console.WriteLine("¡¡Hasta luego!!");
                    Console.ReadLine();
                    break;
            }


        }
        static private async Task menuCanción(int caseSwitch)
        {
            switch (caseSwitch)
            {
                case 1://GETALL
                    SongService.getSongData();
                    Console.ReadLine();
                    menuS(0);
                    break;
                case 2://GET BY ID
                    Console.WriteLine("Introduce el Id de la Canción");
                    int id = Convert.ToInt32(Console.ReadLine());
                    SongService.getSongId(id);
                    Console.ReadLine();
                    menuS(0);
                    break;
                case 3: //GET BY NAME
                    Console.WriteLine("Introduce el Nombre de la Canción");
                    string name = Console.ReadLine();
                    SongService.getSongByName(name);
                    Console.ReadLine();
                    menuS(0);
                    break;
                case 4: //POST
                    Console.WriteLine("Introduce el Nombre de la Canción que quieras agregar:");
                    string namePost = Console.ReadLine();
                    Console.WriteLine("Introduce la fecha de la canción que quieras agregar:");
                    string fechaPost = Console.ReadLine();
                    Console.WriteLine("Introduce EL Id del Artista:");
                    int idPost = Convert.ToInt32(Console.ReadLine());
                    SongService.postSong(namePost, fechaPost, idPost).Wait();
                    menuS(0);
                    break;
                case 5: //PUT
                    Console.WriteLine("Introduce el ID de la Canción que quieras modificar:");
                    int idPut = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Introduce el Nombre:");
                    string namePut = Console.ReadLine();
                    Console.WriteLine("Introduce el id del album:");
                    int idAlbumPut = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Introduce la fecha de creación:");
                    string fechaPut = Console.ReadLine();
                    SongService.putSong(idPut, namePut, idAlbumPut, fechaPut).Wait();
                    Console.ReadLine();
                    menuS(0);
                    break;
                case 6://Delete
                    Console.WriteLine("Introduce el ID de la canción que quieras ELIMINAR:");
                    int idDEL = Convert.ToInt32(Console.ReadLine());
                    SongService.deleteSong(idDEL).Wait();
                    Console.ReadLine();

                    menuS(0);
                    break;
                default:
                    Console.WriteLine("¡¡Hasta luego!!");
                    Console.ReadLine();
                    break;
            }


        }
    }
}
