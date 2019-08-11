﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MangaStore.Database.Models
{
    public class Genre
    {
        public Genre(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public Genre()
        {
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
