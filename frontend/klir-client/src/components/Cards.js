import React from 'react'
import '../styles/cards.css'

export const Cards = ({item}) => {
  
  const {name, price, promotionTitle} = item;
  const imgURL = 'ddd.jpg';
  return (
    <div className="cards">
        <div className="image_box">
            <img src={imgURL} alt={name} />
        </div>
        <div className="details">
            <p>{name}</p>
            <p>{promotionTitle}</p>
            <p>Price - ${price}</p>
            <button> Add to Cart</button>
        </div>
    </div>
  )
}


export default Cards