import './../css/BookCard.css';

function BookCard(props) {
    return (
        <div className="book-card text-card">
            <img src={props.book.coverImageUrl}></img>
            <div>
                <p>{props.book.price} ₽</p>
                <p>{props.book.title}</p>
                <p>{props.book.author}</p>
            </div>
            <div className='book-card-group-btn'>
                <button>В корзину</button>
                <button>Нравится</button>
                <button>Подробнее</button>
            </div>
            
        </div>
    )
}

export default BookCard;