import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TitleHomeComponent } from './title-home.component';

describe('TitleHomeComponent', () => {
  let component: TitleHomeComponent;
  let fixture: ComponentFixture<TitleHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TitleHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TitleHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
