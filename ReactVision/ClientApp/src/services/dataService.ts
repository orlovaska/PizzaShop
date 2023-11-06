import { json } from "react-router-dom";
import { ICategoryType, IProductType, IUserType, ICartsType } from "../types";
import { IAddressType } from "../typesUI/types";

export async function editUser(
    userId: number,
    firstName: string,
    lastName: string,
    email: string,
    phone: string
): Promise<void> {
    const url = `/app/editUser?userId=${userId}&firstName=${firstName}&lastName=${lastName}&email=${email}&phone=${phone} `;

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(response.status.toString());
        }
    } catch (error) {
        console.error(error);
    }
}
export async function addCustomer(
  firstName: string,
  lastName: string,
  email,
  phone: string,
    password: string,
): Promise<void> {
    const url = `/app/addCustomer?firstName=${firstName}&lastName=${lastName}&email=${email}&phone=${phone}&password=${password} `;

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(response.status.toString());
        }
    } catch (error) {
        console.error(error);
    }
}
export async function getAllCategories(): Promise<ICategoryType[]> {
    const url = `/app/getAllCategories`;

    try {
        const response = await fetch(url);
            const result = await response.json();
            return result;

    } catch (error) {
        console.error(error);
        return [];
    };
}
export async function getAllProducts(): Promise<IProductType[]> {
    const bool: boolean = true;
    const url = `/app/getAllProducts?hs=${bool}`;

    try {
        const response = await fetch(url);
        const result = await response.json();
        return result;
    } catch (error) {
        console.error(error);
        return [];
    }
}
export async function increaseQuantityOfProductInCart(
  userId: number,
  productId: number
): Promise<void> {
    const url = `/app/increaseQuantityOfProductInCart?userId=${userId}&productId=${productId}`;

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(response.status.toString());
        }
    } catch (error) {
        console.error(error);
    }
}
export async function reduceQuntityOfProductInCart(
  userId: number,
  productId: number
): Promise<void> {
    const url = `/app/reduceQuntityOfProductInCart?userId=${userId}&productId=${productId} `;

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(response.status.toString());
        }
    } catch (error) {
        console.error(error);
    }
}
export async function deleteProductFromCart(
  userId: number,
  productId: number
): Promise<void> {
    const url = `/app/deleteProductFromCart?userId=${userId}&productId=${productId} `;

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(response.status.toString());
        }
    } catch (error) {
        console.error(error);
    }

}
export async function emailIsUnique(email: string): Promise<boolean> {
    const url = `/app/emailIsUnique?email=${email} `;


    try {
        const response = await fetch(url);
        if (response.ok) {
            const result = await response.json();
            if (typeof result === 'boolean') {
                return result;
            } else {
                return false;
            }
        } else {
            throw new Error(response.status.toString());
        }
    } catch (error) {
        console.error(error);
        return false;
    }
}
export async function passwordVerification(
  email: string,
  password: string
): Promise<boolean> {
    const url = `/app/passwordVerification?email=${email}&password=${password} `;
    try {
        const response = await fetch(url);
        if (response.ok) {
            const result = await response.json();
            if (typeof result === 'boolean') {
                return result;
            } else {
                return false;
            }
        } else {
            throw new Error(response.status.toString());
        }
    } catch (error) {
        console.error(error);
        return false;
    }
}
export async function getUsersCart(userId: number): Promise<ICartsType[]> {
    const url = `/app/getUsersCart?userId=${userId}`;

    try {
        const response = await fetch(url);
        const result = await response.json();
        return result;

    } catch (error) {
        console.error(error);
        return [];
    };
}
export async function getUserByEmail(email: string): Promise<IUserType> {
    const url = `/app/getUserByEmail?email=${email}`;

    try {
        const response = await fetch(url);
        const customer = await response.json();

        const user: IUserType = {
            id: customer.id,
            firstName: customer.firstName,
            lastName: customer.lastName,
            phone: customer.phone,
            email: customer.email
        };

        return user;

    } catch (error) {
        console.error(error);
        return [];
    };
}
export async function addAddressByCustomer(
    customerId: number,
    address: string,
): Promise<IAddressType> {
    console.log("Зашло в addAddressByCustomer")
    const url = `/app/addAddressByCustomer?customerId=${customerId}&address=${address} `;
    try {
        const response = await fetch(url);
        const data = await response.json();

        const addedAddress: IAddressType = {
            id: data.id,
            address: data.address,
            customerId: data.customerId
        };

        return addedAddress;

    } catch (error) {
        console.error(error);
    };
}
export async function addNewOrderFromCarts(
    customerId: number,
    addressId: number,
    comment: string,
): Promise<void> {
    const url = `/app/addNewOrderFromCarts?customerId=${customerId}&addressId=${addressId}&comment=${comment} `;

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(response.status.toString());
        }
    } catch (error) {
        console.error(error);
    }
}

const user: IUserType = {
  id: 1,
  firstName: "Yakow",
  lastName: "Orlov",
  phone: "1234567890",
  email: "yacha@example.com",
};

// Создание 10 объектов CartsModel
const carts: ICartsType[] = Array.from({ length: 10 }, (_, index) => ({
  id: index + 1,
  quntity: index + 2,
  productId: index + 1,
  product: {
    id: index + 1,
    name: `Product ${index + 1}`,
    currentPrice: 10.99 + index * 2,
    imageUrl: `https://s3.smartofood.ru/rollme59_ru/menu/7f2ae889-45e1-5eaa-ac0f-aba8fb92226d.jpg`,
    categoryId: (index % 3) + 1,
  },
  price: (index + 2) * (10.99 + index * 2),
}));

const categories: ICategoryType[] = [
  {
    id: 1,
    name: "Категория есть продукты",
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/25f6f65d-d417-5fc4-936a-8996c366e9ec.jpg",
  },
  {
    id: 2,
    name: "Категория 2",
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/25f6f65d-d417-5fc4-936a-8996c366e9ec.jpg",
  },
  {
    id: 3,
    name: "Категория 3",
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/25f6f65d-d417-5fc4-936a-8996c366e9ec.jpg",
  },
  {
    id: 4,
    name: "Категория 4",
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/25f6f65d-d417-5fc4-936a-8996c366e9ec.jpg",
  },
  {
    id: 5,
    name: "Категория 5",
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/25f6f65d-d417-5fc4-936a-8996c366e9ec.jpg",
  },
  {
    id: 6,
    name: "Категория 6",
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/25f6f65d-d417-5fc4-936a-8996c366e9ec.jpg",
  },
];

const allProducts: IProductType[] = [
  {
    id: 1,
    name: "Product 1",
    currentPrice: 10.99,
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/7f2ae889-45e1-5eaa-ac0f-aba8fb92226d.jpg",
    categoryId: 1,
  },
  {
    id: 2,
    name: "Product 2",
    currentPrice: 1900.99,
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/7f2ae889-45e1-5eaa-ac0f-aba8fb92226d.jpg",
    categoryId: 2,
  },
  {
    id: 3,
    name: "Мда 3",
    currentPrice: 25.99,
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/7f2ae889-45e1-5eaa-ac0f-aba8fb92226d.jpg",
    categoryId: 1,
  },
  {
    id: 4,
    name: "Product 4",
    currentPrice: 10.99,
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/7f2ae889-45e1-5eaa-ac0f-aba8fb92226d.jpg",
    categoryId: 1,
  },
  {
    id: 5,
    name: "Product 5",
    currentPrice: 19.99,
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/7f2ae889-45e1-5eaa-ac0f-aba8fb92226d.jpg",
    categoryId: 2,
  },
  {
    id: 6,
    name: "Product 6",
    currentPrice: 25.99,
    imageUrl:
      "https://s3.smartofood.ru/rollme59_ru/menu/7f2ae889-45e1-5eaa-ac0f-aba8fb92226d.jpg",
    categoryId: 3,
  },
];
