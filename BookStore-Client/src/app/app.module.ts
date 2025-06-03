import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { BookService } from './shared/services/book.service';

import { JwtModule } from '@auth0/angular-jwt';
import { NgxPaginationModule } from 'ngx-pagination';
import { HomeComponent } from './home/home/home.component';
import { NavbarComponent } from './shared/navbar/navbar/navbar.component';
import { CategoryComponent } from './category/category-list/category-list.component';

export function tokenGetter() {
  return localStorage.getItem('access_token');
}

const routes: Routes = [
  { path: '', component: BookListComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    BookListComponent,
    HomeComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    NgxPaginationModule,
    RouterModule.forRoot(routes), // ✅ use forRoot here
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5001'],
        disallowedRoutes: [
          'localhost:5001/api/auth/login',
          'localhost:5001/api/auth/register'
        ]
      }
    })
  ],
  providers: [BookService],
  bootstrap: [AppComponent]
})
export class AppModule { }
