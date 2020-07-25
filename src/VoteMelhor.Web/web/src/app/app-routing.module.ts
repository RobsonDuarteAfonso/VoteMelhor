import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './views/login/login.component';
import { HomeComponent } from './views/home/home.component';
import { ProposalComponent } from './views/proposal/proposal.component';
import { SearchComponent } from './views/search/search.component';
import { ContactComponent } from './views/contact/contact.component';
import { CreateAccountComponent } from './views/create-account/create-account.component';


const routes: Routes = [
  { path: 'search', component: SearchComponent },
  { path: 'proposal', component: ProposalComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'login', component: LoginComponent },
  { path: 'create-account', component: CreateAccountComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
