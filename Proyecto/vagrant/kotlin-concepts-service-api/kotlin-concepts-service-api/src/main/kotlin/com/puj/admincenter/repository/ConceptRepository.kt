package com.puj.admincenter.repository.concepts

import com.puj.admincenter.domain.concepts.Concept

import org.springframework.stereotype.Repository
import org.springframework.data.jpa.repository.JpaRepository
import org.springframework.data.jpa.repository.JpaSpecificationExecutor
import org.springframework.data.jpa.repository.Query
import org.springframework.data.jpa.repository.Modifying
import org.springframework.data.jpa.domain.Specification;
import org.springframework.transaction.annotation.Transactional
import org.springframework.data.repository.query.Param
import org.springframework.data.domain.Page
import org.springframework.data.domain.Pageable
import java.util.*
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

@Repository
interface ConceptRepository : JpaRepository<Concept, Int>,
                              JpaSpecificationExecutor<Concept> {


    @Query("""
        SELECT COUNT(concepts) > 0
        FROM Concept concepts
        WHERE concepts.concept_id = :concept_id
    """)
    fun existsByConceptId(@Param("concept_id") concept_id: Int): Boolean



    @Transactional
    @Modifying
    @Query("""
        UPDATE Concept concepts
        SET concept_status = :concept_status
        WHERE concept_id = :concept_id
    """)
    fun logicDeleteById(@Param("concept_id") concept_id: Int, @Param("concept_status") concept_status: Boolean): Int

    

}



class ConceptSpecification(private val concept_id: Int?, 
                           private val vocabulary_id: String?, 
                           private val domain_id: String?, 
                           private val word_desc: String?
                          ): Specification<Concept> {
    override fun toPredicate(root: Root<Concept>, query: CriteriaQuery<*>, cb: CriteriaBuilder): Predicate {
        val p = mutableListOf<Predicate>()
        concept_id?.let {
            p.add(cb.equal(root.get<Int>("concept_id"),concept_id))
        }

        vocabulary_id?.let {
            p.add(cb.equal(root.get<String>("vocabulary_id"),vocabulary_id))    
        }

        domain_id?.let {
            p.add(cb.equal(root.get<String>("domain_id"),domain_id))    
        }

        word_desc?.let {
            p.add(cb.like(root.get<String>("short_desc"),"%$word_desc%"))        
        }   
        return cb.and(*p.toTypedArray())
    }
}  