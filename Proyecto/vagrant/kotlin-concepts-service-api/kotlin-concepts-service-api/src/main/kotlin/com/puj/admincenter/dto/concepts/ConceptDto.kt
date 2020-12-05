package com.puj.admincenter.dto.concepts

import com.puj.admincenter.domain.concepts.Concept

data class ConceptDto(
    val id: Int,
    val pxordx: String,
    val oldpxordx: String,
    val codetype: String,
    val concept_class_id: String,
    val concept_id: Int,	
    val vocabulary_id: String,
    val domain_id: String,
    val track: String,
    val standard_concept: String,
    val code: String,
    val codewithperiods: String,
    val codescheme: String,
    val long_desc: String,
    val short_desc: String,
    val code_status: String,
    val code_change: String,
    val code_change_year: Int,
    val code_planned_type: String,
    val code_billing_status: String,
    val code_cms_claim_status: String,
    val sex_cd: String?,
    val anat_or_cond: String,
    val poa_code_status: String,
    val poa_code_change: String,
    val poa_code_change_year: String,
    val valid_start_date: String,
    val valid_end_date: String,
    val invalid_reason: String,
    val create_dt: Int,
    val concept_status: Boolean
)