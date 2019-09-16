﻿using GoodToCode.Entity.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Person
{
    public class CreateModel : PageModel
    {
        public const string ResultMessage = "Result";
        public const string ValidationSummaryMessage = "ValidationSummary";
        private readonly IHttpCrudService<PersonDto> crudService;

        [BindProperty]
        public PersonDto Person { get; set; }

        public CreateModel(IConfiguration configuration, IHttpCrudService<PersonDto> crud)
        {
            crud.Uri = new System.Uri($@"{configuration["AppSettings:MyWebService"]}/Person");
            crudService = crud;
        }

        public IActionResult OnGet()
        {
            Person = new PersonDto();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Person = await crudService.CreateAsync(Person);
            if (!Person.IsNew)
                TempData[ResultMessage] = "Successfully created";
            else
                TempData[ResultMessage] = "Failed to create";

            return Page();
        }
    }
}