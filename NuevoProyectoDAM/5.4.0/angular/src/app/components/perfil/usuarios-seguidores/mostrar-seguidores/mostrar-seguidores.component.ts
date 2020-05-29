import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { UsuarioLogadoServiceProxy } from '@shared/service-proxies/service-proxies';
import { UsuariosSeguidoresDto } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

class PagedUsersRequestDto extends PagedRequestDto {
  filter: string;
}

@Component({

  selector: 'app-mostrar-usuarios-seguidores',

  templateUrl: './mostrar-seguidores.component.html'

})

export class MostrarSeguidoresComponent extends PagedListingComponentBase<UsuariosSeguidoresDto> {

  filterText = '';
  user: UsuariosSeguidoresDto;
  idUsuario : number;


  constructor(
    injector: Injector,
    private _userservice: UsuarioLogadoServiceProxy,
    private _dialog: MatDialog,
    @Optional() @Inject(MAT_DIALOG_DATA) private _user: UsuariosSeguidoresDto,
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

delete(user: UsuariosSeguidoresDto): void {
    /*abp.message.confirm(
        this.l('UserDeleteWarningMessage', user.Id),
        undefined,
        (result: boolean) => {
            if (result) {
                /*this._userservice
                    .delete(user.id)
                    .pipe(
                        finalize(() => {
                            abp.notify.success(this.l('SuccessfullyDeleted'));
                            this.refresh();
                        })
                    )
                    .subscribe(() => { });
            }
        }
    );*/
  }

  mostrarSeguidores(user : UsuariosSeguidoresDto){
    this._dialog.open(MostrarSeguidoresComponent);
  }

}