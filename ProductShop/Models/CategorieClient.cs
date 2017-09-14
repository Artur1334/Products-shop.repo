using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Headers;
using System.Net.Http;
using EntitieServices.EntitiProductShop;

namespace ProductShop.Models
{
    public class CategorieClient
    {
        private string Base_URL = "http://localhost:54857/api/";

        public IEnumerable<Category> FindAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Categories").Result;
                if (response.IsSuccessStatusCode)
                 return response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}