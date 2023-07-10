﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entity
{
    [Table("Rezerwacja")]
    public class Rezerwacja : Osoba
    {
        [Key]
        public int Id { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public int IdMiejsca { get; set; }

        [ForeignKey(nameof(IdMiejsca))]
        public Miejsce Miejsce { get; set; }

    }
}
