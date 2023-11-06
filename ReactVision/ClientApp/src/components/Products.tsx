import React, { useEffect, useState } from "react";
import { getAllProducts } from "../services/dataService.ts";
import ProductFilter from "./ProductFilter.tsx";
import ProductList from "./ProductList.tsx";
import { ICategoryType, IProductType } from "../types";

export interface IProductsProps {
  selectedCategory: ICategoryType | undefined;
  addToCart: (product: IProductType) => void;
}

function Products(props: IProductsProps) {
  const [products, setProducts] = useState<IProductType[]>([]);
  const [filter, setFilter] = useState({ sort: "", query: "" });

  useEffect(() => {
      const fetchProducts = async () => {
      const productsData = await getAllProducts();
      setProducts(productsData);
    };

      fetchProducts();
  }, []);

  const handleAddToCart = (product: IProductType) => {
    props.addToCart(product);
  };

  // Фильтрация и сортировка продуктов в зависимости от filter.sort и filter.query и selectedCategory
  const sortedAndSearchedProducts: IProductType[] = products
    .filter((product) =>
      product.name.toLowerCase().includes(filter.query.toLowerCase())
    )
    .filter((product) =>
      props.selectedCategory?.id
        ? product.categoryId === props.selectedCategory?.id
        : true
    )
    .sort((a, b) => {
      if (filter.sort === "name") {
        return a.name.localeCompare(b.name);
      }
      if (filter.sort === "price") {
        return a.currentPrice - b.currentPrice;
      }
      return 0;
    });
  return (
    <>
    <div style={{ display: "flex", justifyContent: "flex-end" }}>
  <ProductFilter filter={filter} setFilter={(filter) => setFilter(filter)} />
</div>
      {/* <ProductFilter
        filter={filter}
        setFilter={(filter) => setFilter(filter)}
      /> */}
      <ProductList
        products={sortedAndSearchedProducts}
        title="Список продуктов"
        addToCart={(product) => handleAddToCart(product)}
      />
    </>
  );
}

export default Products;
