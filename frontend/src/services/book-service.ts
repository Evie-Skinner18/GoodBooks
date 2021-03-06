// you can use fetch for a small app like this but going to use Axios because that will be good preparation for future Vue apps

import axios from 'axios';
import IBook from '@/types/Book';

export default class BookService {

    // we can add env vars from .env file via process.env
    // 'https://localhost:5001/api'
    BASE_URL = process.env.VUE_APP_API_URL;

    public async getAllBooks(): Promise<IBook[]> {
        let response = await axios.get(`${this.BASE_URL}/books/`);
        return response.data;
    }

    public async addNewBook(book: IBook) {
        let response = await axios.post(`${this.BASE_URL}/books/`, book);
        return response.data;
    }

    // [HttpDelete("/api/books/{id}")] and pass in relevant id
    public async deleteBook(id: number) {
        let response = await axios.delete(`${this.BASE_URL}/books/${id}`);
        return response.data;
    }    
}