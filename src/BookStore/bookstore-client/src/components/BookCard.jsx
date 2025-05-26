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
        <div class="book-card background--light" onClick={handleDetailsClick} title='Подробнее'>
            <img class='book-card__cover' 
                src={props.book.coverImageUrl } 
                alt={props.book.title}
                onError={handleBookImageError}
                ></img>
            <div class='book-card__info '>
                <h4 class='book-card__text'>{props.book.title}</h4>
                <h5 class='book-card__text'>{props.book.author}</h5>
                <p class='book-card__text'>{props.book.price} ₽</p>
            </div>
            <div class='book-card__actions'>
                <button class='button button--primary'>В корзину</button>
                <button class='button btn-orange'>&#9733;</button>
            </div>
        </div>
    )
}

export default BookCard;