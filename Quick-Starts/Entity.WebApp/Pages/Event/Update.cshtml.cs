﻿using GoodToCode.Framework.Hosting;
using GoodToCode.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Event
{
    public class UpdateModel : PageModel
    {
        public const string ResultMessage = "Result";
        public const string ValidationSummaryMessage = "ValidationSummary";
        private readonly IHttpCrudService<EventDto> crudService;

        [BindProperty]
        public EventDto Event { get; set; }

        public UpdateModel(IConfiguration configuration, IHttpCrudService<EventDto> crud)
        {
            crudService = crud;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            Event = await crudService.ReadAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            Event = await crudService.UpdateAsync(Event);

            if (!Event.IsNew)
                TempData[ResultMessage] = "Successfully Updated";
            else
                TempData[ResultMessage] = "Failed to Update";

            return Page();
        }
    }
}