﻿namespace WEB_API_2024.Models.Database.Website.Master
{
    public class ProductDetail
    {
        public int id { get; set; }
        public string product_title { get; set; }
        public string product_id { get; set; }
        public decimal discount_percentage { get; set; }
        public decimal price { get; set; }
        public decimal mrp { get; set; }
        public string country_name { get; set; }
        public int quantity { get; set; }
        public string Stock_status { get; set; }
        public string product_url { get; set; }
        public string currency_code { get; set; }
        public string description { get; set; }
        public string thumbnail_image { get; set; }
        public string options { get; set; }
    }
}
