import URL from "./config";

const LOGIN_PATH = "/api/Login";

function loginService(username, password) {
  var myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  var raw = JSON.stringify({"email":username,"password":password});

  var requestOptions = {
    method: 'POST',
    headers: myHeaders,
    body: raw
  };

  return fetch(URL + LOGIN_PATH, requestOptions);
}
export default loginService;
