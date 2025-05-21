import './../css/App.css'
import './../css/BookCard.css';
import { useNavigate } from 'react-router-dom';
import defaultImgBook from './../assets/images/default_book.png';

function BookCard(props) {

    const navigate = useNavigate();

    const handleDetailsClick = () => {
        navigate(`/${props.book.id}`);
    };

    const handleImageError = (e) => {
        e.target.src = defaultImgBook;
        e.target.onerror = null;
    };

    return (
        <div className="book-card frame-pink">
            <img className='book-card__image' 
                src={props.book.coverImageUrl } 
                alt={props.book.title}
                onError={handleImageError}
                ></img>
            <div className='book-card__content'>
                <h3 className='book-card__text'>{props.book.price} ₽</h3>
                <p className='book-card__text'>{props.book.title}</p>
                <p className='book-card__text'>{props.book.author}</p>
            </div>
            <div className='book-card__actions'>
                <button className='btn-violet'>В корзину</button>
                <button className='btn-orange'>♡</button>
                <button 
                    onClick={handleDetailsClick}
                    className='btn-violet book-card__more-btn'>
                        Подробнее
                </button>
            </div>
        </div>
    )
}

export default BookCard;