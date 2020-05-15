import { Component, Injector, Inject, OnInit, Optional } from '@angular/core';
import {
    MatDialogRef,
    MAT_DIALOG_DATA,
    MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { AplicacionServiceProxy, /*GetAplicacionForEditOutput,*/ AplicacionDto} 
from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-aplicacion-dialog.component.html',
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
export class EditAplicacionDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    aplicacion: AplicacionDto = new AplicacionDto();
  
    constructor(
        injector: Injector,
        private _aplicacionService: AplicacionServiceProxy,
        private _dialogRef: MatDialogRef<EditAplicacionDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
        this.aplicacion.id = _id;
    }

    ngOnInit(): void {
        /*this._aplicacionService 
            .getAplicacionForEdit(this._id)
            .subscribe(result => {
                this.aplicacion.nombre = result.name;
                //this.equipo.
            });*/
                
                //this.grantedPermissionNames = result.grantedPermissionNames;
                //this.setInitialPermissionsStatus();
            
    }

    
    
     save(): void {
        this.saving = true;
        this._aplicacionService
            .update(this.aplicacion)
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
