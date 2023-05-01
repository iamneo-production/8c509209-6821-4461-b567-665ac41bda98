import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs';

import { AppointmentComponent } from './appointment.component';
import { LoginService } from '../login/login.service';
import { ProductModelService } from './product-model.service';
import { ProductModel } from './productmodel';

describe('AppointmentComponent', () => {
  let component: AppointmentComponent;
  let fixture: ComponentFixture<AppointmentComponent>;
  let loginService: LoginService;
  let productModelService: ProductModelService;


  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        ReactiveFormsModule,
        HttpClientTestingModule
      ],
      declarations: [AppointmentComponent],
      providers: [LoginService, ProductModelService]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppointmentComponent);
    component = fixture.componentInstance;
    loginService = TestBed.inject(LoginService);
    productModelService = TestBed.inject(ProductModelService);
    spyOn(loginService, 'get').and.returnValue('1');

  });

  it('test_case2', () => {
    expect(component).toBeTruthy();
  });
});