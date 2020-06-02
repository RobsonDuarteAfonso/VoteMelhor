import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AppRoutingModule } from '../app-routing.module';
import { HomeComponent } from './home/home.component';
import { ComponentsModule } from './../components/components.module';
import { LoginComponent } from './login/login.component';
import { SearchComponent } from './search/search.component';
import { ContactComponent } from './contact/contact.component';
import { ProposalComponent } from './proposal/proposal.component';
import { CreateAccountComponent } from './create-account/create-account.component';

@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    SearchComponent,
    ContactComponent,
    ProposalComponent,
    CreateAccountComponent
  ],
  imports: [
    CommonModule,
    ComponentsModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule
  ]
})

export class PagesModule { }
