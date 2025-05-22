import './../css/Header.css'
import { useNavigate } from 'react-router-dom';
// import loginImage from '../assets/images/loginImage.jpg'


function Header() {

    const navigate = useNavigate();

    const handleHomeClick = () => {
        navigate(`/`);
    };

    return (
        <div className="header frame-violet">
            <h1 className='logo txt-violet' onClick={handleHomeClick}>bookly</h1>
            <input className='search-bar' type='text'  placeholder='Найти...'></input>
            <div className='icons'>
                <span>Избранное</span>
                <span>Корзина</span>
                <span>Вход</span>
            </div>
        </div>
    );
}


export default Header;