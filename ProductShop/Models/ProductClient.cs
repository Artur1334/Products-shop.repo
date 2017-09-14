using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace ProductShop.Models
{
    public class ProductClient
    {
        private string Base_URL = "http://localhost:54857/api/";

        public IEnumerable<Product> FindAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress=new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("products").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                }
                return null;
            }
            catch
            {
                return null;
            }   
        }
        public IEnumerable<Product> FindCategory(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("products").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Product>>().Result.Where(p=>p.Categorie.Equals(id));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public Product FindProduct(int? id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("products").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Product>>().Result.Single(p=>p.ProductID.Equals(id));
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}