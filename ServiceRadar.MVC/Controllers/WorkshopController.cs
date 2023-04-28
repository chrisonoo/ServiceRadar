using Microsoft.AspNetCore.Mvc;

using ServiceRadar.Application.Services;
using ServiceRadar.Domain.Entities;

namespace ServiceRadar.MVC.Controllers;
public class WorkshopController : Controller
{
    private readonly IWorkshopService _workshopService;

    public WorkshopController(IWorkshopService workshopService)
    {
        _workshopService = workshopService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Workshop workshop)
    {
        await _workshopService.Create(workshop);
        return RedirectToAction(nameof(Create)); // TODO: refactor
    }
}
