using WebDev.Application.Models;
using WebDev.Services.Entities;

namespace WebDev.Application.Mappers
{
    public class ConceptMapper
    {
        public Concept MapConceptDtoToConcept(ConceptDto conceptDto)
        {
            Concept concept = new Concept()
            {
                Id = conceptDto.Id,
                Pxordx = conceptDto.Pxordx,
                OldPxordx = conceptDto.OldPxordx,
                CodeType = conceptDto.CodeType,
                ConceptClassId = conceptDto.ConceptClassId,
                ConceptId = conceptDto.ConceptId,
                VocabularyId = conceptDto.VocabularyId,
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
            return concept;
        }

        public ConceptDto MapConceptToConceptDto(Concept concept)
        {
            return ConceptDto.Build(
                id: concept.Id,
                pxordx: concept.Pxordx,
                oldPxordx: concept.OldPxordx,
                codeType: concept.CodeType,
                conceptClassId: concept.ConceptClassId,
                conceptId: concept.ConceptId,
                vocabularyId: concept.VocabularyId,
                domainId: concept.DomainId,
                track: concept.Track,
                standardConcept: concept.StandardConcept,
                code: concept.Code,
                codeWithPeriods: concept.CodeWithPeriods,
                codeScheme: concept.CodeScheme,
                longDesc: concept.LongDesc,
                shortDesc: concept.ShortDesc,
                codeStatus: concept.CodeStatus,
                codeChange: concept.CodeChange,
                codeChangeYear: concept.CodeChangeYear,
                codePlannedType: concept.CodePlannedType,
                codeBillingStatus: concept.CodeBillingStatus,
                codeCmsClaimStatus: concept.CodeCmsClaimStatus,
                sexCd: concept.SexCd,
                anatOrCond: concept.AnatOrCond,
                poaCodeStatus: concept.PoaCodeStatus,
                poaCodeChange: concept.PoaCodeChange,
                poaCodeChangeYear: concept.PoaCodeChangeYear,
                validStartDate: concept.ValidStartDate,
                validEndDate: concept.ValidEndDate,
                invalidReason: concept.InvalidReason,
                createDt: concept.CreateDt);
        }
    }
}
