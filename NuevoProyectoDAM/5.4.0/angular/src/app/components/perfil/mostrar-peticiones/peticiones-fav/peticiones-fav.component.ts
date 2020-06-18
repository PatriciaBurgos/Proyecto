import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { UsuarioLogadoServiceProxy, PublicacionGustadaServiceProxy, PeticionDto, PeticionServiceProxy } from '@shared/service-proxies/service-proxies';
import { UsuariosSeguidoresDto } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

class PagedPeticionRequestDto extends PagedRequestDto {
  filter: string;
}

@Component({
  selector: 'app-peticiones-fav',
  templateUrl: './peticiones-fav.component.html',
  styleUrls: ['./peticiones-fav.component.css']
})


export class PeticionesFavComponent extends PagedListingComponentBase<PeticionDto> {
  
  filterText = '';
  peticiones: PeticionDto[]=[];


  constructor(
    injector: Injector,
    private _peticionservice: PeticionServiceProxy,
    private _pubGustadaservice: PublicacionGustadaServiceProxy,
    private _dialog: MatDialog
    
  ) {
    super(injector);
  }

  list(
    request: PagedPeticionRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    
    request.filter = this.filterText;

    
      this._peticionservice 
          .getPublicacionesPeticiones()
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.peticiones = result.items;
              
          });
    }

  

  delete(anuncios: PeticionDto): void { }

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