import defaultImgBook from '../assets/images/default_book.png';


export const handleBookImageError = (e) => {
  e.target.src = defaultImgBook;
  e.target.onerror = null;
};