import axios from "axios";

const API_URL = "http://localhost:5138/api/Book";

export const getBooks = async() => {
    const response = await axios.get(API_URL);
    return response.data;
}


