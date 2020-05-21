import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {PeticionServiceProxy, PeticionCreateDto} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'create-peticion-dialog.component.html',
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
export class CreatePeticionDialogComponent extends AppComponentBase  {
    saving = false;
    peticion: PeticionCreateDto = new PeticionCreateDto();


    constructor(
        injector: Injector,
        private _PeticionService: PeticionServiceProxy,
        private _dialogRef: MatDialogRef<CreatePeticionDialogComponent>
    ) {
        super(injector);
    }

  
    
    save(): void {
        this.saving = true;
        const Peticion_ = new PeticionCreateDto();
        Peticion_.init(this.peticion);
        console.log(Peticion_);
        
        this._PeticionService 
            .create(Peticion_)
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
