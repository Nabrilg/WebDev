using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebDev.Application.Config;
using WebDev.Application.Mappers;
using WebDev.Application.Models;
using WebDev.Services;
using WebDev.Services.Entities;

namespace WebDev.Application.Controllers
{
    public class ConceptsController : Controller
    {
        #region Properties
        private List<Concept> conceptList;
        private readonly ConceptsService conceptsService;
        private readonly ConceptMapper conceptMapper;
        #endregion

        #region Intialize
        public ConceptsController(IOptions<ApiConfiguration> apiConfig)
        {
            ApiConfiguration apiConfiguration = apiConfig.Value;
            conceptsService = new ConceptsService(apiConfiguration.ApiConceptsUrl);
            conceptMapper = new ConceptMapper();
        }
        #endregion

        #region Http Methods
        // GET: ConceptsController
        public async Task<ActionResult> Index()
        {
            LoadSessionProperties();
            string token = HttpContext.Session.GetString("Token");

            // Set Object Model
            IList<ConceptDto> concepts = await conceptsService.GetConcepts(token);
            if (concepts != null)
            {
                conceptList = concepts.Select(conceptDto => conceptMapper.MapConceptDtoToConcept(conceptDto)).ToList();
            }

            return View(conceptList);
        }

        // GET: ConceptsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            LoadSessionProperties();
            string token = HttpContext.Session.GetString("Token");

            var conceptFound = await conceptsService.GetConceptById(id, token);

            if (conceptFound == null)
            {
                return NotFound();
            }

            var concept = conceptMapper.MapConceptDtoToConcept(conceptFound);

            return View(concept);
        }

        // GET: ConceptsController/Create
        public ActionResult Create()
        {
            LoadSessionProperties();

            return View();
        }

        // POST: ConceptsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Concept concept)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                if (ModelState.IsValid)
                {
                    await conceptsService.AddConcept(conceptMapper.MapConceptToConceptDto(concept), token);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConceptsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            LoadSessionProperties();
            string token = HttpContext.Session.GetString("Token");

            var conceptFound = await conceptsService.GetConceptById(id, token);

            if (conceptFound == null)
            {
                return NotFound();
            }

            var conceptToEdit = conceptMapper.MapConceptDtoToConcept(conceptFound);

            return View(conceptToEdit);
        }

        // POST: ConceptsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Concept concept)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");

                await conceptsService.UpdateConcept(conceptMapper.MapConceptToConceptDto(concept), concept.Id, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ConceptsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            LoadSessionProperties();
            string token = HttpContext.Session.GetString("Token");

            var conceptFound = await conceptsService.GetConceptById(id, token);

            if (conceptFound == null)
            {
                return NotFound();
            }

            var conceptToDelete = conceptMapper.MapConceptDtoToConcept(conceptFound);

            return View(conceptToDelete);
        }

        // POST: ConceptsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Concept concept)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");

                await conceptsService.DeleteConcept(concept.Id, token);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        // Loads to view data properties the session attributes that have been passed from previews controllers
        private void LoadSessionProperties()
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["Name"] = HttpContext.Session.GetString("Name");
        }
    }
}
