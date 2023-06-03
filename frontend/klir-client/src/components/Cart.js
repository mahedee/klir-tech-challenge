import React, { useEffect, useState } from "react";
import "../styles/cart.css";
import { DeleteCartItem, GetUsersCart } from "../services/CartServices";

export const Cart = ({ cart, setCart, handleQuantityChange }) => {
  //console.log("Cart componet -> cart", cart);
  const [data, setData] = useState({
    usersCart: cart,
    dataCount: 0,
    loading: true,
    error: "",
  });
  const [price, setPrice] = useState(0);

  const imgURL = "ddd.jpg";

  const handlePrice = (cart) => {
    let totalPrice = 0;
    cart.map((item) => (totalPrice += item.totalPrice));
    setPrice(totalPrice);
  };

  const removeCartItem = (id) => {
    DeleteCartItem(id)
      .then((response) => {
        console.log("Data deleted successfully! ");
      })
      .catch((error) => {
        console.log("There is an error to delete cart item! ");
      });
  };

  const handleRemove = (id) => {
    removeCartItem(id);
    const arr = cart.filter((item) => item.id !== id);
    setCart(arr);
    handlePrice(cart);
  };

  const loadUsersCart = () => {
    GetUsersCart()
      .then((response) => {
        //console.log("users cart item response", response.data);
        setData({
          usersCart: response.data,
          dataCount: response.data.count,
          loading: false,
        });
        handlePrice(response.data);
      })
      .catch((error) => {
        setData({ usersCart: [], loading: false, error: "error loading data" });
        console.log("Error: ", error);
      });
  };

  useEffect(() => {
    let isMounted = true;
    if (isMounted) {
      loadUsersCart();
      isMounted = false;
    }
  }, [cart]);

  return (
    <article>
      {data.usersCart?.map((item) => (
        <div className="cart_box" key={item.id}>
          <div className="cart_img">
            <img src={imgURL} alt={item.productName} />
            <p>{item.productName}</p>
          </div>
          <div>
            <button onClick={() => handleQuantityChange(item, +1)}>+</button>
            <button>{item.quantity}</button>
            <button onClick={() => handleQuantityChange(item, -1)}>-</button>
          </div>
          <div>
            <span>{item.unitPrice}</span>
          </div>
          <div>
            <span>{item.totalPrice}</span>
          </div>
          <div>
            <button onClick={() => handleRemove(item.id)}>Remove</button>
          </div>
        </div>
      ))}

      <div className="total">
        <span>Total price of your cart</span>
        <span>${price}</span>
      </div>
    </article>
  );
};

export default Cart;
