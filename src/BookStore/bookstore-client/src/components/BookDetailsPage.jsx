import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { getBookDetails } from "../api/BookApi"
import './../css/BookDetailsPage.css';
import './../css/App.css';
import { handleBookImageError } from './../utils/imageHandlers.js';


function BookDetailsPage () {
    const { id } = useParams();
    const [book, setBook] = useState(null);


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
        <div className="book-details-page">
            <div className="book-details-page__title">
                <h1>{book.title}</h1>
                <h2>{book.author}</h2>
            </div>
            <div className="book-details-page__content">

                <img className="book-details-page__image" 
                    src={book.coverImageUrl} 
                    alt={book.title}
                    onError={handleBookImageError}></img>

                <div className="book-details-page__details frame-pink">
                    <h3>Аннотация</h3>
                    <p className="txt-grey">{book.description}</p>
                    <h3>Характеристики</h3>
                    <p className="txt-grey">ID: {book.id}</p>
                    <p className="txt-grey">Автор: {book.author}</p>
                    <p className="txt-grey">Год публикации: {book.yearPublished}</p>
                    <p className="txt-grey">Количество страниц: {book.pagesCount}</p>
                </div>

                <div className="book-details-page__price frame-pink">
                    <h3 className="">Цена: {book.price} ₽</h3>
                    <button className="btn-violet">В корзину</button>
                    <button className="btn-orange">Избранное</button>
                </div>

            </div>

            
        </div>
    )
}

export default BookDetailsPage;