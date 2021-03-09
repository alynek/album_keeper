using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Album 
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Backdrop { get; set; }

        [Required]
        public string Band { get; set; }
        public IList<Music> Musics { get; set; }
    }
}