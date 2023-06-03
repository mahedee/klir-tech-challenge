import logo from "./logo.svg";
import "./App.css";
import React, { useState } from "react";
import Navbar from "./components/Navbar";
import Products from "./components/Products";

function App() {
  const [show, setShow] = useState(true); //display cart item or product based on shows value
  const [cart, setCart] = useState([]);

  return (
    <React.Fragment>
      <Navbar cartsItem={cart.length}  setShow={setShow}></Navbar>
      <Products></Products>
    </React.Fragment>
  );
}

export default App;
