import './../css/BookCard.css';
import './../css/App.css'
// import 'bootstrap/dist/css/bootstrap.min.css';

function BookCard(props) {
    return (
        <div className="book-card">
            <img src={props.book.coverImageUrl} alt={props.book.title}></img>
            <div className='book-card-grpoup-text'>
                <h3 className='book-card-text'>{props.book.price} ₽</h3>
                <p className='book-card-text'>{props.book.title}</p>
                <p className='book-card-text'>{props.book.author}</p>
            </div>
            <div className='book-card-group-btn '>
                <button className='btn'>В корзину</button>
                <button className='btn'>Нравится</button>
                <button className='book-card-group_btn-more btn'>Подробнее</button>
            </div>
        </div>
    )
}

export default BookCard;