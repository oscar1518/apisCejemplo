using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    public class AAATestController : Controller
    {
        private AppDbContext _appContext;

        public AAATestController(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        [HttpGet("TestAsync")]
        public async Task<bool> TestAsync()
        {
            await EnviarMail();
            return true;
        }

        private async Task EnviarMail()
        {
            await Task.Delay(10 * 1000);
        }

        [HttpGet("TestEndpoint")]
        public List<Factura> Test()
        {
            List<Factura> facturas = new List<Factura>();
            facturas.Add(new Factura()
            {
                Codigo = "FF-21-00003",
                Importe = 10.25,
                EjercicioContable = 2021
            });
            facturas.Add(new Factura()
            {
                Codigo = "FF-21-00002",
                Importe = 15.20,
                EjercicioContable = 2020
            });
            facturas.Add(new Factura()
            {
                Codigo = "FF-21-00001",
                Importe = 13.22,
                EjercicioContable = 2020
            });

            //return facturas.Where(x => x.Importe > 15).ToList();

            // 1. Ordenar las facturas codigo
            //return facturas.OrderBy(x => x.Codigo).ToList();

            // 2. Mostrar todas las facturas del 2020
            //return facturas.Where(x => x.EjercicioContable == 2020).ToList();

            // 3. Mostrar las facturas cuyo importe este entre 11 y 14

            return facturas.Where(x => x.Importe <= 14 && x.Importe >= 11).ToList();

            //List<Factura> listaFacturas = new List<Factura>();
            //foreach (Factura x in facturas)
            //{


            //    if (x.Importe <= 14 && x.Importe >= 11){
            //        listaFacturas.Add(x);
            //    }


            //}

            //return listaFacturas;


            // 4. Mostrar la primera factura de 2020 cuyo codigo acabe en 1
            //return facturas.FirstOrDefault(x => x.Codigo.EndsWith("1") && x.EjercicioContable == 2020);




            //List<string> list = new List<string>()
            //{
            //    "Papel",
            //    "Boli",
            //    "Piedra",
            //    "Rojo",
            //    "Verde"
            //};

            // 1. Devolver tercer elemento
            // Return string, list[2];
            //return list.ElementAt(2);

            // 2. Devolver el primer elemento que empiece por R
            //string r = list.FirstOrDefault(x => x.StartsWith("R"));

            // 3. Devolver el último elemento que empiece por P
            //string r = list.LastOrDefault(x => x.StartsWith("P"));

            // 4. Devolver un número que indique cuántos elementos tiene la lista
            //int r = list.Count();

            // 5. Ordenar alfabéticamente la lista
            //List<string> lista = list.OrderBy(x => x).ToList();

            // 6. Ordenar anti-alfabéticamente (al revés que el 6, de la Z a la A) la lista
            //List<string> lista = list.OrderByDescending(x => x).ToList();


            // 7. Añadir el elemento Azul a la lista
            //list.Add("Azul");

            // 8. Añadir una lista con los elementos Azul y Amarillo a la lista.
            //List<string> collection = new List<string>();
            //collection.Add("Azul");
            //collection.Add("Amarillo");
            //list.Add(collection.LastOrDefault(x=>x.StartsWith("Az")));


            //return list;
        }
    }
}
