import { Component, NgModule } from '@angular/core';
import { BookService } from '../../shared/services/book.service'; 
import { Book } from '../../shared/models/book';
import { CategoryService } from '../../shared/services/category.service';
import { Category } from '../../shared/models/category';

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
    this.bookService.getAllBooks().subscribe({
      next: (books) => {
        this.books = books;
        console.log('Books fetched successfully:', books);
         this.filteredBooks = books;;
      },
      error: (error) => {
        console.error('Error fetching books:', error);
      },
      });

    
  }

  filterBooks() {
  const term = this.searchTerm.toLowerCase();
  this.filteredBooks = this.books.filter(book =>
    book.title.toLowerCase().includes(term) || 
    book.author.toLowerCase().includes(term)
  );}

  toggleDescription(bookId: number): void {
    this.showFullDescription[bookId] = !this.showFullDescription[bookId];
  }
 
}
