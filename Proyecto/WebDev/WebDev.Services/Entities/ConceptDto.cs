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
        public string Codetype { get; set; }

        [JsonProperty("concept_class_id")]
        public string Concept_class_id { get; set; }

        [JsonProperty("concept_id")]
        public int Concept_id { get; set; }

        [JsonProperty("vocabulary_id")]
        public string Vocabulary_id { get; set; }

        [JsonProperty("domain_id")]
        public string Domain_id { get; set; }

        [JsonProperty("track")]
        public string Track { get; set; }

        [JsonProperty("standard_concept")]
        public string Standard_concept { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("codewithperiods")]
        public string Codewithperiods { get; set; }

        [JsonProperty("codescheme")]
        public string Codescheme { get; set; }

        [JsonProperty("long_desc")]
        public string Long_desc { get; set; }

        [JsonProperty("short_desc")]
        public string Short_desc { get; set; }

        [JsonProperty("code_status")]
        public string Code_status { get; set; }

        [JsonProperty("code_change")]
        public string Code_change { get; set; }

        [JsonProperty("code_change_year")]
        public int Code_change_year { get; set; }

        [JsonProperty("code_planned_type")]
        public string Code_planned_type { get; set; }

        [JsonProperty("code_billing_status")]
        public string Code_billing_status { get; set; }

        [JsonProperty("code_cms_claim_status")]
        public string Code_cms_claim_status { get; set; }

        [JsonProperty("sex_cd")]
        public string Sex_cd { get; set; }

        [JsonProperty("anat_or_cond")]
        public string Anat_or_cond { get; set; }

        [JsonProperty("poa_code_status")]
        public string Poa_code_status { get; set; }

        [JsonProperty("poa_code_change")]
        public string Poa_code_change { get; set; }

        [JsonProperty("poa_code_change_year")]
        public string Poa_code_change_year { get; set; }

        [JsonProperty("valid_start_date")]
        public string Valid_start_date { get; set; }

        [JsonProperty("valid_end_date")]
        public string Valid_end_date { get; set; }

        [JsonProperty("invalid_reason")]
        public string Invalid_reason { get; set; }

        [JsonProperty("create_dt")]
        public int Create_dt { get; set; }

        [JsonProperty("concept_status")]
        public bool Concept_status { get; set; }

        public static ConceptDto Build(int id, 
            string pxordx, string oldpxordx, string codetype, string concept_class_id,
            int concept_id, string vocabulary_id, string domain_id,
            string track, string standard_concept, string code, string codewithperiods,
            string codescheme, string long_desc, string short_desc, string code_status,
            string code_change, int code_change_year, string code_planned_type, string code_billing_status,
            string code_cms_claim_status, string sex_cd, string anat_or_cond, string poa_code_status,
            string poa_code_change, string poa_code_change_year, string valid_start_date, string valid_end_date,
            string invalid_reason, int create_dt)
        {
            return new ConceptDto
            {
                Id = id,
                Pxordx = pxordx,
                Oldpxordx = oldpxordx,
                Codetype = codetype,
                Concept_class_id = concept_class_id,
                Concept_id = concept_id,
                Vocabulary_id = vocabulary_id,
                Domain_id = domain_id,
                Track = track,
                Standard_concept = standard_concept,
                Code = code,
                Codewithperiods = codewithperiods,
                Codescheme = codescheme,
                Long_desc = long_desc,
                Short_desc = short_desc,
                Code_status = code_status,
                Code_change = code_change,
                Code_change_year = code_change_year,
                Code_planned_type = code_planned_type,
                Code_billing_status = code_billing_status,
                Code_cms_claim_status = code_cms_claim_status,
                Sex_cd = sex_cd,
                Anat_or_cond = anat_or_cond,
                Poa_code_status = poa_code_status,
                Poa_code_change = poa_code_change,
                Poa_code_change_year = poa_code_change_year,
                Valid_start_date = valid_start_date,
                Valid_end_date = valid_end_date,
                Invalid_reason = invalid_reason,
                Create_dt = create_dt,
                Concept_status = true
            };
        }

    }
}
