using Newtonsoft.Json;

namespace WebDev.Services.Entities
{
    public class ConceptDto
    {
        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pxordx")]
        public string Pxordx { get; set; }

        [JsonProperty("oldpxordx")]
        public string OldPxordx { get; set; }

        [JsonProperty("codeType")]
        public string CodeType { get; set; }

        [JsonProperty("concept_Class_Id")]
        public string ConceptClassId { get; set; }

        [JsonProperty("concept_Id")]
        public int ConceptId { get; set; }
        
        [JsonProperty("vocabulary_Id")]
        public string VocabularyId { get; set; }
        
        [JsonProperty("domain_Id")]
        public string DomainId { get; set; }
        
        [JsonProperty("track")]
        public string Track { get; set; }
        
        [JsonProperty("standard_Concept")]
        public string StandardConcept { get; set; }
        
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("codeWithPeriods")]
        public string CodeWithPeriods { get; set; }
        
        [JsonProperty("codeScheme")]
        public string CodeScheme { get; set; }
        
        [JsonProperty("long_Desc")]
        public string LongDesc { get; set; }
        
        [JsonProperty("short_Desc")]
        public string ShortDesc { get; set; }
        
        [JsonProperty("code_Status")]
        public string CodeStatus { get; set; }
        
        [JsonProperty("code_Change")]
        public string CodeChange { get; set; }
        
        [JsonProperty("code_Change_Year")]
        public int CodeChangeYear { get; set; }
        
        [JsonProperty("code_Planned_Type")]
        public string CodePlannedType { get; set; }
        
        [JsonProperty("code_Billing_Status")]
        public string CodeBillingStatus { get; set; }
        
        [JsonProperty("code_Cms_Claim_Status")]
        public string CodeCmsClaimStatus { get; set; }
        
        [JsonProperty("sex_Cd")]
        public string SexCd { get; set; }
        
        [JsonProperty("anat_Or_Cond")]
        public string AnatOrCond { get; set; }
        
        [JsonProperty("poa_Code_Status")]
        public string PoaCodeStatus { get; set; }
        
        [JsonProperty("poa_Code_Change")]
        public string PoaCodeChange { get; set; }
        
        [JsonProperty("poa_Code_Change_Year")]
        public string PoaCodeChangeYear { get; set; }
        
        [JsonProperty("valid_Start_Date")]
        public string ValidStartDate { get; set; }
        
        [JsonProperty("valid_End_Date")]
        public string ValidEndDate { get; set; }
        
        [JsonProperty("invalid_Reason")]
        public string InvalidReason { get; set; }
        
        [JsonProperty("create_Dt")]
        public int CreateDt { get; set; }
        #endregion

        #region Initialize
        private ConceptDto()
        {

        }

        public static ConceptDto Build(int id, string pxordx, string oldPxordx, string codeType,
                                       string conceptClassId, int conceptId, string vocabularyId,
                                       string domainId, string track, string standardConcept,
                                       string code, string codeWithPeriods, string codeScheme,
                                       string longDesc, string shortDesc, string codeStatus,
                                       string codeChange, int codeChangeYear, string codePlannedType,
                                       string codeBillingStatus, string codeCmsClaimStatus, string sexCd,
                                       string anatOrCond, string poaCodeStatus, string poaCodeChange,
                                       string poaCodeChangeYear, string validStartDate, string validEndDate,
                                       string invalidReason, int createDt)
        {
            return new ConceptDto
            {
                Id = id,
                Pxordx = pxordx,
                OldPxordx = oldPxordx,
                CodeType = codeType,
                ConceptClassId = conceptClassId,
                ConceptId = conceptId,
                VocabularyId = vocabularyId,
                DomainId = domainId,
                Track = track,
                StandardConcept = standardConcept,
                Code = code,
                CodeWithPeriods = codeWithPeriods,
                CodeScheme = codeScheme,
                LongDesc = longDesc,
                ShortDesc = shortDesc,
                CodeStatus = codeStatus,
                CodeChange = codeChange,
                CodeChangeYear = codeChangeYear,
                CodePlannedType = codePlannedType,
                CodeBillingStatus = codeBillingStatus,
                CodeCmsClaimStatus = codeCmsClaimStatus,
                SexCd = sexCd,
                AnatOrCond = anatOrCond,
                PoaCodeStatus = poaCodeStatus,
                PoaCodeChange = poaCodeChange,
                PoaCodeChangeYear = poaCodeChangeYear,
                ValidStartDate = validStartDate,
                ValidEndDate = validEndDate,
                InvalidReason = invalidReason,
                CreateDt = createDt
            };
        }
        #endregion
    }
}
