import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonRealEditingComponent } from './person-real-editing.component';

describe('PersonRealEditingComponent', () => {
  let component: PersonRealEditingComponent;
  let fixture: ComponentFixture<PersonRealEditingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonRealEditingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonRealEditingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
