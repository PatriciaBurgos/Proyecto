import { Component, OnInit, Injector, ViewChild, Directive } from '@angular/core';
import { UserServiceProxy, UsuarioLogadoServiceProxy, UserDto, UserDtoPagedResultDto } from '@shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AnuncioServiceProxy, AnuncioDto } from '@shared/service-proxies/service-proxies';
import { AnunciosComponent } from '@app/components/anuncios/anuncios.component';

class PagedUsersRequestDto extends PagedRequestDto {
  filter: string;
}



@Component({
//selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  animations: [appModuleAnimation()],
  styles: [
      `
        mat-form-field {
          padding: 10px;
        }
      `
  ]
})


export class PerfilComponent extends PagedListingComponentBase<UserDto> {

  user: UserDto;
  
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
          .getUsuarioLogado()
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.user = result;
              
          });

  //ngOnInit() {
  //    this._anuncioservice.getAll('', 0, 20)
  //        .subscribe(result =>
  //        this.anuncios = result.items);
  }

  delete(user: UserDto): void {
      abp.message.confirm(
          this.l('UserDeleteWarningMessage', user.id),
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
                      .subscribe(() => { });*/
              }
          }
      );
  }


  createAnun () : void {
      this._dialog.open(CreateAnuncioDialogComponent);

  }

}