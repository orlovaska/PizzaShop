import React from "react";
import MySelect from "./MySelect.tsx";

export interface IProductFilterProps {
  filter: {
    sort: string;
    query: string;
  };
  setFilter: (filter) => void;
}

function ProductFilter(props: IProductFilterProps) {
  const filter = props.filter;
  const setFilter = props.setFilter;
  return (
    <div>
      <input
        className="input-field"
        value={filter.query}
        onChange={(e) => setFilter({ ...filter, query: e.target.value })}
        placeholder="Поиск..."
      />
      <MySelect
        value={filter.sort}
        onChange={(selectedSort) =>
          setFilter({ ...filter, sort: selectedSort })
        }
        defaultValue="Сортировка"
        options={[
          { value: "name", name: "По названию" },
          { value: "price", name: "По цене" },
        ]}
      />
    </div>
  );
}
export default ProductFilter;
