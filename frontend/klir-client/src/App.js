import logo from "./logo.svg";
import "./App.css";
import './styles/common.css'
import React, { useState, useEffect } from "react";
import Navbar from "./components/Navbar";
import Products from "./components/Products";
import Cart from './components/Cart';
import { AddItemToCart, EditCartItem, GetUsersCart} from './services/CartServices';

function App() {
  const [show, setShow] = useState(true); //display cart item or product based on shows value
  const [cart, setCart] = useState([]);
  const [warning, setWarning] = useState(false); // item is already added to cart

  const initialCartItem = {
    id: 0,
    productId: 0,
    unitPrice: 0,
    quantity: 0,
  };

  const [cartItem, setCartItem] = useState(initialCartItem);


  useEffect(() => {
    GetUsersCart()
      .then((response) => {
        //console.log("users cart item response", response.data);
        setCart(response.data);
      })
      .catch((error) => {
        setCart([]);
        //setData({ usersCart: [], loading: false, error: "error loading data" });
        console.log("Error: ", error)
      });
  }, [])


  const handleAddToCart = (item) => {
    //console.log('Cart item', item);

    // Check item is already exists or not
    let isPresent = false;
    cart.forEach((product) => {
      if (item.id === product.id)
        isPresent = true;
    })
    if (isPresent) {
      setWarning(true);
      setTimeout(() => {
        setWarning(false)
      }, 2000)
      return;
    }

    cartItem.id = 0;
    cartItem.productId = item.id;
    cartItem.unitPrice = item.price;
    cartItem.quantity = 1;

    setCartItem({ ...cartItem });

    // insert new item to database
    AddItemToCart(cartItem)
      .then((response) => {
      }, (error) => {
        throw error;
      })
      .catch((error) => {
        throw error;
      });


    // Add new item with existing item
    setCart([...cart, item]);
  }


  // handle quantity change d can be +1 or -1
  const handleQuantityChange = (item, d) => {
    let _index = -1;

    // find the index of the item
    cart.forEach((data, index) => {
      if (data.id === item.id)
        _index = index;
    });

    // return if item not found 
    if (_index < 0)
      return;

    // Keep cart in a temporary array
    const tempCart = cart;

    tempCart[_index].quantity += d;
    
    // user cannot decrease to less than 1
    // can either remove

    if (tempCart[_index].quantity === 0)
      tempCart[_index].quantity = 1;
  
    EditCartItem(item.id, tempCart[_index])
      .then((response) => {
        console.log(" updated item ",response.data);
        tempCart[_index] = response.data;

        console.log("Update in client side",tempCart[_index]);
      }, (error) => {
        throw (error);
      }
      )
      .catch((error) => {
        throw (error);
      });

    // set cart with new value
    setCart([...tempCart]);

  }


  return (
    <React.Fragment>
      <Navbar cartsItem={cart.length}  setShow={setShow}/>
      {
        show ? <Products handleAddToCart={handleAddToCart}/>
          : <Cart cart={cart} setCart={setCart} handleQuantityChange={handleQuantityChange} />
      }

      
      {
        warning && <div className='warning'>Item is already added to your cart</div>
      }

    </React.Fragment>
  );
}

export default App;
