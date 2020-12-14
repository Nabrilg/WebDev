import { URL } from "./config";

const LOGIN_PATH = "/api/Login";

export function login(username, password) {
  var myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  var raw = JSON.stringify({"email":"Jhoan.Lozano@email.com","password":"Password"});

  var requestOptions = {
    method: 'POST',
    headers: myHeaders,
    //body: JSON.stringify({email: username, password})
    body: raw
  };

  return fetch(URL + LOGIN_PATH, requestOptions);
}