import './../css/Header.css'

function Header() {
    return (
        <div className="header frame-violet">
            <h1 className='txt-violet'>bookly</h1>
            <input type='text' value={"Найти на сайте"} className='frame-pink '></input>
            <button className='header-button'>Избранное</button>
            <button className='header-button'>Корзина</button>
            <button className="header-btn-login header-button">Вход</button>
        </div>
    );
}


export default Header;