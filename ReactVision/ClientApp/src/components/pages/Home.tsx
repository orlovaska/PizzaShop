import React, { useEffect, useState } from "react";
import {useNavigate} from "react-router-dom"
import Header from "../Header.tsx";
import Menu from "../Menu.tsx";
import { increaseQuantityOfProductInCart, getUsersCart } from "../../services/dataService.ts";
import { IProductType } from "../types";
import { useUserContext } from "../../Context/UserContext.tsx";

export interface IHomeProps{
  showAllProducts: boolean;
}

function Home(props: IHomeProps) {
  const navigate = useNavigate();
  const user= useUserContext()?.user;
  const [cartCount, setCartCount] = useState(0);
    const [cartPrice, setCartPrice] = useState(0);
    useEffect(() => {
        if (!user) {
            navigate("/login");
        }
    }, []); 

    useEffect(() => {
        async function fetchUsersCart() {
            const userId = user?.id ? user?.id : null;
            if (userId) {
                const cartItems = await getUsersCart(userId);
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

  const handleIncreaseQuantityOfProductInCart = (product: IProductType) => {
    if (user) {
        setCartCount(cartCount + 1);
        setCartPrice(cartPrice + product.currentPrice);
      increaseQuantityOfProductInCart(user.id, product.id);
    } else {
      navigate("/login");
    }
  };
 
  return (
    <div>
      <Header
        cartCount={cartCount}
        cartPrice={cartPrice}
      />
      <Menu
        showAllProducts={props.showAllProducts}
        addToCart={(product) => handleIncreaseQuantityOfProductInCart(product)}
      />
    </div>
  );
}

export default Home;
