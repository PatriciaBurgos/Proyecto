import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuariosSeguidosComponent } from './usuarios-seguidos.component';

describe('UsuariosSeguidosComponent', () => {
  let component: UsuariosSeguidosComponent;
  let fixture: ComponentFixture<UsuariosSeguidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuariosSeguidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuariosSeguidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
