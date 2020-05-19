import { Component, Injector, Inject, OnInit, Optional } from '@angular/core';
import {
    MatDialogRef,
    MAT_DIALOG_DATA,
    MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { AnuncioServiceProxy, /*GetAnuncioForEditOutput,*/ AnuncioDto} 
from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-Anuncio-dialog.component.html',
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
export class EditAnuncioDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    Anuncio: AnuncioDto = new AnuncioDto();
  
    constructor(
        injector: Injector,
        private _AnuncioService: AnuncioServiceProxy,
        private _dialogRef: MatDialogRef<EditAnuncioDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
        this.Anuncio.id = _id;
    }

    ngOnInit(): void {
        /*this._AnuncioService 
            .getAnuncioForEdit(this._id)
            .subscribe(result => {
                this.Anuncio.nombre = result.name;
                //this.equipo.
            });*/
                
                //this.grantedPermissionNames = result.grantedPermissionNames;
                //this.setInitialPermissionsStatus();
            
    }

    
    
     save(): void {
        this.saving = true;
        this._AnuncioService
            .update(this.Anuncio)
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
