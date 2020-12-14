import React, { useState } from "react";
import loginService from "./services/loginService"

export default function Login({ setAuthState }) {

  const [input, setInputs] = useState({
    username: "",
    password: ""
  });

  const handleChange = event => {
    input[event.target.name] = event.target.value;
    setInputs({...input});
  };

  const onLogin = () => {
    loginService(input.username, input.password)
    .then(response => {
      if(!response.ok){
        alert("Wrong username or password");
        throw new Error("Wrong username or password");
      }
      return response.json();
    })
    .then(response => {
      setAuthState({user: {userId: response.userId, name: response.name}, token: response.token});
    })
    .catch(err => {
      console.log(err);
    })
  }

  return (
    <div className="card shadow-sm p-3 mb-5 rounded">
      <div className="card-header bg-white text-center">
        <strong className="text-uppercase">Login</strong>
      </div>
      <div className="card-body">
        <div className="form-group">
          <div className="row my-1">
            <label className="col" id="lblUsername">Email</label>
            <input
              className="col"
              placeholder="ex@example.co"
              name="username"
              type="email"
              value={input.username}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblPassword">Password</label>
            <input
              className="col"
              placeholder="Password"
              name="password"
              type="password"
              value={input.password}
              onChange={handleChange}
            />
          </div>
          <div className="text-center mt-3">
            <button className="btn btn-primary" onClick={onLogin}>Submit</button>
          </div>
        </div>
      </div>
    </div>
  );
}
