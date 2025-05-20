import BookList from './components/BookList';
import './css/App.css';
import {Routes, Route} from 'react-router-dom';
import BookDetailsPage from './components/BookDetailsPage';
import Header from './components/Header';




function App() {
  return (
    <div className='app'>
      <Header></Header>
      <Routes>
        <Route path='/' element={ <BookList />}></Route>
        <Route path=":id" element={<BookDetailsPage />} />
      </Routes>
    </div>
  )
}

export default App;
