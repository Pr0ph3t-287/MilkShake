import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginComponent } from "./pages/login/login.component";
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './pages/register/register.component';
import { OrderComponent } from './pages/order/order.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'order', component: OrderComponent }
  
]

@NgModule({
  declarations: [],
  exports: [
    RouterModule,
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
  ]
})
export class AppRoutingModule { }
