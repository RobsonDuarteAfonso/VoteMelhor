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
  @Input() publicRateColor = '';
  @Input() publicRateText = '';

  constructor() { }

  ngOnInit(): void {
  }

}
