import React, { useState, useEffect } from "react";
import strings from "../resources/ResourcesStrings";
import CategoryList from "../components/CategoryList.tsx";
import { ICategoryType, IProductType } from "../types";
import { getAllCategories } from "../services/dataService.ts";
import Products from "./Products.tsx";

export interface IMenuProps {
  showAllProducts: boolean;
  addToCart: (product: IProductType) => void;
}

function Menu(props: IMenuProps) {
  const [showProductsByCategory, setShowProductsByCategory] = useState<boolean>();
  const [selectedCategory, setSelectedCategory] = useState<ICategoryType | undefined>();
  const [categories, setCategories] = useState<ICategoryType[]>();

  useEffect(() => {
    if (props.showAllProducts) {
        setSelectedCategory(undefined); // Обнуляем selectedCategory
        setShowProductsByCategory(!props.showAllProducts)
    }
  }, [props.showAllProducts]);

    useEffect(() => {
        async function fetchData() {
            try {
                const data: string[] = await getAllCategories();
                setCategories(data);
            } catch (error) {
                console.error("Ошибка при получении данных о категориях:", error);
            }
        }

        fetchData();
    }, []);

  const handleAddToCart = (product: IProductType) => {
   props.addToCart(product);
  };

  const handleChangeSelectCategory = (category: ICategoryType) => {
    setShowProductsByCategory(true);
    setSelectedCategory(category);
  };

  return (
    <div style={{ marginTop: "100px" }}>
      {props.showAllProducts || showProductsByCategory ? (
        <Products selectedCategory={selectedCategory} addToCart={product => handleAddToCart(product)
        } ></Products>
      ) : (
        <CategoryList
          categories={categories}
          onChangeSelectCategory={(category) =>
            handleChangeSelectCategory(category)
          }
        ></CategoryList>
      )}
    </div>
  );
}

export default Menu;
