<<<<<<<< HEAD:GeekShopping/GeekShopping.CartAPI/Data/ValueObjects/ProductVO.cs
﻿namespace GeekShopping.CartAPI.Data.ValueObjects
========
﻿using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models
>>>>>>>> 81059ce2a212feb649e324112eb868cde0e72703:GeekShopping/GeekShopping.Web/Models/ProductModel.cs
{

    public class ProductVO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubstringName()
        {
            if (Name.Length < 24) return Name;
            return $"{Name.Substring(0, 21)}...";
        }

        public string SubstringDescription()
        {
            if (Description.Length < 355) return Description;
            return $"{Description.Substring(0, 352)}...";
        }
    }
}
