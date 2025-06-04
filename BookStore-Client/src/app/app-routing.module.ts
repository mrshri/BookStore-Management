import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './book/book-list/book-list.component';
import { HomeComponent } from './home/home/home.component';
import { CategoryComponent } from './category/category-list/category-list.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { authGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },

  { path: 'home', component: HomeComponent },
  
  { path: 'books', component: BookListComponent,canActivate:[authGuard] },

  { path: 'categories', component: CategoryComponent ,canActivate:[authGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
