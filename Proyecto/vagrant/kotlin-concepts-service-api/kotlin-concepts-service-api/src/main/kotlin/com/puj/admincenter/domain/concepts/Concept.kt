package com.puj.admincenter.domain.concepts

import org.hibernate.annotations.GenericGenerator
import org.springframework.security.core.GrantedAuthority
import org.springframework.security.core.userdetails.UserDetails
import com.fasterxml.jackson.annotation.JsonIgnore
import java.io.Serializable
import java.util.*
import javax.persistence.*

@Entity
@Table(name = "concepts")
data class Concept(
    
    @Column(name = "id", nullable = false)
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    var id: Int = 0,

    @Column(nullable = false, unique = true)
    val pxordx: String = "",

    @Column(nullable = false)
    val oldpxordx: String = "",

    @Column(nullable = false)
    val codetype: String = "",

    @Column(nullable = false)
    val concept_class_id: String = "",

    @Id
    @Column(nullable = false)
    val concept_id: Int = 0,

    @Column(nullable = false)
    val vocabulary_id: String = "",

    @Column(nullable = false)
    val domain_id: String = "",

    @Column(nullable = false)
    val track: String = "",

    @Column(nullable = true)
    val standard_concept: String = "",

    @Column(nullable = false)
    val code: String = "",

    @Column(nullable = false)
    val codewithperiods: String = "",

    @Column(nullable = false)
    val codescheme: String = "",

    @Column(nullable = false)
    val long_desc: String = "",

    @Column(nullable = true)
    val short_desc: String = "",

    @Column(nullable = true)
    val code_status: String = "",

    @Column(nullable = true)
    val code_change: String = "",

    @Column(nullable = true)
    val code_change_year: Int = 0,

    @Column(nullable = true)
    val code_planned_type: String = "",

    @Column(nullable = true)
    val code_billing_status: String = "",

    @Column(nullable = true)
    val code_cms_claim_status: String = "", 

    @Column(nullable = true)
    var sex_cd: String? = "", 

    @Column(nullable = true)
    val anat_or_cond: String = "", 

    @Column(nullable = true)
    val poa_code_status: String = "", 

    @Column(nullable = true)
    val poa_code_change: String = "", 

    @Column(nullable = true)
    val poa_code_change_year: String = "",

    @Column(nullable = true)
    val valid_start_date: String = "",

    @Column(nullable = true)
    val valid_end_date: String = "",

    @Column(nullable = true)
    val invalid_reason: String = "",

    @Column(nullable = true)
    val create_dt: Int = 0,

    @Column(nullable = true)
    val concept_status: Boolean = true
)