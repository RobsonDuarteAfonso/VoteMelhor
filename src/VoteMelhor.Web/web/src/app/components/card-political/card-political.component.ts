import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-card-political',
  templateUrl: './card-political.component.html',
  styleUrls: ['./card-political.component.css']
})
export class CardPoliticalComponent implements OnInit {

  @Input() backgroundRate = '';
  @Input() textColorRate = '';
  @Input() textRate = '';
  @Input() imageUrl = '';
  @Input() namePolitical = '';
  @Input() positionPolitical = '';
  @Input() textRateUsers = '';

  constructor() { }

  ngOnInit(): void {
  }

}
