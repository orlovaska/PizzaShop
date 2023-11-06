import React from "react";
import strings from "../resources/ResourcesStrings";
import "./CartItemList.css";
import { ICartsType } from "../types";
import CartItem from "./CartItem.tsx";

export interface ICartItemListProps {
  cartItems: ICartsType[] | undefined;
  reduceQuantityOfProductFromCart: (cart: ICartsType) => void;
  increaseQuantityOfProductInCart: (cart: ICartsType) => void;
  deleteProductFromCart: (cart: ICartsType) => void;
}

function CartItemList(props: ICartItemListProps) {
  const cartItems = props.cartItems;
  const totalCount = cartItems?.length;

  if (totalCount == 0) {
    return <div>В корзине пусто</div>;
  }

  return (
    <div className="cart-item-list">
      {cartItems?.map((category) => (
        <CartItem
          key={category.id}
          cartItem={category}
          reduceQuantityOfProductFromCart={(cart) =>
            props.reduceQuantityOfProductFromCart(cart)
          }
          increaseQuantityOfProductInCart={(cart) =>
            props.increaseQuantityOfProductInCart(cart)
          }
          deleteProductFromCart={(cart) => props.deleteProductFromCart(cart)}
        />
      ))}
    </div>
  );
}

export default CartItemList;
