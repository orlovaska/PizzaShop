import React from "react";
import strings from "../resources/ResourcesStrings";
import "./ProductList.css";
import ProductItem from "./ProductItem.tsx";
import { IProductType } from "../types";

export interface IProductListProps {
  products: IProductType[];
  title: strings;
  addToCart: (product: IProductType) => void;
}

function ProductList(props: IProductListProps) {
  const products: IProductType[] = props.products;

  const handleAddToCart = (product: IProductType) => {
    props.addToCart(product);
  }
  
  //if (products.length <= 0) {
  //  return <h1 style={{ textAlign: "center" }}>Продукты не найдены!</h1>;
  //}

  return (
    <div className="product-list">
      {products.map((product) => (
        <ProductItem key={product.id} product={product} addToCart= {product => handleAddToCart(product)}
         />
      ))}
    </div>
  );
}

export default ProductList;
