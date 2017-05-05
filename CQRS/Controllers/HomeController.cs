﻿using System.Threading.Tasks;
using Erazer.Services.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Erazer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            //var ticket = await _mediator.Send(new TicketQuery {Id = id });
            //var events = await _mediator.Send(new TicketEventsQuery {Page = 1, TicketId = id});
            return View();
        }

        public IActionResult Ticket(string id = "20d0454a-a13d-46fc-842b-43287b6f1f2e")
        {
            return View(model: id);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}