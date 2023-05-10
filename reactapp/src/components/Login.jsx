
import React, { useState } from 'react';
import profileServices from "../services/profileFetch";
import { useNavigate, useParams } from "react-router-dom";
import "../styles/profilepage.css";

const Login = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    const handleEmailChange = (e) => {
        setEmail(e.target.value);
    }

    const handlePasswordChange = (e) => {
        setPassword(e.target.value);
    }

    const handleLogin = () => {
        //var result = profileServices.loginProfile({
        //    userEmail: email,
        //    userPass: password
        //})
        //if (result.success) {
        //    navigate("/home/" + result.data.userId);
        //}
        fetch('https://localhost:7107/api/ProfileService/LoginUser', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                userEmail: email,
                userPass: password
            })
        })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                if (data.success) {
                    console.log('Login successful!');
                    navigate("/home/" + data.userId);
                } else {
                    setError('Invalid email or password');
                }
            })
            .catch(error => {
                setError('An error occurred during login');
            });
    }

    return (
        <div>
            <div className="Profile">
                <div className="profile_container">
                    <h1>Login</h1>
                    {error && <p>{error}</p>}
                    <form>
                        <label>Email:</label>
                        <input type="email" value={email} onChange={handleEmailChange} style={{ color:'black' }} />
                        <br />
                        <label>Password:</label>
                        <input type="password" value={password} onChange={handlePasswordChange} style={{ color: 'black' }} />
                        <br />
                        <button type="button" onClick={handleLogin}>Login</button>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default Login;
