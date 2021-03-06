﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.DomianModel.Model
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            IsRemoved = false;
            CreateDate = DateTime.Now;
            LastEditDate = CreateDate;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = false)]
        public Guid Id { get; set; }

        public bool IsRemoved { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}
