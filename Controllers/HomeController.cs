using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using P3_Continua.Models;
using P3_Continua.Services;

namespace P3_Continua.Controllers;

public class HomeController : Controller
{
    private readonly JsonPlaceholderService _service;

    public HomeController(JsonPlaceholderService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _service.GetPostsAsync();
        return View(posts);
    }
    public async Task<IActionResult> Details(int id)
    {
        var post = await _service.GetPostAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        var user = await _service.GetUserAsync(post.UserId);
        var comments = await _service.GetCommentsForPostAsync(id);

        var viewModel = new PostDetailsViewModel
        {
            Post = post,
            User = user ?? new(),
            Comments = comments
        };

        return View(viewModel);
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
