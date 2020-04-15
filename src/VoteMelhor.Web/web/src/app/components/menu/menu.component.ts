import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  show = false;
  body: any;

  @ViewChild('header', { static: true }) element: ElementRef;





  constructor() { }

  ngOnInit() {
    this.body = this.element.nativeElement.ownerDocument.body;
  }

  menuToggle() {
    this.show = !this.show;
    this.body.style.overflow = this.show === true ? 'hidden' : 'Initial';

  }

}
