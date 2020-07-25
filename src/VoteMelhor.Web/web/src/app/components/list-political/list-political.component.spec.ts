import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPoliticalComponent } from './list-political.component';

describe('ListPoliticalComponent', () => {
  let component: ListPoliticalComponent;
  let fixture: ComponentFixture<ListPoliticalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListPoliticalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPoliticalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
