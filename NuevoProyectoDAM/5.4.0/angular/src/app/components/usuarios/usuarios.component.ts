import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { UserDto, UserDtoPagedResultDto, UsuarioLogadoServiceProxy, UserServiceProxy } from '@shared/service-proxies/service-proxies';


class PagedUsersRequestDto extends PagedRequestDto {
    keyword: string;
    isActive: boolean | null;
}

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html'
})


export class UsuariosComponent extends PagedListingComponentBase<UserDto> {
  users: UserDto[] = [];
  keyword = '';
  isActive: boolean | null;

  constructor(
      injector: Injector,
      private _userService: UserServiceProxy,
      private _dialog: MatDialog
  ) {
      super(injector);
  }


  protected list(
      request: PagedUsersRequestDto,
      pageNumber: number,
      finishedCallback: Function
  ): void {

      request.keyword = this.keyword;
      request.isActive = this.isActive;

      this._userService
          .getAll(request.keyword, request.isActive, request.skipCount, request.maxResultCount)
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe((result: UserDtoPagedResultDto) => {
              this.users = result.items;
              this.showPaging(result, pageNumber);
          });
  }

  protected delete(user: UserDto): void {
      /*abp.message.confirm(
          this.l('UserDeleteWarningMessage', user.fullName),
          undefined,
          (result: boolean) => {
              if (result) {
                  this._userService.delete(user.id).subscribe(() => {
                      abp.notify.success(this.l('SuccessfullyDeleted'));
                      this.refresh();
                  });
              }
          }
      );*/
  }

  
}
