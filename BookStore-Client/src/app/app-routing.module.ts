import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './book/book-list/book-list.component';
import { HomeComponent } from './home/home/home.component';
import { CategoryComponent } from './category/category-list/category-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent },

  { path: 'home', component: HomeComponent },
  
  { path: 'books', component: BookListComponent },

  { path: 'categories', component: CategoryComponent },
  // { path: 'login', component: LoginComponent },
  // { path: 'register', component: RegisterComponent }
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
