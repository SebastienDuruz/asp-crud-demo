using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.Models;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private Uri _baseAddress = new Uri("https://localhost:7138");
    private readonly ILogger<HomeController> _logger;
    private HttpClient _httpClient;

    public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
    {
        _logger = logger;

        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        List<Article> articles = new List<Article>();
        HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress);
        if (response.IsSuccessStatusCode)
        {
            try
            {
                articles = JsonConvert.DeserializeObject<List<Article>>(await response.Content.ReadAsStringAsync());
            }
            catch(Exception ex)
            {
                articles = new List<Article>();
            }
        }
        
        ViewData["Articles"] = articles;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
