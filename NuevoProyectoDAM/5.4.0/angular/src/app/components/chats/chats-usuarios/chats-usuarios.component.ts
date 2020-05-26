import { Component,  Injector, OnInit, Optional, Inject } from '@angular/core';
import { ChatServiceProxy, ChatDto, AuthenticateResultModel, ChatDtoPagedResultDto, UsuariosSeguidosDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { CreateChatDialogComponent } from 'app/components/chats/create-chats/create-chat-dialog.component';

class PagedChatRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'app-chats-usuarios',
  templateUrl: './chats-usuarios.component.html'

})


export class ChatsUsuariosComponent extends PagedListingComponentBase<ChatDto> {

  chats: ChatDto[] = [];

  filterText = '';
  constructor(
      injector: Injector,
      private _chatservice: ChatServiceProxy,
      private _dialog: MatDialog,
      @Optional() @Inject(MAT_DIALOG_DATA) private _userDestino: string

  ) {
      super(injector);
  }

  list(
      request: PagedChatRequestDto,
      pageNumber: number,
      finishedCallback: Function
  ): void {

      request.filter = this.filterText;

      this._chatservice
          .getChatDosUsuarios(this._userDestino)
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.chats = result.items;
              
          });

  //ngOnInit() {
  //    this._anuncioservice.getAll('', 0, 20)
  //        .subscribe(result =>
  //        this.anuncios = result.items);
  }

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