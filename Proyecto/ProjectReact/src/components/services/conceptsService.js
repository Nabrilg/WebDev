import URL from "./config";

const PATH = "/api/Concepts";

class ConceptService{
  constructor(token){
    this.myHeaders = new Headers();
    this.myHeaders.append("Content-Type", "application/json");
    this.myHeaders.append("Authorization", token.token);
  }
  get(){
    var requestOptions = {
      method: 'GET',
      headers: this.myHeaders
    };
    console.log(URL + PATH);
    return fetch(URL + PATH, requestOptions);
  }
  post(concept){
    concept.id = 0;
    concept.concept_Id = parseInt(concept.concept_Id);
    concept.code_Change_Year = parseInt(concept.code_Change_Year);
    concept.create_Dt = parseInt(concept.create_Dt);
    var raw = JSON.stringify(concept);
    var requestOptions = {
      method: 'POST',
      headers: this.myHeaders,
      body: raw
    };
    return fetch(URL + PATH, requestOptions);
  }
  put(concept){
    var raw = JSON.stringify(concept);
    var requestOptions = {
      method: 'PUT',
      headers: this.myHeaders,
      body: raw
    };
    return fetch(URL + PATH + "/" + concept.id, requestOptions);
  }
  delete(concept){
    var requestOptions = {
      method: 'DELETE',
      headers: this.myHeaders
    };
    return fetch(URL + PATH + "/" + concept.id, requestOptions);
  }
}

export default ConceptService;
