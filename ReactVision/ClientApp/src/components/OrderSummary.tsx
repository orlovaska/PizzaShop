import React, { useState } from "react";
import strings from "../resources/ResourcesStrings";
import "./OrderSummary.css";
import { addNewOrderFromCarts, addAddressByCustomer } from "../services/dataService.ts";
import { useUserContext } from "../Context/UserContext.tsx";
import { IAddressType } from "../typesUI/types";

export interface IOrderSummaryProps {
    cartPrice: number;
    onOrderPlaced: () => void;
}

function OrderSummary(props: IOrderSummaryProps) {
    const user = useUserContext()?.user;
    let confirmedAddress: IAddressType = null;
    const [comment, setComment] = useState<string>("");
    const [address, setAddress] = useState<string>("");
    const [error, setError] = useState<string>("");
    const [showError, setShowError] = useState<boolean>(false);

    const handleCommentChange = (event) => {
        setComment(event.target.value);
    };

    const handleAddress = (event) => {
        setAddress(event.target.value);
    };


    const fetchAddNewOrderFromCarts = async (userId: number, addressId: number, comment: string) => {
        try {
            await addNewOrderFromCarts(userId, addressId, comment);
        } catch (error) {
            console.error("Ошибка при создании заказа из элементов корзины:", error);
        }
    };

    const fetchAddAddressByCustomer = async (userId: number, address: string) => {
        try {
            const data: IAddressType = await addAddressByCustomer(userId, address);
            confirmedAddress = data;
        } catch (error) {
            console.error("Ошибка при добавлении адреса:", error);
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        if (!isValidAddress(address)) {
            return;
        }
        await fetchAddAddressByCustomer(user.id, address);
        await fetchAddNewOrderFromCarts(user.id, confirmedAddress.id, comment)
        props.onOrderPlaced()
    };

    const isValidAddress = (address): boolean => {
        if (address.length <= 0) {
            setError("Адрес не может быть пустым");
            setShowError(true);
            return false;
        }
        return true;
    };

    return (
        <div className="order-summary-container">
            <div style={{ display: "flex", flexDirection: "column" }}>
                <div style={{ display: "flex", flexDirection: "row" }} className="order-summary-total-container">
                    <div style={{ flex: 1 }} >Итого: </div>
                    <div style={{ flex: 1 }} className="order-summary-total-field">{props.cartPrice.toFixed(2)} ₽</div>
                </div>
                <input
                    className="order-summary-input-field"
                    value={comment}
                    onChange={handleCommentChange}
                    placeholder="Введите комментарий"
                />
                <input
                    className="order-summary-input-field"
                    value={address}
                    onChange={handleAddress}
                    placeholder="Введите адресс доставки"
                />
                <button onClick={handleSubmit} className="submit-button">
                    Оформить заказ
                </button>
            </div>
        </div>
    );
}

export default OrderSummary;
