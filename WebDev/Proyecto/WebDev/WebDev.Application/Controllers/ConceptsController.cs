﻿using WebDev.Application.Config;
using WebDev.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using WebDev.Services;
using WebDev.Services.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Para poder usar la api de concepts
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
            conceptsService = new ConceptsService(_apiConfiguration.ApiConceptsUrl);
        }

       

      //Obtener los indices 
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
            conceptsService.Token = HttpContext.Session.GetString("TokenData");
            IList<ConceptDto> concepts = await conceptsService.GetConcepts();
            _conceptList = concepts.Select(conceptDto => MapperToConcept(conceptDto)).ToList();

            return View(_conceptList);
        }

        //Obtener los detalles de los conceptos 
        public async Task<ActionResult> Details(int conceptid)
        {

            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
            conceptsService.Token = HttpContext.Session.GetString("TokenData");
            var conceptFound = await conceptsService.GetConceptById(conceptid);
            if (conceptFound == null)
            {
                return NotFound();
            }
            var concept = MapperToConcept(conceptFound);
            return View(concept);
        }

        //Obtener los indices : Get para crear
        public ActionResult Create()
        {
            return View();
        }

        // Enviar al controlador el concepto creado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Concept concept)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
            conceptsService.Token = HttpContext.Session.GetString("TokenData");
            try
            {
                if (ModelState.IsValid)
                {
                    var conceptAdded = await conceptsService.AddConcept(MapperToConceptDto(concept));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Para editar los conceptos
        [HttpGet]
        public async Task<ActionResult> Edit(int conceptid)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
            conceptsService.Token = HttpContext.Session.GetString("TokenData");
            var conceptFound = await conceptsService.GetConceptById(conceptid);
            if (conceptFound == null)
            {
                return NotFound();
            }
            var concept = MapperToConcept(conceptFound);
            return View(concept);
        }

        // Para editar los conceptos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Concept concept)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
            conceptsService.Token = HttpContext.Session.GetString("TokenData");
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

        // Para poder obtener lo del eliminar el concepto
        [HttpGet]
        public async Task<ActionResult> Delete(int conceptid)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
            conceptsService.Token = HttpContext.Session.GetString("TokenData");
            var conceptFound = await conceptsService.GetConceptById(conceptid);
            if (conceptFound == null)
            {
                return NotFound();
            }
            var concept = MapperToConcept(conceptFound);
            return View(concept);
        }

        // Eliminar enviar el post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Concept concept)
        {
            ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
            ViewData["User"] = HttpContext.Session.GetString("User");
            conceptsService.Token = HttpContext.Session.GetString("TokenData");
            try
            {
                var userDeleted = await conceptsService.DeleteConcept(concept.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Los conceptos. Como se van a devolver en forma de lista

        private Concept MapperToConcept(ConceptDto conceptDto)
        {
            return new Concept
            {
                Id = conceptDto.Id,
                Pxordx = conceptDto.Pxordx,
                Oldpxordx = conceptDto.Oldpxordx,
                CodeType = conceptDto.CodeType,
                ConceptClassId = conceptDto.ConceptClassId,
                ConceptId = conceptDto.ConceptId,
                VocbularyId = conceptDto.VocbularyId,
                DomainId = conceptDto.DomainId,
                Track = conceptDto.Track,
                StandardConcept = conceptDto.StandardConcept,
                Code = conceptDto.Code,
                CodeWithPeriods = conceptDto.CodeWithPeriods,
                CodeScheme = conceptDto.CodeScheme,
                LongDesc = conceptDto.LongDesc,
                ShortDesc = conceptDto.ShortDesc,
                CodeStatus = conceptDto.CodeStatus,
                CodeChange = conceptDto.CodeChange,
                CodeChangeYear = conceptDto.CodeChangeYear,
                CodePlannedType = conceptDto.CodePlannedType,
                CodeBillingStatus = conceptDto.CodeBillingStatus,
                CodeCmsClaimStatus = conceptDto.CodeCmsClaimStatus,
                SexCd = conceptDto.SexCd,
                AnatOrCond = conceptDto.AnatOrCond,
                PoaCodeStatus = conceptDto.PoaCodeStatus,
                PoaCodeChange = conceptDto.PoaCodeChange,
                PoaCodeChangeYear = conceptDto.PoaCodeChangeYear,
                ValidStartDate = conceptDto.ValidStartDate,
                ValidEndDate = conceptDto.ValidEndDate,
                InvalidReason = conceptDto.InvalidReason,
                CreateDt = conceptDto.CreateDt
            };
        }

        //Construcion de la lista de conceptos en el cuerpo
        private ConceptDto MapperToConceptDto(Concept concept)
        {
            return ConceptDto.Build(
                id: concept.Id,
                pxordx: concept.Pxordx,
                oldpxordx: concept.Oldpxordx,
                codetype: concept.CodeType,
                conceptclassid: concept.ConceptClassId,
                conceptid: concept.ConceptId,
                vocbularyid: concept.VocbularyId,
                domainid: concept.DomainId,
                track: concept.Track,
                standardconcept: concept.StandardConcept,
                code: concept.Code,
                codewithperiods: concept.CodeWithPeriods,
                codescheme: concept.CodeScheme,
                longdesc: concept.LongDesc,
                shortdesc: concept.ShortDesc,
                codestatus: concept.CodeStatus,
                codechange: concept.CodeChange,
                codechangeyear: concept.CodeChangeYear,
                codeplannedtype: concept.CodePlannedType,
                codebillingstatus: concept.CodeBillingStatus,
                codecmsclaimstatus: concept.CodeCmsClaimStatus,
                sexcd: concept.SexCd,
                anatorcond: concept.AnatOrCond,
                poacodestatus: concept.PoaCodeStatus,
                poacodechange: concept.PoaCodeChange,
                poacodechangeyear: concept.PoaCodeChangeYear,
                validstartdate: concept.ValidStartDate,
                validenddate: concept.ValidEndDate,
                invalidreason: concept.InvalidReason,
                createdt: concept.CreateDt
            );
        }
    }
}
