﻿using Core.Entites;

namespace Entities.Concrete.Models
{
    public class CarBody:BaseEntity
    {
        public string CarBodyName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
