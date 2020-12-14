using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class ConceptDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pxordx")]
        public string Pxordx { get; set; }

        [JsonProperty("oldpxordx")]
        public string Oldpxordx { get; set; }

        [JsonProperty("codetype")]
        public string CodeType { get; set; }

        [JsonProperty("concept_class_id")]
        public string ConceptClassId { get; set; }

        [JsonProperty("concept_id")]
        public int ConceptId { get; set; }

        [JsonProperty("vocabulary_id")]
        public string VocbularyId { get; set; }

        [JsonProperty("domain_id")]
        public string DomainId { get; set; }

        [JsonProperty("track")]
        public string Track { get; set; }

        [JsonProperty("standard_concept")]
        public string StandardConcept { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("codewithperiods")]
        public string CodeWithPeriods { get; set; }

        [JsonProperty("codescheme")]
        public string CodeScheme { get; set; }

        [JsonProperty("long_desc")]
        public string LongDesc { get; set; }

        [JsonProperty("short_desc")]
        public string ShortDesc { get; set; }

        [JsonProperty("code_status")]
        public string CodeStatus { get; set; }

        [JsonProperty("code_change")]
        public string CodeChange { get; set; }

        [JsonProperty("code_change_year")]
        public int CodeChangeYear { get; set; }

        [JsonProperty("code_planned_type")]
        public string CodePlannedType { get; set; }

        [JsonProperty("code_billing_status")]
        public string CodeBillingStatus { get; set; }

        [JsonProperty("code_cms_claim_status")]
        public string CodeCmsClaimStatus { get; set; }

        [JsonProperty("sex_cd")]
        public string SexCd { get; set; }

        [JsonProperty("anat_or_cond")]
        public string AnatOrCond { get; set; }

        [JsonProperty("poa_code_status")]
        public string PoaCodeStatus { get; set; }

        [JsonProperty("poa_code_change")]
        public string PoaCodeChange { get; set; }

        [JsonProperty("poa_code_change_year")]
        public string PoaCodeChangeYear { get; set; }

        [JsonProperty("valid_start_date")]
        public string ValidStartDate { get; set; }

        [JsonProperty("valid_end_date")]
        public string ValidEndDate { get; set; }

        [JsonProperty("invalid_reason")]
        public string InvalidReason { get; set; }

        [JsonProperty("create_dt")]
        public int CreateDt { get; set; }

        private ConceptDto()
        {
        }

        public static ConceptDto Build(int id, string pxordx, string oldpxordx, string codetype, string conceptclassid, int conceptid, string vocbularyid, string domainid, string track, string standardconcept, string code, string codewithperiods, string codescheme, string longdesc, string shortdesc, string codestatus, string codechange, int codechangeyear, string codeplannedtype, string codebillingstatus, string codecmsclaimstatus, string sexcd, string anatorcond, string poacodestatus, string poacodechange, string poacodechangeyear, string validstartdate, string validenddate, string invalidreason, int createdt)
        {
            return new ConceptDto
            {
                Id = id,
                Pxordx = pxordx,
                Oldpxordx = oldpxordx,
                CodeType = codetype,
                ConceptClassId = conceptclassid,
                ConceptId = conceptid,
                VocbularyId = vocbularyid,
                DomainId = domainid,
                Track = track,
                StandardConcept = standardconcept,
                Code = code,
                CodeWithPeriods = codewithperiods,
                CodeScheme = codescheme,
                LongDesc = longdesc,
                ShortDesc = shortdesc,
                CodeStatus = codestatus,
                CodeChange = codechange,
                CodeChangeYear = codechangeyear,
                CodePlannedType = codeplannedtype,
                CodeBillingStatus = codebillingstatus,
                CodeCmsClaimStatus = codecmsclaimstatus,
                SexCd = sexcd,
                AnatOrCond = anatorcond,
                PoaCodeStatus = poacodestatus,
                PoaCodeChange = poacodechange,
                PoaCodeChangeYear = poacodechangeyear,
                ValidStartDate = validstartdate,
                ValidEndDate = validenddate,
                InvalidReason = invalidreason,
                CreateDt = createdt
            }; 
        }
    }

    
}
