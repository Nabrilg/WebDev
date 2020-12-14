import React, { Component } from 'react';
import './App.css';
import axios from 'axios';
import Cookie from 'universal-cookie';

const api = axios.create({
    baseURL: `https://javerianawebdevapi.azurewebsites.net/api/Login`
})
class Login extends Component{
    state = {
        form:{
            email: '',
            password: ''
        }
    }

    handleChange=async e=>{
        await this.setState({
            form:{
                ...this.state.form,
                [e.target.name] : e.target.value
            }
        });
    }

    submitLogin = async () =>{
        try{
            let res = await api.post('/', { email: this.state.form.email, password: this.state.form.password })
            var cookie = new Cookie();
            cookie.set('Authorization', res.data.token, {path: '/'});
            console.log("cookie");
            window.location.href = "http://localhost:3000/concepts";
        } catch (err) {
            console.log(err);
        }
    }

    render(){
        return (
            <div className="gradient-bg">
                <div className="login-container">
                    <h1>Login</h1>
                    <form>
                        <p>E-mail:</p>
                        <input type="email" name="email" onChange={this.handleChange}></input>
                        <p>Contraseña:</p>
                        <input type="password" name="password" onChange={this.handleChange}></input>
                        <input type="button" value=" " onClick={ this.submitLogin }></input>
                    </form>
                </div>
            </div>
          );
    }
}

export default Login;
