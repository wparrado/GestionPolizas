import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionPolizaComponent } from './adicion-poliza.component';

describe('AdicionPolizaComponent', () => {
  let component: AdicionPolizaComponent;
  let fixture: ComponentFixture<AdicionPolizaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionPolizaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionPolizaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
