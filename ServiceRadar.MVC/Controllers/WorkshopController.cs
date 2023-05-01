using Microsoft.AspNetCore.Mvc;

using ServiceRadar.Application.Dtos;
using ServiceRadar.Application.Services;

namespace ServiceRadar.MVC.Controllers;
public class WorkshopController : Controller
{
    private readonly IWorkshopService _workshopService;

    public WorkshopController(IWorkshopService workshopService)
    {
        _workshopService = workshopService;
    }

    public async Task<IActionResult> Index()
    {
        var workshops = await _workshopService.GetAll();
        return View(workshops);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkshopDto workshopDto)
    {
        if(!ModelState.IsValid)
        {
            return View(workshopDto);
        }
        await _workshopService.Create(workshopDto);
        return RedirectToAction(nameof(Create));
    }
}
