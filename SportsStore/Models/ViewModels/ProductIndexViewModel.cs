﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class ProductIndexViewModel
    {
        public PaginatedList<Product> Products { get; set; }
        public List<string> Categories { get; set; }
        public string Category { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
}