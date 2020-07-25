import { CommandResult } from './../../models/command-result.model';
import { Component, OnInit, Input } from '@angular/core';
import { Political } from 'src/app/models/political.model';

@Component({
  selector: 'app-list-political',
  templateUrl: './list-political.component.html',
  styleUrls: ['./list-political.component.css']
})
export class ListPoliticalComponent implements OnInit {

  @Input() listPolitical: Political[];

  constructor() { }

  ngOnInit(): void {
  }

}
