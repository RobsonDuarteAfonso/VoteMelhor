import { Rating } from './../../models/rating.model';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-card-political',
  templateUrl: './card-political.component.html',
  styleUrls: ['./card-political.component.css']
})
export class CardPoliticalComponent implements OnInit {

  @Input() imageUrl = '';
  @Input() initialRate = '';
  @Input() namePolitical = '';
  @Input() positionPolitical = '';
  @Input() partyPolitical = '';
  @Input() statePolitical = '';
  @Input() publicRateText = '';
  @Input() rate: Rating[];
  colorRate = '';
  rateName = '';
  colorText = '';
  rateInitials = '';

  show = false;

  constructor() { }

  ngOnInit(): void {
    this.strip();
  }

  strip() {

    if (this.rate != null) {
      this.rateInitials = this.rate[0].rate;
    }

    switch (this.rateInitials) {

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

      case 'RUI':
        this.colorRate = 'background-orange';
        this.colorText = 'color-text-rate-white';
        this.rateName = 'RUIM';
        break;

      case 'PES':
        this.colorRate = 'background-red';
        this.colorText = 'color-text-rate-white';
        this.rateName = 'PÉSSIMO';
        break;

      default:
        this.colorRate = 'background-yellow';
        this.colorText = 'color-text-rate-black';
        this.rateName = 'REGULAR';
        break;
    }

    setTimeout(() => this.show = true, 1000);
  }

}
