import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { ChatServiceProxy, ChatCreateDto } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'create-chat-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class CreateChatDialogComponent extends AppComponentBase  {
    saving = false;
    chat: ChatCreateDto = new ChatCreateDto();


    constructor(
        injector: Injector,
        private _ChatService: ChatServiceProxy,
        private _dialogRef: MatDialogRef<CreateChatDialogComponent>
    ) {
        super(injector);
    }

  
    
    save(): void {
        this.saving = true;
        const Chat_ = new ChatCreateDto();
        Chat_.init(this.chat);
        console.log(Chat_);
        
        this._ChatService 
            .create(Chat_)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close(true);
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
