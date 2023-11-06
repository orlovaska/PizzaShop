import React, { useState } from "react";
import strings from "../resources/ResourcesStrings";
import { Link, useNavigate, useLocation } from "react-router-dom";
import profil from "../assets/img/profil.png";
import logo from "../assets/img/logo.png";
import CartButton from "./CartButton.tsx";
import "./Header.css";

export interface IHeaderProps {
  cartCount: number;
  cartPrice: number;
}
function Header(props: IHeaderProps) {
  const navigate = useNavigate();
  const location = useLocation();

  const handleClickShowAllProducts = () => {
    if (location.pathname !== "/products") {
      navigate("/products");
    }
  };

  const handleClickShowHomePage = () => {
    if (location.pathname !== "/") {
      navigate("/");
    }
  };

  const handleClickShowMyOrders = () => {
    if (location.pathname !== "/myorders") {
      navigate("/myorders");
    }
  };

  const handleClickShowProfil = () => {
    if (location.pathname !== "/profil") {
      navigate("/profil");
    }
  };

  return (
    <header style={{
      position: "fixed",
      top: 0,
      left: 0,
      width: "100%",
      backgroundColor: "white",
      zIndex: 1000,
      boxShadow: "0px 2px 5px rgba(0, 0, 0, 0.1)"}}>
      <div className="grid-container">
        <div className="grid-item">
          <div className="logo">
            <img src={logo} alt="Логотип" />
          </div>
        </div>
        <div className="grid-item">
          <span className="store-name">PizzaShop React</span>
        </div>
        <div className="grid-item"></div>
        <div className="grid-item nav-links-container">
          <div
            onClick={handleClickShowAllProducts}
            className={`nav-links ${
              location.pathname === "/products" ? "active" : ""
            }`}
          >
            Все продукты
          </div>
          {/*<div*/}
          {/*  onClick={handleClickShowMyOrders}*/}
          {/*  className={`nav-links ${*/}
          {/*    location.pathname === "/myorders" ? "active" : ""*/}
          {/*  }`}*/}
          {/*>*/}
          {/*  Мои заказы*/}
          {/*</div>*/}
          <div
            onClick={handleClickShowHomePage}
            className={`nav-links ${location.pathname === "/" ? "active" : ""}`}
          >
            Главная
          </div>
        </div>
        <div className="grid-item">
          <div className="profile circle" onClick={handleClickShowProfil}>
            <img src={profil} alt="Профиль" />
          </div>
        </div>
        <div className="grid-item">
          <CartButton cartCount={props.cartCount} cartPrice={props.cartPrice} />
        </div>
      </div>
    </header>
  );
}

export default Header;
