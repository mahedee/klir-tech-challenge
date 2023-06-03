import axios from "axios";
import { Base_API_URL } from "../utils/BaseURL";

export const GetAllProducts = () =>{
    try{
        //console.log(Base_API_URL + `/Products`);
        const response = axios.get(Base_API_URL + `/Products/GetAll`);
        return response;

    }catch(error){
        throw error;
    }
}