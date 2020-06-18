import { Component,  Injector, OnInit } from '@angular/core';
import { ChatServiceProxy, ChatDto, MostrarChatReducidoDto, AuthenticateResultModel, ChatDtoPagedResultDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreateChatDialogComponent } from './create-chats/create-chat-dialog.component';

class PagedChatRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-chat',
    templateUrl: './chats.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class ChatsComponent extends PagedListingComponentBase<MostrarChatReducidoDto> {

    chats: MostrarChatReducidoDto[] = [];
    
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
