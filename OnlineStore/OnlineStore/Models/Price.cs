﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class Price
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

      // public Product Product { get; set; }

        public double BuyingPrice { get; set; }

        public double SalingPrice { get; set; }

        public Nullable<int> KDV { get; set; }

        public Nullable<int> CampaignID { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<Campaign> Campaigns { get; set; }
    }
}