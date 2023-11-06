import React, { useState } from "react";
import strings from "../resources/ResourcesStrings";
import "./CategoryItem.css";
import { ICategoryType } from "../types";

export interface ICategoryItemProps {
  category: ICategoryType;
  onSelectCategory: (category: ICategoryType) => void;
}

function CategoryItem(props: ICategoryItemProps) {
  const category = props.category;

  return (
    <div className="category_item" data-id={category.id}>
      <div className="category_item-wrapper">
        <img
          src={category.imageUrl}
          alt={category.name}
          className="image"
          loading="lazy"
        />
        <div className="category_item-body">
          <div className="category_item-margin">
            <div className="category_item-content">
              <div className="category_item-name">{category.name}</div>
            </div>
            <button
              className="go-to-button"
              onClick={() => props.onSelectCategory(category)}
            >
              Перейти
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default CategoryItem;
