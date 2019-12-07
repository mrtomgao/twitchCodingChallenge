using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lincoln.ViewModels;
using Lincoln.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lincoln.Controllers
{
  public class HomeController : Controller
  {
    private readonly GameCache gameCache;

    public HomeController(GameCache gameCache)
    {
      this.gameCache = gameCache;
    }

    public IActionResult Index(string id)
    {
      if (!String.IsNullOrEmpty(id))
      {
        var game = gameCache.Games.FirstOrDefault(g => g.Slug.ToUpper() == id.ToUpper());
        return View("Detail", game);
      }
      return View();
    }

    public IActionResult List(string search)
    {
      if (!String.IsNullOrEmpty(search))
      {
        var filteredGames = gameCache.Games.Where(g => g.Name.ToUpper().Contains(search.ToUpper())).ToList();
        return PartialView(filteredGames);
      }
      return PartialView(gameCache.Games);
    }


  }
}
