import { Component,  Injector, OnInit, Optional, Inject } from '@angular/core';
import { ChatServiceProxy, ChatDto, AuthenticateResultModel, ChatDtoPagedResultDto, UsuariosSeguidosDto, ChatCreateDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { CreateChatDialogComponent } from 'app/components/chats/create-chats/create-chat-dialog.component';
import { ActivatedRoute, Params } from '@angular/router';


class PagedChatRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'app-chats-usuarios',
  templateUrl: './chats-usuarios.component.html'

})


export class ChatsUsuariosComponent extends PagedListingComponentBase<ChatDto> {

  chats: ChatDto[] = [];
  chatUDest : string = "";
  chatUOrig : string = ""; 
  idChat : number;
  text : string = "";

  filterText = '';
  constructor(
      injector: Injector,
      private _chatservice: ChatServiceProxy,
      private _dialog: MatDialog,
      private rutaActiva: ActivatedRoute

  ) {
      super(injector);
  }

  list(
      request: PagedChatRequestDto,
      pageNumber: number,
      finishedCallback: Function
  ): void {

      this.idChat = this.rutaActiva.snapshot.params.id;
      request.filter = this.filterText;

      this._chatservice
          .getChatCompletoDosUsuarios(this.idChat)
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.chats = result.items;
              if (this.chats[this.chats.length-1].usuarioOrigen == this.appSession.user.userName){
                this.chatUOrig = this.chats[this.chats.length-1].usuarioOrigen;
                this.chatUDest = this.chats[this.chats.length-1].usuarioDestino;
              }else{
                this.chatUOrig = this.chats[this.chats.length-1].usuarioDestino;
                this.chatUDest = this.chats[this.chats.length-1].usuarioOrigen;
              }

              console.log("UORIG = "+ this.chatUOrig);
              console.log("UDEST = "+ this.chatUDest);
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
     // this.showCreateChatDialog();
     console.log(this.appSession.user.userName);
     const Chat_ = new ChatCreateDto();
     //Chat_.userName = this.

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