import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from '../shared/services/book.service';

@Component({
  selector: 'app-category-books',
  standalone: false,
  templateUrl: './category-books.component.html',
  styleUrl: './category-books.component.css'
})
export class CategoryBooksComponent {
 books: any[] = [];

 constructor(private route:ActivatedRoute,private bookService:BookService) {}
 
 ngOnInit(): void {
  const categoryId = this.route.snapshot.paramMap.get('id');
  if (categoryId) {
    this.bookService.getBooksByCategory(categoryId).subscribe({
      next: (res) => {
        this.books = res;
      },
      error: (err) => console.error('API error:', err)
    });
  }
}

}
