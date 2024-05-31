import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuggesteduserComponent } from './suggesteduser.component';

describe('SuggesteduserComponent', () => {
  let component: SuggesteduserComponent;
  let fixture: ComponentFixture<SuggesteduserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SuggesteduserComponent]
    });
    fixture = TestBed.createComponent(SuggesteduserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
