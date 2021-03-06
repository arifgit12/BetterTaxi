﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterTaxi.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        [StringLength(4)]
        public string FileExtension { get; set; }
    }
}
