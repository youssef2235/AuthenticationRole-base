﻿using AuthenticationRole_base.Models;

namespace BlueGreenEG.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
