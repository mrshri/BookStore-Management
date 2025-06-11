import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private apiUrl = 'https://localhost:7293/api/book';
  constructor(private http:HttpClient) { }

  getAllBooks(searchTerm:string=' '): Observable<Book[]> {
    let params = new HttpParams();
    if (searchTerm) {
      params =  params.set('search',searchTerm)
    }
    return this.http.get<Book[]>(this.apiUrl, { params });
  }

  getBook(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/${id}`);
  }
  getBooksByCategory(categoryId: string) {
  return this.http.get<Book[]>(`https://localhost:7293/api/book/category/${categoryId}`);
}

}
