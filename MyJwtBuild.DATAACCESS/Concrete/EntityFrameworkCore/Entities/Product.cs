using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyJwtBuild.DATAACCESS.Concrete.EntityFrameworkCore.Entities
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Price { get; set; } = null!;
        public int CategoryId { get; set; }
        public int AddedUserId { get; set; }
    }
}
