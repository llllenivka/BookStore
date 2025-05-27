import BookList from './components/BookList';
import './css/App.css';
import {Routes, Route} from 'react-router-dom';
import BookDetailsPage from './components/BookDetailsPage';
import Header from './components/Header';
// import LoginModal from './components/LoginModal';
// import RegisterModal from './components/RegisterModal';
import AuthModal from './components/AuthModal';




function App() {
  return (
    <div className='app-container'>
      {/* <Header /> */}
      {/* <LoginModal></LoginModal> */}
      <Routes>
        <Route path='/login/' element={<AuthModal/>}></Route>
  
        <Route path='/' element={
          <>
            <Header />
            <BookList />
          </>
        }/>

        <Route path=":id" element={
          <>
            <Header />
            <BookDetailsPage />
          </>
        } />
      </Routes>
    </div>
  )
}

export default App;
