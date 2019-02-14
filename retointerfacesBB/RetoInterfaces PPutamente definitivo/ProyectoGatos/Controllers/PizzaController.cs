using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ProyectoPizzas.Models;

namespace ProyectoPizza.Controllers
{

    public class PizzaController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Pizza a pelo.";

            List<Pizza> prodList = await GetAllProduktuakAsync();

            //prodList.Sort((x, y) => x.nombre.CompareTo(y.nombre));
            

            return View(prodList);
        }

        public IActionResult create()
        {
            return View();
        }


        public static async Task<List<Pizza>> GetAllProduktuakAsync()
        {
            // WEB API Rest-a dagoen zerbitzariko URL-a
            HttpClient httpClient = StupidConnection();

            //HttpClient httpClient = new HttpClient();
            // Produktu guztiak gordeko diren Lista sortu
            List<Pizza> prodList = new List<Pizza>();

            // Web API zerbitzura eskaria bidali, produktua/getAll produktu guztiak hartzeko
            HttpResponseMessage Res = await httpClient.GetAsync("pizzas/getAll");

            // APIaren erantzuna arrakastatsua izan den edo ez begiratu
            if (Res.IsSuccessStatusCode)
            {
                // Erantzuna, aldagai batean gorde
                var prodResponse = Res.Content.ReadAsStringAsync().Result;

                // WEB APItik jasotako erantzuna deserializatu eta Produktuen lista batean gorde
                prodList = JsonConvert.DeserializeObject<List<Pizza>>(prodResponse);
            }

            return prodList;
        }
        [HttpPost]
        public ActionResult create(Pizza pizza)
        {
            HttpClient httpClient = StupidConnection();
            //Pruebas
            //Ruta aldatzeko
            var response = httpClient.PostAsJsonAsync<Pizza>(
                "pizzas/", pizza);
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return RedirectToAction("Index");

            // return URI of the created resource.
            //return response.Headers.Location;
        }
        public static HttpClient StupidConnection()
        {
            HttpClient httpClient = new HttpClient();
            string url = "http://127.0.0.1:8080/";

            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Clear();

            // Eskaria egiteko datuen formatua definitu
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
        public ActionResult Delete(string id)
        {
            {
                HttpClient httpClient = StupidConnection();
                //patha aldatzeko
                var coso = httpClient.DeleteAsync(
                    $"pizzas/{id}");
                coso.Wait();
                var respuesta = coso.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("Index");

        }
    }
}