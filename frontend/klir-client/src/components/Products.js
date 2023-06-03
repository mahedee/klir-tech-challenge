import React, {useState, useEffect} from 'react'
import { GetAllProducts } from '../services/ProductServices';
import Cards from './Cards';

function Products() {

    const [data, setData] = useState({productList: [], dataCount: 0, loading: true, error: ""});

    useEffect(()=>{
        let isMounted = true;
        if(isMounted){
          LoadProductsData();
          isMounted = false;
        }
        return () => {
          isMounted = false;
        } // cleanup funnction for reseting data value before every re-render
      },[])


    const LoadProductsData = () => {
        GetAllProducts()
        .then((response) => {
          setData({productList: response.data, dataCount: response.data.count, loading: false});
        })
        .catch((error) => {
          setData({productList: [], loading: false, error: "error loading data"});
          console.log("Error: ", error)
        });
      };

  return (
    <section>
    {
  
        data.productList.map((item) => (             
            <Cards key={item.id} item={item} />
        ))

    
    }
</section>
  )
}

export default Products