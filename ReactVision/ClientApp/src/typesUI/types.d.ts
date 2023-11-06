export interface IProductType {
  id: number;
  name: string;
  currentPrice: number;
    imageUrl: string;
    description: string;
    weightInGrams: number;
  categoryId: number;
}

interface IUserType {
  id: number;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
}

interface ICartsType {
  id: number;
  quantity: number;
  productId: number;
  product: IProductType;
  price: number;
}

export interface ICategoryType {
  id: number;
  name: string;
  imageUrl: string
}

// export interface IOrderDetailType {
//   id: number;
//   quantity: number;
//   priceAtCheckout: number;
//   productId: number;
//   orderId: number;
//   // order: OrderModel;
//   product: IProductType;
// }


// AddressModel.ts
export interface IAddressType {
  id: number;
  address: string;
  customerId: number;
}
