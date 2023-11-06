import React, { useState, useEffect } from "react";
import Header from "../Header.tsx";
import { getUsersCart } from "../../services/dataService.ts";
import ProfilEditor from "../ProfilEditor.tsx";
import { useUserContext } from "../../Context/UserContext.tsx";

function Profil() {
  const user = useUserContext()?.user;
  const [cartCount, setCartCount] = useState<number>(0);
  const [cartPrice, setCartPrice] = useState<number>(0);

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

  return (
    <>
      <Header cartCount={cartCount} cartPrice={cartPrice} />
      {user ? <ProfilEditor user={user} /> : null}
    </>
  );
}

export default Profil;
