import React from "react";
import "./MySelect.css";

const MySelect = ({ options, defaultValue, value, onChange }) => {
  return (
    <select
      className="custom-select"
      value={value}
      onChange={(event) => onChange(event.target.value)}
    >
      <option disabled value="">
        {defaultValue}
      </option>
      {options.map((option) => (
        <option
          key={option.value}
          value={option.value}
          className="select-option"
        >
          {option.name}
        </option>
      ))}
    </select>
  );
};

export default MySelect;
