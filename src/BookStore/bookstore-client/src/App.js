import BookList from './components/BookList';
import './css/App.css';
import {Routes, Route} from 'react-router-dom';
import BookDetailsPage from './components/BookDetailsPage';




function App() {
  return (
    <div className='app'>
      <Routes>
        <Route path='/' element={ <BookList />}></Route>
        <Route path=":id" element={<BookDetailsPage />} />
      </Routes>
    </div>
  )
}

export default App;
