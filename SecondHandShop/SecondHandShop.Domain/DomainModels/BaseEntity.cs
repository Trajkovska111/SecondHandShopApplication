using System;
using System.ComponentModel.DataAnnotations;

namespace SecondHandShop.Domain.DomainModels
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
