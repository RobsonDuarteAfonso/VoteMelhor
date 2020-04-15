import { PropositoComponent } from './components/proposito/proposito.component';
import { PesquisarComponent } from './components/pesquisar/pesquisar.component';
import { ContatoComponent } from './components/contato/contato.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'pesquisar', component: PesquisarComponent },
  { path: 'proposito', component: PropositoComponent },
  { path: 'contato', component: ContatoComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
