import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs';


import { CenterprofileComponent } from './centerprofile.component';


describe('CenterprofileComponent', () => {
  let component: CenterprofileComponent;
  let fixture: ComponentFixture<CenterprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        ReactiveFormsModule,
        HttpClientTestingModule
      ],
      declarations: [CenterprofileComponent],
    
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CenterprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('test_case3', () => {
    expect(component).toBeTruthy();
  });
});