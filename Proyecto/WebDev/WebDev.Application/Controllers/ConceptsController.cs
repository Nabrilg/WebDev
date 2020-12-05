using System;
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


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDev.Application.Controllers
{
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
            ViewData["IsUserLogged"] = _session.GetString("IsUserLogged");
            ViewData["User"] = _session.GetString("User");
            ViewData["Token"] = _session.GetString("Token");
            IList<ConceptDto> concepts = await conceptsService.GetConcepts();
            _conceptList = concepts.Select(conceptDto => MapperToConcept(conceptDto)).ToList();
            return View(_conceptList);
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
    }
}
