﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPFUI.ViewModels
{
    internal class CartViewModel : BaseViewModel
    {
        public int CustomerID { get; set; }
        public CartViewModel()
        {
            CustomerID = 1;
        }
    }
}
