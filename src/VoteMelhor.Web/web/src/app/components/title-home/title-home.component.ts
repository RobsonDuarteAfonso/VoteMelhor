import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-title-home',
  templateUrl: './title-home.component.html',
  styleUrls: ['./title-home.component.css']
})
export class TitleHomeComponent implements OnInit {

  @Input() titleName = '';

  constructor() { }

  ngOnInit(): void {
  }

}
