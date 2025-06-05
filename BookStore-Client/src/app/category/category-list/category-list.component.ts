import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../shared/services/category.service';
import { Category } from '../../shared/models/category';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-list',
  standalone: false,
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css',

})
export class CategoryComponent implements OnInit {
  categories: Category[] = [];

  constructor(private categoryService: CategoryService,private router:Router) {}

  ngOnInit(): void {
    this.categoryService.getAllCategories().subscribe({
      next: (data) => {
        this.categories = data;
      },
      error: (err) => {
        console.error('Error fetching categories:', err);
      }
    });    
  }
  viewBooksByCategory(categoryId: number) {
  this.router.navigate(['/categories', categoryId]);
}
}