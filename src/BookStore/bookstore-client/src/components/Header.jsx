import './../css/Header.css'
import { useNavigate } from 'react-router-dom';


function Header() {

    const navigate = useNavigate();

    const handleHomeClick = () => {
        navigate(`/`);
    };

    return (
        <div className="header frame-violet">
            <h1 className='txt-violet' onClick={handleHomeClick}>bookly</h1>
            <input type='text' value={"Найти на сайте"} className='frame-pink '></input>
            <button className='header-button'>Избранное</button>
            <button className='header-button'>Корзина</button>
            <button className="header-btn-login header-button">Вход</button>
        </div>
    );
}


export default Header;