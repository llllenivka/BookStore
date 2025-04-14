import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { getBookDetails } from "../api/BookApi"


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
    }, [id]);

    if (!book) return <div>Книга не найдена</div>;

    return (
        <div className="book-details">
            <h1>{book.title}</h1>
            <h2>{book.author}</h2>
            <p>Цена: {book.price} ₽</p>
        </div>
    )
}

export default BookDetailsPage;