﻿using System;

namespace GoodBooks.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public BookReview Review { get; set; }
    }
}
