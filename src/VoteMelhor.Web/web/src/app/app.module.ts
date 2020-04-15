import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { HomeComponent } from './components/home/home.component';
import { ContatoComponent } from './components/contato/contato.component';
import { PropositoComponent } from './components/proposito/proposito.component';
import { PesquisarComponent } from './components/pesquisar/pesquisar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginComponent } from './components/login/login.component';
import { NovoCadastroComponent } from './components/novo-cadastro/novo-cadastro.component';
import { HttpClientModule } from '@angular/common/http';
import { RelAvaliadosComponent } from './components/rel-avaliados/rel-avaliados.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    ContatoComponent,
    PropositoComponent,
    PesquisarComponent,
    LoginComponent,
    NovoCadastroComponent,
    RelAvaliadosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
