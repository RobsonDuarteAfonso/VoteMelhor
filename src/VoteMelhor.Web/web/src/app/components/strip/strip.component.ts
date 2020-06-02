import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-strip',
  templateUrl: './strip.component.html',
  styleUrls: ['./strip.component.css']
})
export class StripComponent implements OnInit {

  @Input() rate = '';
  colorRate = '';
  rateName = '';
  colorText = '';

  constructor() { }

  ngOnInit(): void {
    switch (this.rate) {

      case 'EXC':
        this.colorRate = 'background-green';
        this.colorText = 'color-text-rate-white';
        this.rateName = 'EXCELENTE';
        break;

      case 'BOM':
        this.colorRate = 'background-blue';
        this.colorText = 'color-text-rate-white';
        this.rateName = 'BOM';
        break;

      case 'REG':
        this.colorRate = 'background-yellow';
        this.colorText = 'color-text-rate-black';
        this.rateName = 'REGULAR';
        break;

      case 'RUI':
        this.colorRate = 'background-orange';
        this.colorText = 'color-text-rate-white';
        this.rateName = 'RUIM';
        break;

      default:
        this.colorRate = 'background-red';
        this.colorText = 'color-text-rate-white';
        this.rateName = 'PÉSSIMO';
        break;
    }
  }

}
