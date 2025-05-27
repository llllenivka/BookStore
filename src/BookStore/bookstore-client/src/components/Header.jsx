import './../css/Header.css'
import { useNavigate } from 'react-router-dom';
// import loginImage from '../assets/images/loginImage.jpg'


function Header() {

    const navigate = useNavigate();

    const handleHomeClick = () => {
        navigate(`/`);
    };

    const handleRegisterClick = () => {
        navigate(`/login/`);
    };

    return (
        <div className="site-header background--primary">
            <h1 className='site-header__logo text--light' onClick={handleHomeClick}>bookly</h1>
            <input className='input site-header__search' type='text'  placeholder='Найти...'></input>
            <div className='site-header__actions'>
                <span className="site-header__action-icon text--light">Избранное</span>
                <span className="site-header__action-icon text--light">Корзина</span>
                <span className="site-header__action-icon text--light" onClick={handleRegisterClick}>Вход</span>
            </div>
        </div>
    );
}


export default Header;