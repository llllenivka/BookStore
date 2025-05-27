import './../css/App.css';
import './../css/AuthModal.css';
import { useNavigate } from 'react-router-dom';
import React, { useState } from 'react';
import { loginUser } from '../api/AuthApi';

function AuthModal () {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const navigate = useNavigate();

    const handleHomeClick = () => {
        navigate(`/`);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await loginUser(email, password);
            localStorage.setItem('token', response.token);
            navigate("/"); 
        } catch (error) {
            console.log("Неверный email или пароль");
        }
    };


    return(
        <div className="auth-form background--light">
            <div className="auth-form__header text--primary" onClick={handleHomeClick}>bookly</div>
            <div className="auth-form__actions">
                <button className="button button--primary">Вход</button>
                <button className="button button--secondary">Регистрация</button>
            </div>
            <form 
                className="text--muted"
                onSubmit={handleSubmit}>
                <div className="form-grauth-form__field">
                    <label htmlFor="email" className='auth-form__field-label'>Почта</label>
                    <input type="email" 
                        id="email"
                        className="auth-form__input"
                        placeholder="Введите свою почту"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div className="auth-form__field auth-form__field-label">
                    <label htmlFor="password" className='auth-form__field-label'>Пароль</label>
                    <input type="password" 
                        id="password" 
                        className="auth-form__input" 
                        placeholder="Введите свой пароль " 
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>

                <button
                    type="submit"
                    className="button button--primary auth-form__submit">Войти</button>
            </form>
        </div>
    );

    

}

export default AuthModal;