import React from 'react';
import axios from 'axios';
import './../css/App.css';
import './../css/LoginModal.css';

function LoginModal () {

    return (
        <div className='auth-modal'>
            <div className='auth-container frame-pink'>
                <button className='btn-orange btn-close'>&#x2715;</button>
                <h3>Вход</h3>
                <input type='text'></input>
                <input type='text'></input>
                <button>Войти</button>
                <p>или</p>
                <h3>Регистрация</h3>
                <input type='text'></input>
                <input type='text'></input>
                <input type='text'></input>
                <button>Зарегестрироваться</button>
            </div>
        </div>
    ) ;

    

}

export default LoginModal;