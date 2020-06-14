import { Component,  Injector, OnInit } from '@angular/core';
import { ChatServiceProxy, ChatDto, MostrarChatReducidoDto, AuthenticateResultModel, ChatDtoPagedResultDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreateChatDialogComponent } from 'app/components/chats/create-chats/create-chat-dialog.component';
import { ChatsUsuariosComponent } from '../chats-usuarios/chats-usuarios.component';

class PagedChatRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'app-chats-reducidos',
  templateUrl: './chats-reducidos.component.html'
})


export class ChatsReducidosComponent extends PagedListingComponentBase<MostrarChatReducidoDto> {

  chats: MostrarChatReducidoDto[] = [];
  uLogado : number = 0;

  filterText = '';
  constructor(
      injector: Injector,
      private _chatservice: ChatServiceProxy,
      private _dialog: MatDialog
  ) {
      super(injector);
  }

  list(
      request: PagedChatRequestDto,
      pageNumber: number,
      finishedCallback: Function
  ): void {

    this.uLogado = this.appSession.user.id;

      request.filter = this.filterText;

      this._chatservice
          .getUsuariosConLosQueHabla()
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.chats = result.items;
              
          });
        }
  //ngOnInit() {
 //     this._chatservice.getAll('', 0, 20)
  //        .subscribe(result =>
  //        this.chats = result.items);
 // }

  delete(chat: ChatDto): void {
      abp.message.confirm(
          this.l('ChatDeleteWarningMessage', chat.id),
          undefined,
          (result: boolean) => {
              if (result) {
                  this._chatservice
                      .delete(chat.id)
                      .pipe(
                          finalize(() => {
                              abp.notify.success(this.l('SuccessfullyDeleted'));
                              this.refresh();
                          })
                      )
                      .subscribe(() => { });
              }
          }
      );
  }

  createChat(): void {
      this.showCreateChatDialog();
  }

  

  showCreateChatDialog(id?: number): void {
      let createChatDialog;
      createChatDialog = this._dialog.open(CreateChatDialogComponent);
       
      
      createChatDialog.afterClosed().subscribe(result => {
          if (result) {
              this.refresh();
          }
      });
  }

  

}
