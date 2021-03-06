﻿using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public PagingList<ProductReview> ProductReviews { get; set; }
        public int? Quantity { get; set; }
        public int? Id { get; set; }
        public string ReturnUrl { get; set; }
    }
}
