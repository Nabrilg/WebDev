using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDev.Application.Models;
using WebDev.Application.Config;
using WebDev.Services;
using Microsoft.Extensions.Options;
using WebDev.Services.Entities;

namespace WebDev.Application.Controllers
{
    
    [GlobalDataInjector]
    public class ConceptsController : Controller
    {
        private static List<Concept> _conceptList;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        private readonly ApiConfiguration _apiConfiguration;

        private ConceptsService conceptsService;

        // Inject the context in order to access the JWToken got in HomeController
        public ConceptsController(IOptions<ApiConfiguration> apiConfiguration, IHttpContextAccessor httpContextAccessor)
        {

            _apiConfiguration = apiConfiguration.Value;
            _httpContextAccessor = httpContextAccessor;
            conceptsService = new ConceptsService(_apiConfiguration.ApiConceptsUrl, _session.GetString("Token"));

        }

        // GET: ConceptsController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IList<ConceptDto> concepts = await conceptsService.GetConcepts();
            _conceptList = concepts.Select(conceptDto => MapperToConcept(conceptDto)).ToList();
            return View(_conceptList);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int concept_id)
        {
            var conceptFound = await conceptsService.GetConceptById(concept_id);

            if (conceptFound == null)
            {
                return NotFound();
            }

            var concept = MapperToConcept(conceptFound);

            return View(concept);
        }

        // POST: ConceptsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Concept concept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var conceptModified = await conceptsService.UpdateConcept(MapperToConceptDto(concept));

                    return RedirectToAction(nameof(Index));
                }
                return View(concept);
            }
            catch
            {
                return View();
            }
        }


        // GET: ConceptsController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var conceptFound = await conceptsService.GetConceptById(id);

            if (conceptFound == null)
            {
                return NotFound();
            }

            var concept = MapperToConcept(conceptFound);

            return View(concept);
        }

        // GET: ConceptsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConceptsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Concept concept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userAdded = await conceptsService.AddConcept(MapperToConceptDto(concept));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int concept_id)
        {
            var conceptFound = await conceptsService.GetConceptById(concept_id);

            if (conceptFound == null)
            {
                return NotFound();
            }

            var concept = MapperToConcept(conceptFound);

            return View(concept);
        }

        // POST: ConceptsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Concept concept)
        {
            try
            {
                var conceptDeleted = await conceptsService.DeleteConcept(concept.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Concept MapperToConcept(ConceptDto conceptDto)
        {
            return new Concept
            {
                Id = conceptDto.Id,
                Pxordx = conceptDto.Pxordx,
                Oldpxordx = conceptDto.Oldpxordx,
                Codetype = conceptDto.Codetype,
                Concept_class_id = conceptDto.Concept_class_id,
                Concept_id = conceptDto.Concept_id,
                Vocabulary_id = conceptDto.Vocabulary_id,
                Domain_id = conceptDto.Domain_id,
                Track = conceptDto.Track,
                Standard_concept = conceptDto.Standard_concept,
                Code = conceptDto.Code,
                Codewithperiods = conceptDto.Codewithperiods,
                Codescheme = conceptDto.Codescheme,
                Long_desc = conceptDto.Long_desc,
                Short_desc = conceptDto.Short_desc,
                Code_status = conceptDto.Code_status,
                Code_change = conceptDto.Code_change,
                Code_change_year = conceptDto.Code_change_year,
                Code_planned_type = conceptDto.Code_planned_type,
                Code_billing_status = conceptDto.Code_billing_status,
                Code_cms_claim_status = conceptDto.Code_cms_claim_status,
                Sex_cd = conceptDto.Sex_cd,
                Anat_or_cond = conceptDto.Anat_or_cond,
                Poa_code_status = conceptDto.Poa_code_status,
                Poa_code_change = conceptDto.Poa_code_change,
                Poa_code_change_year = conceptDto.Poa_code_change_year,
                Valid_start_date = conceptDto.Valid_start_date,
                Valid_end_date = conceptDto.Valid_end_date,
                Invalid_reason = conceptDto.Invalid_reason,
                Create_dt = conceptDto.Create_dt
            };
        }


        private ConceptDto MapperToConceptDto(Concept concept)
        {
            return ConceptDto.Build
            (
                id: concept.Id,
                pxordx: concept.Pxordx,
                oldpxordx: concept.Oldpxordx,
                codetype: concept.Codetype,
                concept_class_id: concept.Concept_class_id,
                concept_id: concept.Concept_id,
                vocabulary_id: concept.Vocabulary_id,
                domain_id: concept.Domain_id,
                track: concept.Track,
                standard_concept: concept.Standard_concept,
                code: concept.Code,
                codewithperiods: concept.Codewithperiods,
                codescheme: concept.Codescheme,
                long_desc: concept.Long_desc,
                short_desc: concept.Short_desc,
                code_status: concept.Code_status,
                code_change: concept.Code_change,
                code_change_year: concept.Code_change_year,
                code_planned_type: concept.Code_planned_type,
                code_billing_status: concept.Code_billing_status,
                code_cms_claim_status: concept.Code_cms_claim_status,
                sex_cd: concept.Sex_cd,
                anat_or_cond: concept.Anat_or_cond,
                poa_code_status: concept.Poa_code_status,
                poa_code_change: concept.Poa_code_change,
                poa_code_change_year: concept.Poa_code_change_year,
                valid_start_date: concept.Valid_start_date,
                valid_end_date: concept.Valid_end_date,
                invalid_reason: concept.Invalid_reason,
                create_dt: concept.Create_dt
            );
        }
    }
}
