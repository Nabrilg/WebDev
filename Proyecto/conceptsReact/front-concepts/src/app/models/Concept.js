export default class Concept{
  constructor (id, pxordx, oldpxordx, codeType, concept_Class_Id, concept_Id, vocabulary_Id, domain_Id, track,
    standard_Concept, code, codeWithPeriods, codeScheme, long_Desc, short_Desc, code_Status, code_Change,
    code_Change_Year, code_Planned_Type, code_Billing_Status, code_Cms_Claim_Status, sex_Cd, anat_Or_Cond,
    poa_Code_Status, poa_Code_Change, poa_Code_Change_Year, valid_Start_Date, valid_End_Date, invalid_Reason,
    create_Dt){
    this.id = id; //show
    this.pxordx = pxordx;
    this.oldpxordx = oldpxordx;
    this.codeType = codeType;
    this.concept_Class_Id = concept_Class_Id;
    this.concept_Id = concept_Id; //show
    this.vocabulary_Id = vocabulary_Id;
    this.domain_Id = domain_Id;
    this.track = track;
    this.standard_Concept = standard_Concept;
    this.code = code;
    this.codeWithPeriods = codeWithPeriods;
    this.codeScheme = codeScheme;
    this.long_Desc = long_Desc;
    this.short_Desc = short_Desc; //show
    this.code_Status = code_Status;
    this.code_Change = code_Change;
    this.code_Change_Year = code_Change_Year;
    this.code_Planned_Type = code_Planned_Type;
    this.code_Billing_Status = code_Billing_Status;
    this.code_Cms_Claim_Status = code_Cms_Claim_Status;
    this.sex_Cd = sex_Cd;
    this.anat_Or_Cond = anat_Or_Cond;
    this.poa_Code_Status = poa_Code_Status;
    this.poa_Code_Change = poa_Code_Change;
    this.poa_Code_Change_Year = poa_Code_Change_Year;
    this.valid_Start_Date = valid_Start_Date;
    this.valid_End_Date = valid_End_Date;
    this.invalid_Reason = invalid_Reason;
    this.create_Dt = create_Dt;
  }
}
