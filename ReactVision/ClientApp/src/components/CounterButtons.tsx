import React, { useState } from "react";
import "./CounterButtons.css"; // Подключите файл стилей для компонента

export interface ICounterButtonsProps {
  defaultValue: number;
  onValueReduce: () => void;
  onValueIncrease: () => void;
}

function CounterButtons(props: ICounterButtonsProps) {
  const [value, setValue] = useState(props.defaultValue);

  const incrementValue = () => {
    props.onValueIncrease();
    setValue(value + 1);
  };

  const decrementValue = () => {
    if (value != 0) {
      props.onValueReduce();
      setValue(value - 1);
    }
  };
  return (
    <div className="oval-container">
      <button
        className={value == 0 ? "oval-button cant-use" : "oval-button"}
        onClick={decrementValue}
      >
        -
      </button>
      <span className="oval-value">{value}</span>
      <button className="oval-button" onClick={incrementValue}>
        +
      </button>
    </div>
  );
}

export default CounterButtons;
