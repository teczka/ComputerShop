﻿using System.Collections;
using System.Collections.Generic;

namespace ComputerShop.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNumber { get; set; }

        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
