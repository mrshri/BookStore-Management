import { Component } from '@angular/core';
import { CategoryService } from '../../shared/services/category.service';
import { Category } from '../../shared/models/category';

@Component({
  selector: 'app-category-list',
  standalone: false,
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css',
  providers: [CategoryService] // Add any services needed for this component here

})
export class CategoryListComponent {
categories: Category[] = []; // Adjust type as per your Category model

constructor(private categoryService: CategoryService) {}
ngongOnInit() {
  // Initialization logic can go here
  this.categoryService.getCategories().subscribe({
    next: (categories) => {
      this.categories = categories;
      console.log('Categories fetched successfully:', categories);
    },
    error: (error) => {
      console.error('Error fetching categories:', error);
    }
  }); 
}
}
