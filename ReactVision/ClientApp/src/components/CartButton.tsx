import React from "react";
import { useNavigate, useLocation } from "react-router-dom";
import "./CartButton.css";
import cart from "../assets/img/shopping-bag.png";

export interface IProductItemProps {
  cartCount: number;
  cartPrice: number;
}

function CartButton(props: IProductItemProps) {
  const navigate = useNavigate();
  const location = useLocation();

  const handleCartClick = () => {
    if (location.pathname !== "/cart") {
      navigate("/cart");
    }
  };
  const lightOvalClassName = props.cartPrice > 0 ? "light-orange-oval visible" : "light-orange-oval";
  const darkOvalClassName = props.cartPrice > 0 ? "dark-orange-oval visible" : "dark-orange-oval";

  return (
    <div className={lightOvalClassName} onClick={handleCartClick}>
      <div className="image-container">
        <img src={cart} alt="Cart" className="cart-image" />
        <p className="image-text">{props.cartCount}</p>
      </div>
        <div className={darkOvalClassName}>
            {props.cartPrice.toFixed(2)} ₽
        </div>
    </div>
  );
}

export default CartButton;
