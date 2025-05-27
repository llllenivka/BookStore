import './../css/App.css';
import './../css/RegisterModal.css';
import { useNavigate } from "react-router-dom";


function RegisterModal(){
    const navigate = useNavigate();

    const handleHomeClick = () => {
        navigate(`/`);
    };

    return(
        <div className="auth-form background--light">
            <div className="auth-form__header text--primary" onClick={handleHomeClick}>bookly</div>
            <div className="auth-form__actions">
                <button className="button button--primary">Вход</button>
                <button className="button button--secondary">Регистрация</button>
            </div>
            <form className="text--muted">
                <div className="form-grauth-form__field">
                    <label for="email" className='auth-form__field-label'>Почта</label>
                    <input type="email" id="email" className="auth-form__input" placeholder="Введите свою почту"/>
                </div>
                <div className="auth-form__field auth-form__field-label">
                    <label for="password" className='auth-form__field-label'>Пароль</label>
                    <input type="password" id="password" className="auth-form__input" placeholder="Введите свой пароль"/>
                </div>

                <button type="submit" className="button button--primary auth-form__submit">Войти</button>
            </form>
        </div>
    );
}

export default RegisterModal;