import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { UsuarioLogadoServiceProxy, UsuarioGustadoServiceProxy } from '@shared/service-proxies/service-proxies';
import { UsuariosSeguidosDto } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

class PagedUsersRequestDto extends PagedRequestDto {
  filter: string;
}

@Component({
  selector: 'app-seguir-usuario',
  templateUrl: './seguir-usuario.component.html',
  styleUrls: ['./seguir-usuario.component.css']
})


export class SeguirUsuarioComponent implements OnInit {

  
  filterText = '';
  idUsuario : number;

  siSigue : boolean = false;

  constructor(
    injector: Injector,
    private _userservice: UsuarioLogadoServiceProxy,
    private _usuarioGustadoService: UsuarioGustadoServiceProxy,
    private _dialog: MatDialog,
    private rutaActiva: ActivatedRoute
  ) {
    
  }

  ngOnInit(){

    this.idUsuario = this.rutaActiva.snapshot.params.id;
    console.log("Id user = " + this.idUsuario);

    this._userservice
          .saberSiUsuarioActualEsSeguidor(this.idUsuario)
          .subscribe(result  => {
              this.siSigue = result;
              console.log("Si segue = " + this.siSigue);
              
          });
  }
  
  seguirUser(){

    this.idUsuario = this.rutaActiva.snapshot.params.id;
    console.log("Id user = " + this.idUsuario);

    this._usuarioGustadoService
          .usuarioLogadoGustaUsuario(this.idUsuario)
          .subscribe(result  => {
            this.ngOnInit();
          });
  }

  dejarDeSeguirUser(){

    this.idUsuario = this.rutaActiva.snapshot.params.id;
    console.log("Id user = " + this.idUsuario);

    this._usuarioGustadoService
          .usuarioLogadoNOGustaUsuario(this.idUsuario)
          .subscribe(result  => {
            this.ngOnInit();             
          });
  }
  
}