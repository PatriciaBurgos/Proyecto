import { Component, OnInit, Injector, Optional, Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { UsuarioLogadoServiceProxy, AnuncioDto, AnuncioServiceProxy } from '@shared/service-proxies/service-proxies';
import { UsuariosSeguidoresDto } from '@shared/service-proxies/service-proxies';
import { PagedRequestDto, PagedListingComponentBase } from '@shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-anuncios-fav',
  templateUrl: './anuncios-fav.component.html',
  styleUrls: ['./anuncios-fav.component.css']
})

class PagedAnuncioRequestDto extends PagedRequestDto {
  filter: string;
}


export class AnunciosFavComponent extends PagedListingComponentBase<AnuncioDto> {
  

  filterText = '';
  anuncio: AnuncioDto;


  constructor(
    injector: Injector,
    private _anuncioservice: AnuncioServiceProxy,
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

  
}