import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IptuComponent } from './iptu.component';

describe('ListaComponent', () => {
  let component: IptuComponent;
  let fixture: ComponentFixture<IptuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IptuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IptuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
