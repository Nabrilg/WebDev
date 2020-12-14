import { URL } from "./config";

const CONCEPTS_PATH = "/api/Concepts";

export default class ConceptsService {
  constructor(AuthState) { 
    this.myHeaders = new Headers();
    this.myHeaders.append("Content-Type", "application/json");
    this.myHeaders.append("Authorization", AuthState.token);
  }
  get(){
    let requestOptions = {
      method: 'GET',
      headers: this.myHeaders
    };
    return fetch(URL + CONCEPTS_PATH, requestOptions);
  }
  post(concept){
    let requestOptions = {
      method: 'POST',
      headers: this.myHeaders,
      body: JSON.stringify(concept)
    };
    return fetch(URL + CONCEPTS_PATH, requestOptions);
  }
  put(concept){
    console.log(concept);
    var requestOptions = {
      method: 'PUT',
      headers: this.myHeaders,
      body: JSON.stringify(concept)
    };
    console.log(URL + CONCEPTS_PATH + "/" + concept.id);
    return fetch(URL + CONCEPTS_PATH + "/" + concept.id, requestOptions);
  }
  delete(concept_id){
    var requestOptions = {
      method: 'DELETE',
      headers: this.myHeaders
    };
    return fetch(URL + CONCEPTS_PATH + "/" + concept_id, requestOptions);
  }
}