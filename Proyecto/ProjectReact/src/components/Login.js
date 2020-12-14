import React, { useState } from "react";
import { login } from "./services/loginService"

export default function Login({ setAuthState }) {
  const initInputsText = {
    username: "",
    password: ""
  };
  const [inputsText, setInputs] = useState(initInputsText);

  const onLogin = () => {
    login(inputsText.username, inputsText.password)
    .then(response => {
      if(!response.ok) throw new Error("Usuario o contraseña incorrectas.");
      return response.json();
    })
    .then(response => {
      setAuthState({user: {userId: response.userId, name: response.name}, token: response.token});
    })
    .catch(err => {
      console.log(err);
    })
  }

  const handleChange = event => {
    inputsText[event.target.name] = event.target.value;
    setInputs({...inputsText});
  };

  return (
    <div className="card shadow-sm p-3 mb-5 rounded">
      <div className="card-header bg-white text-center">
        <strong className="text-uppercase">Login</strong>
      </div>
      <div className="card-body">
        <div className="form-group">
          <div className="row my-1">
            <label className="col" id="lblUsername">Nombre de usuario</label>
            <input
              className="col"
              placeholder="user@example.com"
              name="username"
              type="email"
              value={inputsText.username}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblPassword">Contraseña</label>
            <input
              className="col"
              placeholder="Contraseña"
              name="password"
              type="password"
              value={inputsText.password}
              onChange={handleChange}
            />
          </div>
          <div className="text-center mt-3">
            <button className="btn btn-outline-success" onClick={onLogin}>Iniciar sesión</button>
          </div>
        </div>
      </div>
    </div>
  );
}
