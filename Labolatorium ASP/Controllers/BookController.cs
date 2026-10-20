using System.Text;
using Labolatorium_ASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_ASP.Controllers;

public class BookController : Controller
{
    //-----------Część C ----------------
    
    // GET /Book/Hello  → zwykły tekst
    public IActionResult Hello() => Content("Witaj w BookStore!", "text/plain; charset=utf-8");

    // GET /Book/Status?code=418 → dowolny kod statusu
    public IActionResult Status(int code = 200) => StatusCode(code);

    // GET /Book/Details/3 → widok
    public IActionResult Details(int id)
    {
        ViewBag.Id = id;
        return View();
    }
    
    //----------Część D ----------------
    
    // (1) query string:  /Book/Echo?name=Ala&count=3
    public IActionResult Echo([FromQuery] string name = "nieznajomy", [FromQuery] int count = 1) =>
        Content(string.Join("\n", Enumerable.Repeat($"Cześć, {name}!", Math.Clamp(count, 1, 20))));
    
    // (2) zmienna ścieżki:  /Book/Square/7   (segment {id} z domyślnej trasy)
    public IActionResult Square(int id) => Content($"{id}^2 = {id * id}");
    
    
    // (3) ciało żądania JSON:  POST /Book/Import
    [HttpPost]
    public IActionResult Import([FromBody] BookDto dto) => Json(new { received = dto.Title, dto.Isbn, dto.Price });
    
    // (4) surowy obiekt Request
    public IActionResult Inspect()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Method: {Request.Method}");
        sb.AppendLine($"Path:   {Request.Path}{Request.QueryString}");
        foreach (var h in Request.Headers) sb.AppendLine($"{h.Key}: {h.Value}");
        return Content(sb.ToString(), "text/plain; charset=utf-8");
    }
    
    //--------- Zadana do samodzielnego wykonania ----------------
    
    // Zadanie 1.
    //Dodaj akcję Sum(int a, int b) dostępną pod /Book/Sum?a=2&b=3,
    //zwracającą 5. Co się stanie po ?a=x? Jaki jest kod statusu i dlaczego (model binding)?
    
    public IActionResult Sum(int a, int b) => Content((a+b).ToString());
    
    // Zadanie 2.
    // Dodaj akcję zwracającą nagłówek User-Agent klienta przez Request.Headers.UserAgent.
    // Wywołaj ją z przeglądarki i z Postmana – porównaj wyniki.
    
    public IActionResult UserAgent() => Content(Request.Headers.UserAgent.ToString());

    // Zadanie 3.
    // Dodaj akcję Book/Health zwracającą Json(new { status = "ok", time = DateTime.Now }).
    // Zwróć uwagę na nagłówek Content-Type: application/json.
    
    public IActionResult Health() => Json(new { status = "ok", time = DateTime.Now });

}