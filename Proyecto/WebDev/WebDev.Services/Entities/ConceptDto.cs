using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class ConceptDto
    {
        public int id { get; set; }

        public string pxordx { get; set; }

        public string oldpxordx { get; set; }

        public string codetype { get; set; }

        public string concept_class_id { get; set; }

        public int concept_id { get; set; }

        public string vocabulary_id { get; set; }

        public string domain_id { get; set; }

        public string track { get; set; }

        public string standard_concept { get; set; }

        public string code { get; set; }

        public string codewithperiods { get; set; }

        public string codescheme { get; set; }

        public string long_desc { get; set; }

        public string short_desc { get; set; }

        public string code_status { get; set; }

        public string code_change { get; set; }

        public int code_change_year { get; set; }

        public string code_planned_type { get; set; }

        public string code_billing_status { get; set; }

        public string code_cms_claim_status { get; set; }

        public string sex_cd { get; set; }

        public string anat_or_cond { get; set; }

        public string poa_code_status { get; set; }

        public string poa_code_change { get; set; }

        public string poa_code_change_year { get; set; }

        public string valid_start_date { get; set; }

        public string valid_end_date { get; set; }

        public string invalid_reason { get; set; }

        public int create_dt { get; set; }
        private ConceptDto()
        {

        }
        public static ConceptDto Build(int id, string pxordx, string oldpxordx, string codetype, string concept_class_id, int concept_id, string vocabulary_id, string domain_id, string track, string standard_concept, string code, string codewithperiods, string codescheme, string long_desc, string short_desc, string code_status, string code_change, int code_change_year, string code_planned_type, string code_billing_status, string code_cms_claim_status, string sex_cd, string anat_or_cond, string poa_code_status, string poa_code_change, string poa_code_change_year, string valid_start_date, string valid_end_date, string invalid_reason, int create_dt)
        {
            return new ConceptDto
            {
                id = id,
                pxordx = pxordx,
                oldpxordx = oldpxordx,
                codetype = codetype,
                concept_class_id = concept_class_id,
                concept_id = concept_id,
                vocabulary_id = vocabulary_id,
                domain_id = domain_id,
                track = track,
                standard_concept = standard_concept,
                code = code,
                codewithperiods = codewithperiods,
                codescheme = codescheme,
                long_desc = long_desc,
                short_desc = short_desc,
                code_status = code_status,
                code_change = code_change,
                code_change_year = code_change_year,
                code_planned_type = code_planned_type,
                code_billing_status = code_billing_status,
                code_cms_claim_status = code_cms_claim_status,
                sex_cd = sex_cd,
                anat_or_cond = anat_or_cond,
                poa_code_status = poa_code_status,
                poa_code_change = poa_code_change,
                poa_code_change_year = poa_code_change_year,
                valid_start_date = valid_start_date,
                valid_end_date = valid_end_date,
                invalid_reason = invalid_reason,
                create_dt = create_dt
            };
        }
    }
}
