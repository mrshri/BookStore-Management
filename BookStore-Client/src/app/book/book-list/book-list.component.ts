import { Component, NgModule } from '@angular/core';
import { BookService } from '../../shared/services/book.service'; 
import { Book } from '../../shared/models/book';
import { CategoryService } from '../../shared/services/category.service';

@Component({
  selector: 'app-book-list',
  standalone: false,
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
  providers: [BookService,CategoryService]
})

export class BookListComponent {

  books: Book[] = [];
  filteredBooks: Book[] = [];
  searchTerm: string = '';
  p: number = 1; 
  showFullDescription: { [bookId: number]: boolean } = {};

  constructor(private bookService:BookService,private categoryService:CategoryService) {}

  ngOnInit() {
    this.searchBooks();    
  }

  searchBooks() {
    this.bookService.getAllBooks(this.searchTerm).subscribe((books: Book[]) => {
      this.books = books;
      this.filterBooks(); 
    });
  }  

  filterBooks():void {
  const term = this.searchTerm.toLowerCase();
    this.filteredBooks = this.books.filter(book =>
    book.title.toLowerCase().includes(term) || 
    book.author.toLowerCase().includes(term) ||
    book.description.toLowerCase().includes(term)
  );
  this.p = 1; 
}

toggleDescription(bookId: number): void {
    this.showFullDescription[bookId] = !this.showFullDescription[bookId];
  }
 
}
