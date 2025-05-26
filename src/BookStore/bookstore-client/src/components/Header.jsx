import './../css/Header.css'
import { useNavigate } from 'react-router-dom';
// import loginImage from '../assets/images/loginImage.jpg'


function Header() {

    const navigate = useNavigate();

    const handleHomeClick = () => {
        navigate(`/`);
    };

    const handleRegisterClick = () => {
        navigate(`/register/`);
    };

    return (
        <div class="site-header background--primary">
            <h1 class='site-header__logo text--light' onClick={handleHomeClick}>bookly</h1>
            <input class='input site-header__search' type='text'  placeholder='Найти...'></input>
            <div class='site-header__action-icon'>
                <span class="text--light">Избранное</span>
                <span class="text--light">Корзина</span>
                <span class="text--light" onClick={handleRegisterClick}>Вход</span>
            </div>
        </div>
    );
}


export default Header;