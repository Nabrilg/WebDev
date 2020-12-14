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
