using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class ConceptDto
    {
        

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
