import { async, ComponentFixture, TestBed } from '@angular/core/testing';
// import { SignupComponent } from './login.component';
// import { SignupService } from './login.service';
import { SignupComponent } from './signup.component';
import { SignupService } from './signup-service.service';
import { RouterTestingModule } from '@angular/router/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { of } from 'rxjs';

describe('SignComponent', () => {
  let component: SignupComponent;
  let fixture: ComponentFixture<SignupComponent>;
  let SignupServiceSpy: jasmine.SpyObj<SignupService>;

  beforeEach(async(() => {
    const spy = jasmine.createSpyObj('SignupService', ['login']);

    TestBed.configureTestingModule({
      declarations: [SignupComponent],
      imports: [ReactiveFormsModule, RouterTestingModule],
      providers: [{ provide: SignupService, useValue: spy }],
    }).compileComponents();

    SignupServiceSpy = TestBed.inject(SignupService) as jasmine.SpyObj<SignupService>;
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SignupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('test_case5', () => {
    expect(component).toBeTruthy();
  });
});