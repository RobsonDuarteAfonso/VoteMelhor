import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RelAvaliadosComponent } from './rel-avaliados.component';

describe('RelAvaliadosComponent', () => {
  let component: RelAvaliadosComponent;
  let fixture: ComponentFixture<RelAvaliadosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RelAvaliadosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RelAvaliadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
