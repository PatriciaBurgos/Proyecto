import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {AnuncioServiceProxy, AnuncioCreateDto} from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase } from '@shared/paged-listing-component-base';


@Component({
    templateUrl: 'create-anuncio-dialog.component.html',
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
export class CreateAnuncioDialogComponent extends PagedListingComponentBase<AnuncioCreateDto> {
    
    saving = false;
    anuncio: AnuncioCreateDto = new AnuncioCreateDto();
    categoria : string = "";

    constructor(
        injector: Injector,
        private _AnuncioService: AnuncioServiceProxy,
        private _dialogRef: MatDialogRef<CreateAnuncioDialogComponent>
    ) {
        super(injector);
    }

  
    list ():void{}
    delete ():void{}   
        
        

    save(): void {
        this.saving = true;
        const Anuncio_ = new AnuncioCreateDto();
        Anuncio_.init(this.anuncio);
        console.log(Anuncio_);
        
        Anuncio_.publicacionCategoria = this.categoria;
        
        this._AnuncioService 
            .create(Anuncio_)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));    
                this.refresh();            
                this.close(true);
                
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
