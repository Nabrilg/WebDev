using WebDev.Application.Models;
using WebDev.Concepts.Entities;

namespace WebDev.Application.Mappers
{
    public static class ConceptMappers
    {
        public static Concept MapperToConcept(ConceptDto conceptDto)
        {
            return new Concept
            {
                id = conceptDto.id,
                pxordx = conceptDto.pxordx,
                oldpxordx = conceptDto.oldpxordx,
                codeType = conceptDto.codeType,
                concept_Class_Id = conceptDto.concept_Class_Id,
                concept_Id = conceptDto.concept_Id,
                vocabulary_Id = conceptDto.vocabulary_Id,
                domain_Id = conceptDto.domain_Id,
                track = conceptDto.track,
                standard_Concept = conceptDto.standard_Concept,
                code = conceptDto.code,
                codeWithPeriods = conceptDto.codeWithPeriods,
                codeScheme = conceptDto.codeScheme,
                long_Desc = conceptDto.long_Desc,
                short_Desc = conceptDto.short_Desc,
                code_Status = conceptDto.code_Status,
                code_Change = conceptDto.code_Change,
                code_Change_Year = conceptDto.code_Change_Year,
                code_Planned_Type = conceptDto.code_Planned_Type,
                code_Billing_Status = conceptDto.code_Billing_Status,
                code_Cms_Claim_Status = conceptDto.code_Cms_Claim_Status,
                sex_Cd = conceptDto.sex_Cd,
                anat_Or_Cond = conceptDto.anat_Or_Cond,
                poa_Code_Status = conceptDto.poa_Code_Status,
                poa_Code_Change = conceptDto.poa_Code_Change,
                poa_Code_Change_Year = conceptDto.poa_Code_Change_Year,
                valid_Start_Date = conceptDto.valid_Start_Date,
                valid_End_Date = conceptDto.valid_End_Date,
                invalid_Reason = conceptDto.invalid_Reason,
                create_Dt = conceptDto.create_Dt
            };
        }

        public static ConceptDto MapperToConceptDto(Concept concept)
        {
            return ConceptDto.Build(
                id: concept.id,
                pxordx: concept.pxordx,
                oldpxordx: concept.oldpxordx,
                codeType: concept.codeType,
                concept_Class_Id: concept.concept_Class_Id,
                concept_Id: concept.concept_Id,
                vocabulary_Id: concept.vocabulary_Id,
                domain_Id: concept.domain_Id,
                track: concept.track,
                standard_Concept: concept.standard_Concept,
                code: concept.code,
                codeWithPeriods: concept.codeWithPeriods,
                codeScheme: concept.codeScheme,
                long_Desc: concept.long_Desc,
                short_Desc: concept.short_Desc,
                code_Status: concept.code_Status,
                code_Change: concept.code_Change,
                code_Change_Year: concept.code_Change_Year,
                code_Planned_Type: concept.code_Planned_Type,
                code_Billing_Status: concept.code_Billing_Status,
                code_Cms_Claim_Status: concept.code_Cms_Claim_Status,
                sex_Cd: concept.sex_Cd,
                anat_Or_Cond: concept.anat_Or_Cond,
                poa_Code_Status: concept.poa_Code_Status,
                poa_Code_Change: concept.poa_Code_Change,
                poa_Code_Change_Year: concept.poa_Code_Change_Year,
                valid_Start_Date: concept.valid_Start_Date,
                valid_End_Date: concept.valid_End_Date,
                invalid_Reason: concept.invalid_Reason,
                create_Dt: concept.create_Dt
            );
        }
    }
}