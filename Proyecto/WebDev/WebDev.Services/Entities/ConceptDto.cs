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


    }
}
