import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountableComponent } from './accountable.component';

describe('AccountableComponent', () => {
  let component: AccountableComponent;
  let fixture: ComponentFixture<AccountableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccountableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
