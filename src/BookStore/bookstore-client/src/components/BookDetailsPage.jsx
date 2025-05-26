import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { getBookDetails } from "../api/BookApi"
import './../css/BookDetailsPage.css';
import './../css/App.css';
import { handleBookImageError } from './../utils/imageHandlers.js';
import { useNavigate } from "react-router-dom";


function BookDetailsPage () {
    const { id } = useParams();
    const [book, setBook] = useState(null);

    const navigate = useNavigate();

    const handleHomeClick = () => {
        navigate(`/`);
    };


    useEffect(() => {
        const fetchBookDetails = async () => {
            try {
                const data = await getBookDetails(id);
                setBook(data);
            } catch (error) {
                console.error('Ошибка:', error);
            }
        }
        fetchBookDetails();
    }, [id]);

    if (!book) return <div>Книга не найдена</div>;

    return (
        <div className="book-detail">
            <button className="button button--secondary" onClick={handleHomeClick}>&#8592;</button>
            <div className="book-detail__header text--dark">
                <h1>{book.title}</h1>
                <h2>{book.author}</h2>
            </div>
            <div className="book-detail__content">

                <img className="book-detail__cover" 
                    src={book.coverImageUrl} 
                    alt={book.title}
                    onError={handleBookImageError}></img>

                <div className="book-detail__info background--light">
                    <h3>Аннотация</h3>
                    <p className="txt-grey">{book.description}</p>
                    <h3>Характеристики</h3>
                    <p className="txt-grey">ID: {book.id}</p>
                    <p className="txt-grey">Автор: {book.author}</p>
                    <p className="txt-grey">Год публикации: {book.yearPublished}</p>
                    <p className="txt-grey">Количество страниц: {book.pagesCount}</p>
                </div>

                <div className="book-detail__purchase background--light">
                    <h3 >Цена: {book.price} ₽</h3>
                    <button className="button button--primary">В корзину</button>
                    <button className="button button--outline">Избранное</button>
                </div>

            </div>

            
        </div>
    )
}

export default BookDetailsPage;