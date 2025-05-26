import './../css/App.css';
import './../css/RegisterModal.css';
import { useNavigate } from "react-router-dom";


function RegisterModal(){
    const navigate = useNavigate();

    const handleHomeClick = () => {
        navigate(`/`);
    };

    return(
        <div class="auth-form background--light">
            <div class="auth-form__header text--primary" onClick={handleHomeClick}>bookly</div>
            <div class="auth-form__actions">
                <button class="button button--primary">Вход</button>
                <button class="button button--secondary">Регистрация</button>
            </div>
            <form class="text--muted">
                <div class="form-grauth-form__field">
                    <label for="email" className='auth-form__field-label'>Почта</label>
                    <input type="email" id="email" class="auth-form__input" placeholder="Введите свою почту"/>
                </div>
                <div class="auth-form__field auth-form__field-label">
                    <label for="password" className='auth-form__field-label'>Пароль</label>
                    <input type="password" id="password" class="auth-form__input" placeholder="Введите свой пароль"/>
                </div>

                <button type="submit" class="button button--primary auth-form__submit">Войти</button>
            </form>
        </div>
    );
}

export default RegisterModal;