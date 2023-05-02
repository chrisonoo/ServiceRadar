using MediatR;

using Microsoft.AspNetCore.Mvc;

using ServiceRadar.Application.Services;
using ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Application.Workshops.Queries.GetAllWorkshops;

namespace ServiceRadar.MVC.Controllers;
public class WorkshopController : Controller
{
    private readonly IWorkshopService _workshopService;
    private readonly IMediator _mediator;

    public WorkshopController(IWorkshopService workshopService, IMediator mediator)
    {
        _workshopService = workshopService;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var workshops = await _mediator.Send(new GetAllWorkshopsQuery());
        return View(workshops);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkshopCommand command)
    {
        if(!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}
