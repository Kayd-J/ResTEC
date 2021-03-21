import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheffOwnedComponent } from './cheff-owned.component';

describe('CheffOwnedComponent', () => {
  let component: CheffOwnedComponent;
  let fixture: ComponentFixture<CheffOwnedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CheffOwnedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CheffOwnedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
