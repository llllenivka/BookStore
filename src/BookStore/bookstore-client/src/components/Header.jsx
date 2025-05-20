import './../css/Header.css'

function Header() {
    return (
        <div className="header">
            <h1>bookly</h1>
            <input type='text' value={"Найти на сайте"}></input>
            <button className='header-button'>Избранное</button>
            <button className='header-button'>Корзина</button>
            <button className="header-btn-login header-button">Вход</button>
        </div>
    );
}


export default Header;