import { Component, Injector, Inject, OnInit, Optional } from '@angular/core';
import {
    MatDialogRef,
    MAT_DIALOG_DATA,
    MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { PeticionServiceProxy, /*GetPeticionForEditOutput,*/ PeticionDto} 
from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-Peticion-dialog.component.html',
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
export class EditPeticionDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    Peticion: PeticionDto = new PeticionDto();
  
    constructor(
        injector: Injector,
        private _PeticionService: PeticionServiceProxy,
        private _dialogRef: MatDialogRef<EditPeticionDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
        this.Peticion.id = _id;
    }

    ngOnInit(): void {
        /*this._PeticionService 
            .getPeticionForEdit(this._id)
            .subscribe(result => {
                this.Peticion.nombre = result.name;
                //this.equipo.
            });*/
                
                //this.grantedPermissionNames = result.grantedPermissionNames;
                //this.setInitialPermissionsStatus();
            
    }

    
    
     save(): void {
        this.saving = true;
        this._PeticionService
            .update(this.Peticion)
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
