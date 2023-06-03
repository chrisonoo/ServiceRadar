using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
using ServiceRadar.Application.Workshops.Commands.EditWorkshop;
using ServiceRadar.Application.Workshops.Queries.GetAllWorkshops;
using ServiceRadar.Application.Workshops.Queries.GetWorkshopByEncodedName;

namespace ServiceRadar.MVC.Controllers;
public class WorkshopController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public WorkshopController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateWorkshopCommand command)
    {
        if(!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Workshop/{encodedName}/Details")]
    public async Task<IActionResult> Details(string encodedName)
    {
        var workshopDto = await _mediator.Send(new GetWorkshopByEncodedNameQuery(encodedName));
        return View(workshopDto);
    }

    [Route("Workshop/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var workshopDto = await _mediator.Send(new GetWorkshopByEncodedNameQuery(encodedName));
        var workshopToEdit = _mapper.Map<EditWorkshopCommand>(workshopDto);

        return View(workshopToEdit);
    }

    [HttpPost]
    [Route("Workshop/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(EditWorkshopCommand command)
    {
        if(!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Index()
    {
        var workshops = await _mediator.Send(new GetAllWorkshopsQuery());
        return View(workshops);
    }
}
