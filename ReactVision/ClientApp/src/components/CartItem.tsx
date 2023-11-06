import React, { useState } from "react";
import { ICartsType } from "../types";
import garbage from "../assets/img/garbage.png";
import CounterButtons from "./CounterButtons.tsx";
import "./CartItem.css";
import MyModal from "../components/MyModal/MyModal.jsx";

export interface ICartItemProps {
  cartItem: ICartsType;
  reduceQuantityOfProductFromCart: (cart: ICartsType) => void;
  increaseQuantityOfProductInCart: (cart: ICartsType) => void;
  deleteProductFromCart: (cart: ICartsType) => void;
}

function CartItem(props: ICartItemProps) {
    //const cartItem = props.cartItem
    const product = props.cartItem.product;
    const [price, setPrice] = useState<number>(props.cartItem.price);
    const [quantity, setQuantity] = useState<number>(props.cartItem.quntity);


  const handleReduceQuantityOfProductFromCart = () => {
      setPrice(price - product.currentPrice);
      setQuantity(quantity - 1);
      const updatedCartItem = {
          ...props.cartItem, // Копируем все свойства из оригинального cartItem
          price: price, // Устанавливаем новое значение для Price
          quantity: quantity // Устанавливаем новое значение для Quantity
      };
    if (quantity === 1) {
        props.deleteProductFromCart(updatedCartItem);
        return;
    }
      props.reduceQuantityOfProductFromCart(updatedCartItem);
    };

    const handleIncreaseQuantityOfProductInCart = () => {
        const updatedCartItem = {
            ...props.cartItem, // Копируем все свойства из оригинального cartItem
            price: price, // Устанавливаем новое значение для Price
            quantity: quantity // Устанавливаем новое значение для Quantity
        };
        setPrice(price + product.currentPrice);
        setQuantity(quantity + 1);
        props.increaseQuantityOfProductInCart(updatedCartItem)
    };

    const handleDeleteProductFromCart = () => {
        const updatedCartItem = {
            ...props.cartItem, // Копируем все свойства из оригинального cartItem
            price: price, // Устанавливаем новое значение для Price
            quantity: quantity // Устанавливаем новое значение для Quantity
        };
        props.deleteProductFromCart(updatedCartItem)
    };

  return (
    <div className="cart-item-container">
      <div className="grid-item cart-product-image">
        <div>
          <img
            className="cart-product-image"
            src={product.imageUrl}
            alt="Продукт"
          />
        </div>
      </div>
      <div className="grid-item">
        <div style={{ display: "flex", flexDirection: "column" }}>
          <div>{product.name}</div>
          <div>{product.currentPrice.toFixed(2)} ₽</div>
        </div>
      </div>
      <div className="grid-item left">
        <CounterButtons
          defaultValue={quantity}
          onValueReduce={handleReduceQuantityOfProductFromCart}
                  onValueIncrease={handleIncreaseQuantityOfProductInCart}
        ></CounterButtons>
      </div>
          <div className="grid-item">{price.toFixed(2)} ₽</div>
      <div className="grid-item">
              <div className="profile circle" onClick={handleDeleteProductFromCart}>
          <img src={garbage} alt="Удалить" />
        </div>
      </div>
    </div>
  );
}

export default CartItem;
