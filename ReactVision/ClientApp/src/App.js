import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import './custom.css';
import { UserProvider } from "./Context/UserContext.tsx"; // Импортируйте контекст пользователя
import LoginForm from "./components/pages/Login/LoginForm.tsx";
import SignupForm from "./components/pages/SignupForm.tsx";
import Profil from "./components/pages/Profil.tsx";
import Cart from "./components/pages/Cart.tsx";
import Home from "./components/pages/Home.tsx";


export default class App extends Component {
    static displayName = App.name;

  render() {

      return (
          <UserProvider>
              <Routes>
                  <Route path="/login" element={<LoginForm />}></Route>
                  <Route path="/signup" element={<SignupForm />}></Route>
                  <Route path="/cart" element={<Cart />}></Route>
                  <Route path="/products" element={<Home showAllProducts={true} />}></Route>
                  <Route path="/profil" element={<Profil />}></Route>
                  <Route path="/" element={<Home showAllProducts={false} />}></Route>

              </Routes>
        </UserProvider>
    );
  }
}
