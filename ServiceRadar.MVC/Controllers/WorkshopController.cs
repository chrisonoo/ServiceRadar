using MediatR;

using Microsoft.AspNetCore.Mvc;

using ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
using ServiceRadar.Application.Workshops.Queries.GetAllWorkshops;
using ServiceRadar.Application.Workshops.Queries.GetWorkshopByEncodedName;

namespace ServiceRadar.MVC.Controllers;
public class WorkshopController : Controller
{
    private readonly IMediator _mediator;

    public WorkshopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var workshops = await _mediator.Send(new GetAllWorkshopsQuery());
        return View(workshops);
    }

    [Route("Workshop/{encodedName}/Details")]
    public async Task<IActionResult> Details(string encodedName)
    {
        var workshopDto = await _mediator.Send(new GetWorkshopByEncodedNameQuery(encodedName));
        return View(workshopDto);
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
