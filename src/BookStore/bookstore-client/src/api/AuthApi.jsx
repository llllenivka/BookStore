import axios from "axios";

const API_URL = "http://localhost:5138/api/User";

export const loginUser = async (email, password) => {
    try {
        const response = await axios.post(`${API_URL}/login`, 
            { email, password },
            { withCredentials: true } 
        );
        console.log("Успешный вход");
        return response.data;
    } catch (error) {
        console.error('Ошибка при входе: ', error);
        throw error;
    }
}

export const registerUser = async (name, email, password) => {
    try {
        const role = "User";
        const response = await axios.post(`${API_URL}/register`, {
            name, 
            email,
            password,
            role
        });
        return response;
    } catch (error) {
        console.error('Ошибка при регистрации: ', error);
        throw error;
    }
}
