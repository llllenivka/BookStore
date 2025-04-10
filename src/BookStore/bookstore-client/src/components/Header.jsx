import './../css/Header.css'

function Header() {
    return (
        <div className="header">
            <h1>Фолиант</h1>
            <input type='text' value={"Найти на сайте..."}></input>
            <button>Вход</button>
        </div>
    );
}


export default Header;