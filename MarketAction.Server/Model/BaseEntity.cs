using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAction.Server.Model
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            IsRemoved = false;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(AutoGenerateField = false)]
        public Guid Id { get; set; }

        public bool IsRemoved { get; set; }
    }
}
