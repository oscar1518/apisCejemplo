﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba.Models
{
    [Table("Songs")]
    public class Song
    {
        public int Id { get; set; }


        public int ArtistId { get; set; }
        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        //Virtual
        public Artist Artist { get; set; }

    }
}
