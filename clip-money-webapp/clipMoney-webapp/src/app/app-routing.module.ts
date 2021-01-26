import { MyMovementsComponent } from './components/my-movements/my-movements.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LastMovementsComponent } from './components/last-movements/last-movements.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { TransfersComponent } from './components/transfers/transfers.component';

const routes: Routes = [
  {path: '', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'transfers', component: TransfersComponent},
  {path: 'lastMovements', component: LastMovementsComponent},
  {path: 'home', component: HomeComponent},
  {path: 'myMovements', component: MyMovementsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
