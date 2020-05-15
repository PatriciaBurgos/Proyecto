import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {AplicacionServiceProxy, AplicacionDto, 
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'create-aplicacion-dialog.component.html',
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
export class CreateAplicacionDialogComponent extends AppComponentBase  {
    saving = false;
    aplicacion: AplicacionDto = new AplicacionDto();
      

    constructor(
        injector: Injector,
        private _aplicacionService: AplicacionServiceProxy,
        private _dialogRef: MatDialogRef<CreateAplicacionDialogComponent>
    ) {
        super(injector);
    }

  
    
    save(): void {
        this.saving = true;
        const aplicacion_ = new AplicacionDto();
        aplicacion_.init(this.aplicacion);
        console.log(aplicacion_);

        this._aplicacionService 
            .create(aplicacion_)
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
