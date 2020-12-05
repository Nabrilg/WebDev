package com.puj.admincenter.service

import com.puj.admincenter.domain.concepts.Concept
import com.puj.admincenter.dto.concepts.ConceptDto
import com.puj.admincenter.dto.IdResponseDto
import com.puj.admincenter.repository.concepts.ConceptRepository
import com.puj.admincenter.repository.concepts.ConceptSpecification


import org.springframework.data.domain.Pageable
import org.springframework.data.domain.Page
import org.springframework.security.crypto.bcrypt.BCrypt
import org.springframework.stereotype.Service
import org.springframework.http.ResponseEntity
import org.springframework.http.HttpStatus
import org.springframework.web.bind.annotation.*
import org.slf4j.LoggerFactory
import java.io.Serializable
import java.util.*

@Service
class ConceptService(private val conceptRepository: ConceptRepository) {
    companion object {
        val LOG = LoggerFactory.getLogger(ConceptService::class.java)!!
    }

    fun getConcepts(concept_id: Int?,
                    vocabulary_id: String?,               
                    domain_id: String?,
                    word_desc: String?,
                    authorization: String): ResponseEntity<*> {
        val concept = conceptRepository.findAll(ConceptSpecification(concept_id,
                                                                     vocabulary_id,
                                                                     domain_id,
                                                                     word_desc
                                                                     ))
        return if (concept.isNullOrEmpty()) {
            val messageError = "No concepts found"
            LOG.error(messageError)
            return ResponseEntity<Any>(messageError,
                                       HttpStatus.NOT_FOUND)
        } else {
            ResponseEntity.ok(concept)
        }
    }

    fun createConcept(conceptDto: ConceptDto): ResponseEntity<*> {
        if (conceptRepository.existsByConceptId(conceptDto.concept_id)) {
            val messageError = "Concept with concept_id_ ${conceptDto.concept_id} already exists."
            LOG.error(messageError)
            return ResponseEntity<Any>(messageError,
                                       HttpStatus.CONFLICT)
        }
        val concept = Concept(pxordx = conceptDto.pxordx,
                            oldpxordx = conceptDto.oldpxordx,
                            codetype = conceptDto.codetype,
                            concept_class_id = conceptDto.concept_class_id,
                            concept_id = conceptDto.concept_id,	
                            vocabulary_id = conceptDto.vocabulary_id,
                            domain_id = conceptDto.domain_id,
                            track = conceptDto.track,
                            standard_concept = conceptDto.standard_concept,
                            code = conceptDto.code,
                            codewithperiods = conceptDto.codewithperiods,
                            codescheme = conceptDto.codescheme,
                            long_desc = conceptDto.long_desc,
                            short_desc = conceptDto.short_desc,
                            code_status = conceptDto.code_status,
                            code_change = conceptDto.code_change,
                            code_change_year = conceptDto.code_change_year,
                            code_planned_type = conceptDto.code_planned_type,
                            code_billing_status = conceptDto.code_billing_status,
                            code_cms_claim_status = conceptDto.code_cms_claim_status,
                            sex_cd = conceptDto.sex_cd,
                            anat_or_cond = conceptDto.anat_or_cond,
                            poa_code_status = conceptDto.poa_code_status,
                            poa_code_change = conceptDto.poa_code_change,
                            poa_code_change_year = conceptDto.poa_code_change_year,
                            valid_start_date = conceptDto.valid_start_date,
                            valid_end_date = conceptDto.valid_end_date,
                            invalid_reason = conceptDto.invalid_reason,
                            create_dt = conceptDto.create_dt,
                            concept_status = conceptDto.concept_status
                            )
        val conceptSaved = conceptRepository.save(concept)
        LOG.info("Concept ${conceptDto.concept_id} created with id ${conceptSaved.id}")
        val responseDto = IdResponseDto(conceptSaved.id.toLong())
        return ResponseEntity<IdResponseDto>(responseDto,
                                             HttpStatus.CREATED)
    }


    fun deleteConcept(concept_id: Int,
                authorization: String): ResponseEntity<*> {
        if (conceptRepository.existsByConceptId(concept_id)) {
            val conceptDeleted = conceptRepository.logicDeleteById(concept_id, false)
            if (conceptDeleted > 0){
                val message = "Concept with concept_id_ ${concept_id} successfulluy deactivated."
                return ResponseEntity<Any>(message,
                                            HttpStatus.ACCEPTED)
            }
            val message2 = "An error has ocurred. Concept with concept_id_ ${concept_id} was not deactivated."
            return ResponseEntity<Any>(message2,
                                             HttpStatus.CONFLICT)
        }
        val messageError = "Concept with concept_id_ ${concept_id} does not exist."
        LOG.error(messageError)
        return ResponseEntity<Any>(messageError,
                                    HttpStatus.CONFLICT)
    }

    fun updateConcept(conceptDto: ConceptDto) : ResponseEntity<*> {
        if (conceptRepository.existsByConceptId(conceptDto.concept_id)) {
            val message2 = "----------------Concept value id = ${conceptDto.id}.------------------"
            LOG.info(message2)
            val concept = Concept(id = conceptDto.id,
                            pxordx = conceptDto.pxordx,
                            oldpxordx = conceptDto.oldpxordx,
                            codetype = conceptDto.codetype,
                            concept_class_id = conceptDto.concept_class_id,
                            concept_id = conceptDto.concept_id,	
                            vocabulary_id = conceptDto.vocabulary_id,
                            domain_id = conceptDto.domain_id,
                            track = conceptDto.track,
                            standard_concept = conceptDto.standard_concept,
                            code = conceptDto.code,
                            codewithperiods = conceptDto.codewithperiods,
                            codescheme = conceptDto.codescheme,
                            long_desc = conceptDto.long_desc,
                            short_desc = conceptDto.short_desc,
                            code_status = conceptDto.code_status,
                            code_change = conceptDto.code_change,
                            code_change_year = conceptDto.code_change_year,
                            code_planned_type = conceptDto.code_planned_type,
                            code_billing_status = conceptDto.code_billing_status,
                            code_cms_claim_status = conceptDto.code_cms_claim_status,
                            sex_cd = conceptDto.sex_cd,
                            anat_or_cond = conceptDto.anat_or_cond,
                            poa_code_status = conceptDto.poa_code_status,
                            poa_code_change = conceptDto.poa_code_change,
                            poa_code_change_year = conceptDto.poa_code_change_year,
                            valid_start_date = conceptDto.valid_start_date,
                            valid_end_date = conceptDto.valid_end_date,
                            invalid_reason = conceptDto.invalid_reason,
                            create_dt = conceptDto.create_dt,
                            concept_status = conceptDto.concept_status)
            val conceptSaved = conceptRepository.save(concept)
            val messageError = "Concept with concept_id_ ${conceptDto.concept_id} updated successfully."
            LOG.info("Concept ${conceptDto.concept_id} updated with id ${conceptSaved.id}")
            return ResponseEntity<Any>(messageError,
                                       HttpStatus.ACCEPTED)
        }
        val messageError = "Concept with concept_id_ ${conceptDto.concept_id} does not exist."
        LOG.error(messageError)
        return ResponseEntity<Any>(messageError,
                                    HttpStatus.CONFLICT)

    }
}