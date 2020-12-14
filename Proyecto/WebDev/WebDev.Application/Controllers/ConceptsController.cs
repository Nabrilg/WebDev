using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.Application.Config;
using WebDev.Application.Mappers;
using WebDev.Application.Models;
using WebDev.Concepts;
using WebDev.Concepts.Entities;

namespace WebDev.Application.Controllers
{
    public class ConceptsController : Controller
    {
        private readonly ConceptsService conceptsService;

        public ConceptsController(IOptions<ApiConfiguration> apiConfiguration)
        {
            var _apiConfiguration = apiConfiguration.Value;
            conceptsService = new ConceptsService(_apiConfiguration.ApiConceptUrl);
        }

        // GET: ConceptsController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string vartoken = HttpContext.Session.GetString("Token");

            IList<ConceptDto> concepts = await conceptsService.GetConcepts(vartoken);

            var _conceptList = concepts.Select(conceptDto => ConceptMappers.MapperToConcept(conceptDto)).ToList();

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View(_conceptList);
        }

        // GET: ConceptsController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int concept_Id)
        {
            string vartoken = HttpContext.Session.GetString("Token");

            var conceptsFound = await conceptsService.GetConceptsByParams($"concept_Id={concept_Id}", vartoken);

            if (conceptsFound == null)
            {
                return NotFound();
            }

            var concept = ConceptMappers.MapperToConcept(conceptsFound);

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View(concept);
        }

        // GET: ConceptsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            string vartoken = HttpContext.Session.GetString("Token");
            HttpContext.Session.SetString("Token2",vartoken);

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View();
        }

        // POST: ConceptsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Concept concept)
        {
            string vartoken = HttpContext.Session.GetString("Token2");

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            try
            {
                if (ModelState.IsValid)
                {

                    await conceptsService.AddConcept(ConceptMappers.MapperToConceptDto(concept), vartoken);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConceptsController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int concept_Id)
        {
            string vartoken = HttpContext.Session.GetString("Token");

            var conceptFound = await conceptsService.GetConceptsByParams($"concept_Id={concept_Id}", vartoken);

            if (conceptFound == null)
            {
                return NotFound();
            }

            var concept = ConceptMappers.MapperToConcept(conceptFound);

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View(concept);
        }

        // POST: ConceptsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Concept concept)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            try
            {
                if (ModelState.IsValid)
                {
                    string vartoken = HttpContext.Session.GetString("Token");

                    await conceptsService.UpdateConcept(ConceptMappers.MapperToConceptDto(concept), vartoken);

                    return RedirectToAction(nameof(Index));
                }
                return View(concept);
            }
            catch
            {
                return View();
            }
        }

        // GET: ConceptsController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int concept_Id)
        {
            string vartoken = HttpContext.Session.GetString("Token");


            var conceptFound = await conceptsService.GetConceptsByParams($"concept_Id={concept_Id}", vartoken);

            if (conceptFound == null)
            {
                return NotFound();
            }

            var concept = ConceptMappers.MapperToConcept(conceptFound);

            HttpContext.Session.SetString("DELETE", JsonConvert.SerializeObject(conceptFound));

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

            return View(concept);
        }

        // POST: ConceptsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Concept concept)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

             ConceptDto concepts = ConceptMappers.MapperToConceptDto(JsonConvert.DeserializeObject<Concept>(HttpContext.Session.GetString("DELETE")));
            try
            {
                string vartoken = HttpContext.Session.GetString("Token");

                var conceptFound = await conceptsService.GetConceptsByParams($"concept_Id={concepts.concept_Id}", vartoken);

                if (conceptFound == null)
                {
                    return View();
                }

                await conceptsService.DeleteConcept(conceptFound.id, vartoken);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}