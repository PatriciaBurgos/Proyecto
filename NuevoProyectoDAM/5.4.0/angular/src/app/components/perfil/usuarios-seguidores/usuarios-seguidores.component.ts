import { Component, OnInit, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { UsuarioLogadoServiceProxy } from '@shared/service-proxies/service-proxies';
import { UsuariosSeguidoresDto } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { MostrarSeguidoresComponent } from './mostrar-seguidores/mostrar-seguidores.component';
import { ActivatedRoute } from '@angular/router';

class PagedUsersRequestDto extends PagedRequestDto {
  filter: string;
}

@Component({
  selector: 'app-usuarios-seguidores',
  templateUrl: './usuarios-seguidores.component.html'
})

export class UsuariosSeguidoresComponent extends PagedListingComponentBase<UsuariosSeguidoresDto> {

  user: UsuariosSeguidoresDto;
  filterText = '';
  idUsuario : number;

  constructor(
    injector: Injector,
    private _userservice: UsuarioLogadoServiceProxy,
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
      this._userservice 
          .getMisSeguidores()
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.user = result;
              
          });
    } else{
      this._userservice 
          .getSeguidoresUsuario(this.idUsuario)
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.user = result;
              
          });
    }

  }

delete(user: UsuariosSeguidoresDto): void { }

  mostrarSeguidores(user : UsuariosSeguidoresDto){
    this._dialog.open(MostrarSeguidoresComponent, {data: this.idUsuario});
  }

}
