import React from "react";
import strings from "../resources/ResourcesStrings";
import "./ProductItem.css";
import { IProductType } from "../types";

export interface IProductItemProps {
  product: IProductType;
  addToCart: (product: IProductType) => void;
};

function ProductItem(props: IProductItemProps) {
  const product = props.product;

  const handleAddToCart = () => {
    props.addToCart(props.product)
  }

  return (
    <div className="products_item" data-id={product.id}>
      <div className="products_item-wrapper">
        <img
          src={product.imageUrl}
          alt={product.name}
          className="image"
          loading="lazy"
        />
        <div className="products_item-body">
          <div className="products_item-margin">
            <div className="products_item-content">
              <div className="products_item-name">{product.name}</div>
                          <div className="products_item-size">{product.weightInGrams} г</div>
              <div className="products_item-desc">
                              {product.description}
              </div>
            </div>
            <div className="products_item-foot">
              <div className="products_item-price">{product.currentPrice} ₽</div>
              <button className="add-to-cart-button" onClick={handleAddToCart}>Добавить</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ProductItem;
