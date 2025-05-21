import './../css/App.css'
import './../css/BookCard.css';
import { useNavigate } from 'react-router-dom';
import { handleBookImageError } from './../utils/imageHandlers.js';


function BookCard(props) {

    const navigate = useNavigate();

    const handleDetailsClick = () => {
        navigate(`/${props.book.id}`);
    };


    return (
        <div className="book-card frame-pink" onClick={handleDetailsClick}>
            <img className='book-card__image' 
                src={props.book.coverImageUrl } 
                alt={props.book.title}
                onError={handleBookImageError}
                ></img>
            <div className='book-card__content'>
                <h4 className='book-card__text'>{props.book.title}</h4>
                <h5 className='book-card__text'>{props.book.author}</h5>
                <p className='book-card__text'>{props.book.price} ₽</p>
            </div>
            <div className='book-card__actions'>
                <button className='btn-violet'>В корзину</button>
                <button className='btn-orange'>&#9733;</button>
            </div>
        </div>
    )
}

export default BookCard;