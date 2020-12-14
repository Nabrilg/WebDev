using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDev.Application.Models;
using WebDev.Application.Config;
using Microsoft.Extensions.Options;
using WebDev.Services.Entities;
using WebDev.Services;

namespace WebDev.Application.Controllers
{
    public class ConceptsController : Controller
    {
        private static List<Concept> _conceptList;
        private readonly ApiConfiguration _apiConfiguration;
        private ConceptsService conceptsService;

        public ConceptsController(IOptions<ApiConfiguration> apiConfiguration)
        {
            _apiConfiguration = apiConfiguration.Value;
            conceptsService = new ConceptsService(_apiConfiguration.ApiUsersUrl);
        }

        // GET: ConceptsController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            conceptsService.TokenUser = HttpContext.Session.GetString("Token");
            IList<ConceptDto> concepts = await conceptsService.GetConcepts();

            _conceptList = concepts.Select(conceptDto => MapperToConcept(conceptDto)).ToList();

            return View(_conceptList);
        }

        // GET: ConceptsController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(string concept_id)
        {
            conceptsService.TokenUser = HttpContext.Session.GetString("Token");
            var conceptFound = await conceptsService.FindConcept(Convert.ToInt32(concept_id));

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
                    conceptsService.TokenUser = HttpContext.Session.GetString("Token");
                    var conceptAdded = await conceptsService.AddConcept(MapperToConceptDto(concept));
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
        public async Task<ActionResult> Edit(string concept_id)
        {
            conceptsService.TokenUser = HttpContext.Session.GetString("Token");
            var conceptFound = await conceptsService.FindConcept(Convert.ToInt32(concept_id));

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
                    conceptsService.TokenUser = HttpContext.Session.GetString("Token");
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

        // GET: ConceptsController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(string concept_id)
        {
            conceptsService.TokenUser = HttpContext.Session.GetString("Token");
            var conceptFound = await conceptsService.FindConcept(Convert.ToInt32(concept_id));

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
                conceptsService.TokenUser = HttpContext.Session.GetString("Token");
                var conceptFound = await conceptsService.FindConcept(concept.Concept_Id);

                if (conceptFound == null)
                {
                    return View();
                }

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
                Id = conceptDto.id,
                Pxordx = conceptDto.pxordx,
                Oldpxordx = conceptDto.oldpxordx,
                CodeType = conceptDto.codetype,
                Concept_Class_Id = conceptDto.concept_class_id,
                Concept_Id = conceptDto.concept_id,
                Vocabulary_Id = conceptDto.vocabulary_id,
                Domain_Id = conceptDto.domain_id,
                Track = conceptDto.track,
                Standard_Concept = conceptDto.standard_concept,
                Code = conceptDto.code,
                CodeWithPeriods = conceptDto.codewithperiods,
                CodeScheme = conceptDto.codescheme,
                Long_Desc = conceptDto.long_desc,
                Short_Desc = conceptDto.short_desc,
                Code_Status = conceptDto.code_status,
                Code_Change = conceptDto.code_change,
                Code_Change_Year = conceptDto.code_change_year,
                Code_Planned_Type = conceptDto.code_planned_type,
                Code_Billing_Status = conceptDto.code_billing_status,
                Code_Cms_Claim_Status = conceptDto.code_cms_claim_status,
                Sex_Cd = conceptDto.sex_cd,
                Anat_Or_Cond = conceptDto.anat_or_cond,
                Poa_Code_Status = conceptDto.poa_code_status,
                Poa_Code_Change = conceptDto.poa_code_change,
                Poa_Code_Change_Year = conceptDto.poa_code_change_year,
                Valid_Start_Date = conceptDto.valid_start_date,
                Valid_End_Date = conceptDto.valid_end_date,
                Invalid_Reason = conceptDto.invalid_reason,
                Create_Dt = conceptDto.create_dt
            };
        }

        private ConceptDto MapperToConceptDto(Concept concept)
        {
            return ConceptDto.Build(
              id: concept.Id,
              pxordx: concept.Pxordx,
              oldpxordx: concept.Oldpxordx,
              codetype: concept.CodeType,
              concept_class_id: concept.Concept_Class_Id,
              concept_id: concept.Concept_Id,
              vocabulary_id: concept.Vocabulary_Id,
              domain_id: concept.Domain_Id,
              track: concept.Track,
              standard_concept: concept.Standard_Concept,
              code: concept.Code,
              codewithperiods: concept.CodeWithPeriods,
              codescheme: concept.CodeScheme,
              long_desc: concept.Long_Desc,
              short_desc: concept.Short_Desc,
              code_status: concept.Code_Status,
              code_change: concept.Code_Change,
              code_change_year: concept.Code_Change_Year,
              code_planned_type: concept.Code_Planned_Type,
              code_billing_status: concept.Code_Billing_Status,
              code_cms_claim_status: concept.Code_Cms_Claim_Status,
              sex_cd: concept.Sex_Cd,
              anat_or_cond: concept.Anat_Or_Cond,poa_code_status: concept.Poa_Code_Status,
              poa_code_change: concept.Poa_Code_Change,
              poa_code_change_year: concept.Poa_Code_Change_Year,
              valid_start_date: concept.Valid_Start_Date,
              valid_end_date: concept.Valid_End_Date,
              invalid_reason: concept.Invalid_Reason,
              create_dt: concept.Create_Dt
            );
        }
    }
}
