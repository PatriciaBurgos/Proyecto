

import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { UsuarioLogadoServiceProxy, PeticionDto, PeticionServiceProxy, PublicacionGustadaServiceProxy } from '@shared/service-proxies/service-proxies';
import { UsuariosSeguidoresDto } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';


class PagedPeticionRequestDto extends PagedRequestDto {
  filter: string;
}


@Component({
  selector: 'app-peticiones-completas',
  templateUrl: './peticiones-completas.component.html',
  styleUrls: ['./peticiones-completas.component.css']
})


export class PeticionesCompletasComponent extends PagedListingComponentBase<PeticionDto> {
  

  filterText = '';
  peticion: PeticionDto;


  constructor(
    injector: Injector,
    private _peticionesservice: PeticionServiceProxy,
    private _pubGustadaservice: PublicacionGustadaServiceProxy,
    private _dialog: MatDialog,
    @Optional() @Inject(MAT_DIALOG_DATA) private _idPeti: number,
    
  ) {
    super(injector);
  }

  list(
    request: PagedPeticionRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    
    request.filter = this.filterText;

    
      this._peticionesservice 
          .getUnaPeticion(this._idPeti)
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.peticion = result;
              
          });
    }

  

  delete(peticion: PeticionDto): void {
      /*abp.message.confirm(
          this.l('UserDeleteWarningMessage', user.Id),
          undefined,
          (result: boolean) => {
              if (result) {
                  /*this._userservice
                      .delete(user.id)
                      .pipe(
                          finalize(() => {
                              abp.notify.success(this.l('SuccessfullyDeleted'));
                              this.refresh();
                          })
                      )
                      .subscribe(() => { });
              }
          }
      );*/
  }

  gustaPublicacion(idPub : number){
    console.log("PUB = " + idPub);

    this._pubGustadaservice
        .usuarioLogadoGustaPublicacion(idPub)
        .pipe(
            finalize(() => {})
        )
        .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
            console.log("PublicacionGustada");
            this.refresh();
            
        });
    this.refresh();
}

noGustaPublicacion(idPub : number){
    console.log("PUB = " + idPub);

    this._pubGustadaservice
        .usuarioLogadoNOGustaPublicacion(idPub)
        .pipe(
            finalize(() => {})
        )
        .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
            console.log("PublicacionGustada");
            this.refresh();
            
        });
    this.refresh();
}

  
}