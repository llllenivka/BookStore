import React, { useState, useEffect} from "react";
import {getBooks} from './../api/BookApi'
import BookCard from "./BookCard";
import './../css/BookList.css'

function BookList() {
    const [books, setBooks] = useState([]);

    const fetchBooks = async () => {
        try {
            const books = await getBooks();
            setBooks(books);
        } catch (error) {
            console.log("Ошибка при загрузке книг:", error);
            return [];
        }
    };

    useEffect(() => {
        fetchBooks();
    }, []);

    console.log(books.length);
    return (
        <div className="book-list">
            {   
                books.map(book => (
                    <BookCard key={book.id} book={book}/>
                ))
            }
        </div>
    )
}

export default BookList;