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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkshopDto workshopDto)
    {
        await _workshopService.Create(workshopDto);
        return RedirectToAction(nameof(Create));
    }
}
