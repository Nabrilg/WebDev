using System.ComponentModel.DataAnnotations;

namespace WebDev.Application.Models
{
    public class Concept
    {
        [Key]
        public int id { get; set; }
        public string pxordx { get; set; }
        public string oldpxordx { get; set; }
        public string codeType { get; set; }
        public string concept_Class_Id { get; set; }
        public int concept_Id { get; set; }
        public string vocabulary_Id { get; set; }
        public string domain_Id { get; set; }
        public string track { get; set; }
        public string standard_Concept { get; set; }
        public string code { get; set; }
        public string codeWithPeriods { get; set; }
        public string codeScheme { get; set; }
        public string long_Desc { get; set; }
        public string short_Desc { get; set; }
        public string code_Status { get; set; }
        public string code_Change { get; set; }
        public int code_Change_Year { get; set; }
        public string code_Planned_Type { get; set; }
        public string code_Billing_Status { get; set; }
        public string code_Cms_Claim_Status { get; set; }
        public string sex_Cd { get; set; }
        public string anat_Or_Cond { get; set; }
        public string poa_Code_Status { get; set; }
        public string poa_Code_Change { get; set; }
        public string poa_Code_Change_Year { get; set; }
        public string valid_Start_Date { get; set; }
        public string valid_End_Date { get; set; }
        public string invalid_Reason { get; set; }
        public int create_Dt { get; set; }
    }
}
