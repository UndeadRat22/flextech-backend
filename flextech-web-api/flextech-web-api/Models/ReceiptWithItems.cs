﻿using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopsnap.Models
{
    public class ReceiptWithItems
    {
        public Receipt UserReceipt;
        public List<ReceiptItem> UserReceiptItems;
    }
}