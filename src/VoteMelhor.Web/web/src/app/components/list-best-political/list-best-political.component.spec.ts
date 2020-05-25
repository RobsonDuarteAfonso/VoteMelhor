import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBestPoliticalComponent } from './list-best-political.component';

describe('ListBestPoliticalComponent', () => {
  let component: ListBestPoliticalComponent;
  let fixture: ComponentFixture<ListBestPoliticalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListBestPoliticalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListBestPoliticalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
