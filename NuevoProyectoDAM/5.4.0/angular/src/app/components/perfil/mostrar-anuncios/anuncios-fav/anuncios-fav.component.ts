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
  selector: 'app-anuncios-fav',
  templateUrl: './anuncios-fav.component.html',
  styleUrls: ['./anuncios-fav.component.css']
})




export class AnunciosFavComponent extends PagedListingComponentBase<AnuncioDto> {
  

  filterText = '';
  anuncios: AnuncioDto[]=[];


  constructor(
    injector: Injector,
    private _anuncioservice: AnuncioServiceProxy,
    private _pubGustadaservice: PublicacionGustadaServiceProxy,
    private _dialog: MatDialog
    
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
          .getPublicacionesAnuncios()
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.anuncios = result.items;
              
          });
    }

  

  delete(anuncios: AnuncioDto): void {
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