﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDev.Api.Model
{
    using System.ComponentModel.DataAnnotations;
    public class Concept
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Pxordx { get; set; }

        public string Oldpxordx { get; set; }

        public string CodeType { get; set; }

        public string Concept_Class_Id { get; set; }

        [Required]
        public int Concept_Id { get; set; }

        [Required]
        public string Vocabulary_Id { get; set; }

        [Required]
        public string Domain_Id { get; set; }

        public string Track { get; set; }

        public string Standard_Concept { get; set; }

        [Required]
        public string Code { get; set; }

        public string CodeWithPeriods { get; set; }

        public string CodeScheme { get; set; }

        public string Long_Desc { get; set; }

        public string Short_Desc { get; set; }

        public string Code_Status { get; set; }

        public string Code_Change { get; set; }

        public int Code_Change_Year { get; set; }

        public string Code_Planned_Type { get; set; }

        public string Code_Billing_Status { get; set; }

        public string Code_Cms_Claim_Status { get; set; }

        public string Sex_Cd { get; set; }

        public string Anat_Or_Cond { get; set; }

        public string Poa_Code_Status { get; set; }

        public string Poa_Code_Change { get; set; }

        public string Poa_Code_Change_Year { get; set; }

        public string Valid_Start_Date { get; set; }

        public string Valid_End_Date { get; set; }

        public string Invalid_Reason { get; set; }

        public int Create_Dt { get; set; }
    }
}
