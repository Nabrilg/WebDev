using System.ComponentModel.DataAnnotations;

namespace WebDev.Application.Models
{
    public class Concept
    {
        [Key]
        public int Id { get; set; }

        public string Pxordx { get; set; }
        public string Oldpxordx { get; set; }
        public string CodeType { get; set; }
        public string ConceptClassId { get; set; }
        public int ConceptId { get; set; }
        public string VocbularyId { get; set; }
        public string DomainId { get; set; }
        public string Track { get; set; }
        public string StandardConcept { get; set; }
        public string Code { get; set; }
        public string CodeWithPeriods { get; set; }
        public string CodeScheme { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }
        public string CodeStatus { get; set; }
        public string CodeChange { get; set; }
        public int CodeChangeYear { get; set; }
        public string CodePlannedType { get; set; }
        public string CodeBillingStatus { get; set; }
        public string CodeCmsClaimStatus { get; set; }
        public string SexCd { get; set; }
        public string AnatOrCond { get; set; }
        public string PoaCodeStatus { get; set; }
        public string PoaCodeChange { get; set; }
        public string PoaCodeChangeYear { get; set; }
        public string ValidStartDate { get; set; }
        public string ValidEndDate { get; set; }
        public string InvalidReason { get; set; }
        public int CreateDt { get; set; }
    }
}