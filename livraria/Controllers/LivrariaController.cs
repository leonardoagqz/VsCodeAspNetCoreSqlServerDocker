using livraria.Models;
using Microsoft.AspNetCore.Mvc;


namespace livraria.Controllers;

//Controladro LivrariaController
public class LivrariaController : Controller
{
    //Injetando instancia do Contexto
    private readonly AppDbContext _context;

    //Contrutor
    public LivrariaController(AppDbContext context)
    {
        _context = context;
    }


    //Métodos Actions

    //Método para exibir a lista de livros
    [HttpGet]
    public IActionResult Index()
    {
        var books = _context.Livros.ToList(); //obtem a lista de livros
        return View(books);

    }


    //Método para criar um livro
    [HttpGet]
    public IActionResult Create()
    {
        return View();

    }

    [HttpPost]
    public async Task<IActionResult> Create(Livro livro)
    {
        if (ModelState.IsValid) //validando livro
        {
            try
            {
                _context.Livros.Add(livro); //incluindo livro no cnotexto (banco)
                await _context.SaveChangesAsync(); //salva no banco
                return RedirectToAction("Index"); //retorna para Index os livros criados
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,
                $"Algo de errado {ex.Message}");
                throw;
            }
        }
        ModelState.AddModelError(string.Empty,
        $"Algo de errado, modelo inválido");
        return View(livro);

    }
}