package com.puj.admincenter.controller

import com.puj.admincenter.domain.concepts.Concept
import com.puj.admincenter.dto.concepts.ConceptDto
import com.puj.admincenter.service.ConceptService

import org.springframework.http.HttpStatus
import org.springframework.http.ResponseEntity
import org.springframework.security.access.prepost.PreAuthorize
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken
import org.springframework.web.bind.annotation.*
import org.springframework.web.bind.annotation.CrossOrigin
import org.springframework.web.context.request.RequestContextHolder
import org.springframework.web.context.request.ServletRequestAttributes
import javax.validation.Valid
import javax.servlet.http.HttpServletRequest
import java.security.Principal
import java.util.Date
import org.slf4j.Logger
import org.slf4j.LoggerFactory

import org.springframework.http.MediaType

@CrossOrigin
@RequestMapping("/concepts")
@RestController
class ConceptController(private val conceptService: ConceptService) {

    @GetMapping(
        produces = ["application/json"]     
    )
    fun getConcepts(@RequestParam(value = "concept_id", required = false) concept_id: Int?,
                    @RequestParam(value = "vocabulary_id", required = false) vocabulary_id: String?,
                    @RequestParam(value = "domain_id", required = false) domain_id: String?,
                    @RequestParam(value = "word_desc", required = false) word_desc: String?,
                    @RequestHeader(value="authorization", required=true) authorization: String): ResponseEntity<*>
        = conceptService.getConcepts(concept_id, vocabulary_id, domain_id, word_desc, authorization)

    @PostMapping(
         consumes = ["application/json"], 
         produces = ["application/json"]
    )
    fun createConcept(@RequestBody @Valid conceptDto: ConceptDto, 
               @RequestHeader(value="authorization", required=true) authorization: String): ResponseEntity<*>
        = conceptService.createConcept(conceptDto)

    @DeleteMapping(
        value = ["/{concept_id}"], 
        produces = ["application/json"]
    )
    fun deleteConcept(@PathVariable concept_id: Int,
               @RequestHeader(value="authorization", required=true) authorization: String): ResponseEntity<*>
        = conceptService.deleteConcept(concept_id, authorization)

    @PutMapping( 
        produces = ["application/json"]
    )
    fun updateConcept(@RequestBody @Valid conceptDto: ConceptDto, 
               @RequestHeader(value="authorization", required=true) authorization: String): ResponseEntity<*>
        = conceptService.updateConcept(conceptDto)
} 