import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  conteudo = 1;

  constructor() {
    this.MostrarConteudo(1);
   }

  ngOnInit() {
  }

  MostrarConteudo(value: number) {
    this.conteudo = value;
  }
}
