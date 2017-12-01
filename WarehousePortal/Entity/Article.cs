﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousePortal.Entity
{
    class Article
    {
        private long Id;
        private int ArtNo;
        private String Name;
        private String Description;
        private Decimal Price;
        private int Quant;


        public Article(long Id, int ArtNo, String Name, String Description, Decimal Price, int Quant)
        {
            if (ArtNo < 1)
            {
                throw new ArgumentOutOfRangeException("Article number must be greater than 0");
            }

            if (String.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Name must not be empty");
            }

            if (String.IsNullOrEmpty(Description))
            {
                throw new ArgumentException("Name must not be empty");
            }

            if (Price < 0.1m)
            {
                throw new ArgumentException("Price must be greater than 0");
            }

            if (Quant < 1)
            {
                throw new ArgumentException("Quant must be greater than 0");
            }

            this.Id = Id;
            this.ArtNo = ArtNo;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Quant = Quant;
        }

        public void AssignId(long Id)
        {
            this.Id = Id;
        }

        public long GetId()
        {
            return Id;
        }

        public int GetArtNo()
        {
            return ArtNo;
        }

        public String GetName()
        {
            return Name;
        }

        public String GetDescription()
        {
            return Description;
        }

        public Decimal GetPrice()
        {
            return Price;
        }
        public int GetQuant()
        {
            return Quant;
        }

        public String[] ToTableRowValues()
        {
            return new string[] { ArtNo.ToString(), Name, Description, Price.ToString(), Quant.ToString() };
        }



    }
}
