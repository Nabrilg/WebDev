using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDev.Application.Models
{
    public class Concept
    {
        [Key]
        public int Id { get; set; }

        public string Pxordx { get; set; }
        public string Oldpxordx { get; set; }
        public string Codetype { get; set; }
        public string Concept_class_id { get; set; }
        public int Concept_id { get; set; }
        public string Vocabulary_id { get; set; }
        public string Domain_id { get; set; }
        public string Track { get; set; }
        public string Standard_concept { get; set; }
        public string Code { get; set; }
        public string Codewithperiods { get; set; }
        public string Codescheme { get; set; }
        public string Long_desc { get; set; }
        public string Short_desc { get; set; }
        public string Code_status { get; set; }
        public string Code_change { get; set; }
        public int Code_change_year { get; set; }
        public string Code_planned_type { get; set; }
        public string Code_billing_status { get; set; }
        public string Code_cms_claim_status { get; set; }
        public string Sex_cd { get; set; }
        public string Anat_or_cond { get; set; }
        public string Poa_code_status { get; set; }
        public string Poa_code_change { get; set; }
        public string Poa_code_change_year { get; set; }
        public string Valid_start_date { get; set; }
        public string Valid_end_date { get; set; }
        public string Invalid_reason { get; set; }
        public int Create_dt { get; set; }

    }
}
