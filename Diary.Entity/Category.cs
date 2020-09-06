﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Diary.Entity
{
    public class Category : BaseEntity
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

    }
}
