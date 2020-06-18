import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { UsuarioLogadoServiceProxy, AnuncioDto, AnuncioServiceProxy, PublicacionGustadaServiceProxy } from '@shared/service-proxies/service-proxies';
import { UsuariosSeguidoresDto } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';


class PagedAnuncioRequestDto extends PagedRequestDto {
  filter: string;
}


@Component({
  selector: 'app-anuncios-completos',
  templateUrl: './anuncios-completos.component.html',
  styleUrls: ['./anuncios-completos.component.css']
})


export class AnunciosCompletosComponent extends PagedListingComponentBase<AnuncioDto> {
  

  filterText = '';
  anuncio: AnuncioDto;


  constructor(
    injector: Injector,
    private _anuncioservice: AnuncioServiceProxy,
    private _pubGustadaservice: PublicacionGustadaServiceProxy,
    private _dialog: MatDialog,
    @Optional() @Inject(MAT_DIALOG_DATA) private _idAnun: number,
    
  ) {
    super(injector);
  }

  list(
    request: PagedAnuncioRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    
    request.filter = this.filterText;

    
      this._anuncioservice 
          .getUnAnuncio(this._idAnun)
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.anuncio = result;
              
          });
    }

  

  delete(anuncios: AnuncioDto): void { }

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