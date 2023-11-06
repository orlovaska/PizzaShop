import React, { useState, useEffect } from "react";
import CartItemList from "../CartItemList.tsx";
import strings from "../../resources/ResourcesStrings";
import { Link, useNavigate } from "react-router-dom";
import Header from "../Header.tsx";
import { useUserContext } from "../../Context/UserContext.tsx";
import { ICartsType } from "../types";
import {
  getUsersCart,
  increaseQuantityOfProductInCart,
  reduceQuntityOfProductInCart,
  deleteProductFromCart,
} from "../../services/dataService.ts";
import OrderSummary from "../OrderSummary.tsx";

function Cart() {
  const user = useUserContext()?.user;
    const navigate = useNavigate();
    const signupForm = strings?.signupForm;
  const [items, setItems] = useState<ICartsType[]>();
  const [cartCount, setCartCount] = useState<number>(0);
  const [cartPrice, setCartPrice] = useState<number>(0);

  useEffect(() => {
    async function fetchUsersCart() {
      const userId = user?.id ? user?.id : null;
      if (userId) {
        const cartItems = await getUsersCart(userId);
        setItems(cartItems);
        const productCount = cartItems.reduce(
          (total, item) => total + item.quntity,
          0
        );
        setCartCount(productCount);
        const total = cartItems.reduce((total, item) => total + item.price, 0);
        setCartPrice(total);
      }
    }

    fetchUsersCart();
  }, []);

  const handleIncreaseQuantityOfProductInCart = (cart: ICartsType) => {
    if (user) {
      setCartCount(cartCount + 1);
      setCartPrice(cartPrice + cart.product.currentPrice);
        fetchIncreaseQuantityOfProductInCart(user.id, cart.product.id);
    } else {
      navigate("/login");
    }
    };

    const fetchIncreaseQuantityOfProductInCart = async(userId: number, productId: number) => {
        try {
            await increaseQuantityOfProductInCart(userId, productId);
        } catch (error) {
            console.error("Ошибка при увеличении количества товара в корзине:", error);
        }
    };

  const handleReduceQuntityOfProductInCart = (cart: ICartsType) => {
    if (user) {
      setCartCount(cartCount - 1);
      setCartPrice(cartPrice - cart.product.currentPrice);
        fetchReduceQuntityOfProductInCart(user.id, cart.product.id);
    } else {
      navigate("/login");
    }
    };

    const fetchReduceQuntityOfProductInCart = async (userId: number, productId: number) => {
        try {
            await reduceQuntityOfProductInCart(userId, productId);
        } catch (error) {
            console.error("Ошибка при уменьшении количества товара в корзине:", error);
        }
    };
  const handleDeleteProductFromCart = (cart: ICartsType) => {
      if (user) {
          setCartCount(cartCount - cart.quantity);
      setCartPrice(cartPrice - cart.price);
        fetchDeleteProductFromCart(user.id, cart.product.id);
      const updatedItems = items?.filter((item) => item.id !== cart.id);
      setItems(updatedItems);
    } else {
      navigate("/login");
    }
    };

    const fetchDeleteProductFromCart = async (userId: number, productId: number) => {
        try {
            await deleteProductFromCart(userId, productId);
        } catch (error) {
            console.error("Ошибка при удалении товара из корзины:", error);
        }
    };

  const handleAddOrderDetailsFromCarts = () => {
    if (user) {
      setCartCount(0);
      setCartPrice(0);
      setItems(undefined);
        
    } else {
      navigate("/login");
    }
  };
  console.log(user)
  return (
    <div>
      <Header cartCount={cartCount} cartPrice={cartPrice}></Header>
      <div style={{ display: "flex", flexDirection: "row" }}>
        {cartCount > 0 ? (
          <>
            <div style={{ flex: 2 }}>
              <CartItemList
                cartItems={items}
                reduceQuantityOfProductFromCart={(cart) =>
                  handleReduceQuntityOfProductInCart(cart)
                }
                increaseQuantityOfProductInCart={(cart) =>
                  handleIncreaseQuantityOfProductInCart(cart)
                }
                deleteProductFromCart={(cart) =>
                  handleDeleteProductFromCart(cart)
                }
              />
            </div>
            <div
              style={{
                flex: 1,
                marginLeft: "20px",
                alignSelf: "flex-start",
                marginTop: "100px",
              }}
            >
              <OrderSummary
                onOrderPlaced={handleAddOrderDetailsFromCarts}
                cartPrice={cartPrice}
              />
            </div>
          </>
        ) : (user ?
                      <h1 style={{ marginLeft: "120px", marginTop: "120px", textAlign: "center" }}>Ваша корзина пуста</h1> :
                      <div style={{ marginLeft: "120px", marginTop: "120px", textAlign: "center" }}>
                          <h1>Авторизуйтесь, чтобы посмотреть</h1>
                          <p className="link-container">
                              <Link to="/login">{signupForm.signIn}</Link>
                          </p>
                      </div>

        )}
      </div>
    </div>
  );
}

export default Cart;
