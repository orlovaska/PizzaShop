import React, { useState } from "react";
import strings from "../resources/ResourcesStrings";
import "./ProductList.css";
import { ICategoryType } from "../types";
import CategoryItem from "./CategoryItem.tsx";

export interface ICategoryListProps {
  categories: ICategoryType[] | undefined;
  onChangeSelectCategory: (category: ICategoryType) => void;
}

function CategoryList(props: ICategoryListProps) {
  const categories = props.categories;
  if (categories && categories.length <= 0) {
    return <h1 style={{ textAlign: "center" }}>Категории не найдены!</h1>;
  }

  return (
    <div className="product-list">
    {categories?.map(category => (
      <CategoryItem key={category.id} category={category} onSelectCategory={props.onChangeSelectCategory} />
    ))}
  </div>

  );
}

export default CategoryList;
