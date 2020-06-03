import { Component,  Injector, OnInit, Optional, Inject} from '@angular/core';
import { ChatServiceProxy, ChatDto, AuthenticateResultModel, ChatDtoPagedResultDto, UsuariosSeguidosDto, ChatCreateDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { CreateChatDialogComponent } from 'app/components/chats/create-chats/create-chat-dialog.component';
import { ActivatedRoute, Params } from '@angular/router';
import {ScrollingModule} from '@angular/cdk/scrolling';


class PagedChatRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'app-chats-usuarios',
  templateUrl: './chats-usuarios.component.html',
  styleUrls: ['./chats-usuarios.components.css']
})


export class ChatsUsuariosComponent extends PagedListingComponentBase<ChatDto> {

  chats: ChatDto[] = [];
  chatUDest : string = "";
  chatUOrig : string = ""; 
  uLogado : string = "";
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

              this.uLogado = this.appSession.user.userName;

              if (this.chats[this.chats.length-1].usuarioOrigen == this.uLogado){
                this.chatUOrig = this.chats[this.chats.length-1].usuarioOrigen;
                this.chatUDest = this.chats[this.chats.length-1].usuarioDestino;
              }else{
                this.chatUOrig = this.chats[this.chats.length-1].usuarioDestino;
                this.chatUDest = this.chats[this.chats.length-1].usuarioOrigen;
              }

              console.log("UORIG = "+ this.chatUOrig);
              console.log("UDEST = "+ this.chatUDest);
          });

          
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
     if(this.text!=""){
        console.log(this.appSession.user.userName);
        const Chat_ = new ChatCreateDto();
        Chat_.userName = this.chatUDest;
        Chat_.texto = this.text;

        this._chatservice 
                .create(Chat_)
                .pipe(
                    finalize(() => {
                        //this.saving = false;
                    })
                )
                .subscribe(() => {
                    this.notify.info(this.l('SavedSuccessfully'));
                    //this.close(true);
                    this.refresh();
                    this.text= "";
                });
    }
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