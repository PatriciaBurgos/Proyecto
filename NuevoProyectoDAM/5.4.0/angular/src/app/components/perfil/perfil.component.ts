import { Component, OnInit, Injector, ViewChild, Directive } from '@angular/core';
import { UserServiceProxy, UsuarioLogadoServiceProxy, UserDto, UserDtoPagedResultDto, UsuarioGustadoServiceProxy } from '@shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AnuncioServiceProxy, AnuncioDto } from '@shared/service-proxies/service-proxies';
import { CreateAnuncioDialogComponent } from '@app/components/anuncios/create-anuncios/create-anuncio-dialog.component';
import { ActivatedRoute } from '@angular/router';
import { CreatePeticionDialogComponent } from '../peticiones/create-peticiones/create-peticion-dialog.component';
import { AnunciosFavComponent } from './mostrar-anuncios/anuncios-fav/anuncios-fav.component';
import { PeticionesFavComponent } from './mostrar-peticiones/peticiones-fav/peticiones-fav.component';

class PagedUsersRequestDto extends PagedRequestDto {
  filter: string;
}



@Component({
//selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./perfil.component.css'],
  /*styles: [
      `
        mat-form-field {
          padding: 10px;
        }
      `
  ]*/
})


export class PerfilComponent extends PagedListingComponentBase<UserDto> {
  user: UserDto;
  idUsuario : number;
  comprobacion : boolean = false;
  siSigue : boolean = false;
  
  
  filterText = '';
  constructor(
      injector: Injector,
      private _userservice: UsuarioLogadoServiceProxy,
      private _usuarioGustadoService: UsuarioGustadoServiceProxy,
      private _dialog: MatDialog,
      private rutaActiva: ActivatedRoute
  ) {
      super(injector);
  }

  list(
      request: PagedUsersRequestDto,
      pageNumber: number,
      finishedCallback: Function
  ): void {
      this.idUsuario = this.rutaActiva.snapshot.params.id;
      request.filter = this.filterText;
      
        if(this.idUsuario == null){
            this.comprobacion = true;
            this._userservice 
                .getUsuarioLogado()
                .pipe(
                    finalize(() => {
                        finishedCallback();
                    })
                )
                .subscribe(result  => {
                    this.user = result;
                    
                });
        }else{
            this._userservice 
                .getUsuarioAplicacion(this.idUsuario)
                .pipe(
                    finalize(() => {
                        finishedCallback();
                    })
                )
                .subscribe(result  => {
                    this.user = result;
                    
                });

                this._userservice
                    .saberSiUsuarioActualEsSeguidor(this.idUsuario)
                    .subscribe(result  => {
                        this.siSigue = result;
                        console.log("Si segue = " + this.siSigue);
                        
                    });
        }
  }

  delete(user: UserDto): void {
      abp.message.confirm(
          this.l('UserDeleteWarningMessage', user.id),
          undefined,
          (result: boolean) => {
              if (result) {
              }
          }
      );
  }


    createAnun () : void {
        this._dialog.open(CreateAnuncioDialogComponent);
        this.refresh();

    }

    createPeti () : void {
        this._dialog.open(CreatePeticionDialogComponent);
        this.refresh();
    }

    abrirAnunFav () : void{
        this._dialog.open(AnunciosFavComponent);
    }

    abrirPetiFav () : void{
        this._dialog.open(PeticionesFavComponent);
    }

    seguirUser(){

        this.idUsuario = this.rutaActiva.snapshot.params.id;
        console.log("Id user = " + this.idUsuario);
    
        this._usuarioGustadoService
              .usuarioLogadoGustaUsuario(this.idUsuario)
              .subscribe(result  => {
                this.refresh();
                this.pageRefresh();
              });
      }
    
      dejarDeSeguirUser(){
    
        this.idUsuario = this.rutaActiva.snapshot.params.id;
        console.log("Id user = " + this.idUsuario);
    
        this._usuarioGustadoService
              .usuarioLogadoNOGustaUsuario(this.idUsuario)
              .subscribe(result  => {
                this.refresh();  
                this.pageRefresh();        
              });
      }

      pageRefresh() {
        location.reload();
     }
}