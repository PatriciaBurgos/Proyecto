import { Component, OnInit, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { UsuarioLogadoServiceProxy } from '@shared/service-proxies/service-proxies';
import { UsuariosSeguidoresDto } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { MostrarSeguidoresComponent } from './mostrar-seguidores/mostrar-seguidores.component';

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

  constructor(
    injector: Injector,
    private _userservice: UsuarioLogadoServiceProxy,
    private _dialog: MatDialog
  ) {
    super(injector);
  }

  list(
    request: PagedUsersRequestDto,
    pageNumber: number,
    finishedCallback: Function
): void {

    request.filter = this.filterText;

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
