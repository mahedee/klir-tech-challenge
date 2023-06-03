import React from 'react'
import '../styles/navbar.css'

export default function Navbar({cartsItem, setShow}) {
    return (
        <nav>
            <div className='nav_box'>
                <span className='my_shop' onClick={()=>setShow(true)}>
                    Klir Tech Challenge
                </span>
                <div className='cart' onClick={()=>setShow(false)}>
                    <span>
                        <i className='fas fa-cart-plus'></i>
                    </span>
                    <span>{cartsItem}</span>
                </div>
            </div>
        </nav>
    )
}
