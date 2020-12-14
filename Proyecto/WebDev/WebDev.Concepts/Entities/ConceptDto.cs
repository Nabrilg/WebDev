namespace WebDev.Concepts.Entities
{
    public class ConceptDto
    {
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

        private ConceptDto()
        {
        }

        public static ConceptDto Build(int id, string pxordx, string oldpxordx, string codeType, string concept_Class_Id, int concept_Id, string vocabulary_Id, string domain_Id, string track, string standard_Concept, string code, string codeWithPeriods, string codeScheme, string long_Desc, string short_Desc, string code_Status, string code_Change, int code_Change_Year, string code_Planned_Type, string code_Billing_Status, string code_Cms_Claim_Status, string sex_Cd, string anat_Or_Cond, string poa_Code_Status, string poa_Code_Change, string poa_Code_Change_Year, string valid_Start_Date, string valid_End_Date, string invalid_Reason, int create_Dt)
        {
            return new ConceptDto
            {
                id = id,
                pxordx = pxordx,
                oldpxordx = oldpxordx,
                codeType = codeType,
                concept_Class_Id = concept_Class_Id,
                concept_Id = concept_Id,
                vocabulary_Id = vocabulary_Id,
                domain_Id = domain_Id,
                track = track,
                standard_Concept = standard_Concept,
                code = code,
                codeWithPeriods = codeWithPeriods,
                codeScheme = codeScheme,
                long_Desc = long_Desc,
                short_Desc = short_Desc,
                code_Status = code_Status,
                code_Change = code_Change,
                code_Change_Year = code_Change_Year,
                code_Planned_Type = code_Planned_Type,
                code_Billing_Status = code_Billing_Status,
                code_Cms_Claim_Status = code_Cms_Claim_Status,
                sex_Cd = sex_Cd,
                anat_Or_Cond = anat_Or_Cond,
                poa_Code_Status = poa_Code_Status,
                poa_Code_Change = poa_Code_Change,
                poa_Code_Change_Year = poa_Code_Change_Year,
                valid_Start_Date = valid_Start_Date,
                valid_End_Date = valid_End_Date,
                invalid_Reason = invalid_Reason,
                create_Dt = create_Dt
            };
        }
    }
}