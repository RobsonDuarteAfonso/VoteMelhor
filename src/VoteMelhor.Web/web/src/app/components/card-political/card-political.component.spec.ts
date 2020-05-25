import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardPoliticalComponent } from './card-political.component';

describe('CardPoliticalComponent', () => {
  let component: CardPoliticalComponent;
  let fixture: ComponentFixture<CardPoliticalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardPoliticalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardPoliticalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
