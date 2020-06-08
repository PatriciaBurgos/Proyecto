import { Component,  Injector, OnInit } from '@angular/core';
import { AnuncioServiceProxy, AnuncioDto, AuthenticateResultModel, AnuncioDtoPagedResultDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreateAnuncioDialogComponent } from 'app/components/anuncios/create-anuncios/create-anuncio-dialog.component'
import { ActivatedRoute } from '@angular/router';
import { AnunciosCompletosComponent } from './anuncios-completos/anuncios-completos.component';

class PagedAnuncioRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'app-mostrar-anuncios',
  templateUrl: './mostrar-anuncios.component.html'
})


export class MostrarAnunciosComponent extends PagedListingComponentBase<AnuncioDto> {

  anuncios: AnuncioDto[] = [];
  idUsuario : number;
  comprobacion : boolean = false;
  
  filterText = '';
  constructor(
      injector: Injector,
      private _anuncioservice: AnuncioServiceProxy,
      private _dialog: MatDialog,
      private rutaActiva: ActivatedRoute
  ) {
      super(injector);
  }

  list(
      request: PagedAnuncioRequestDto,
      pageNumber: number,
      finishedCallback: Function
  ): void {
      
      this.idUsuario = this.rutaActiva.snapshot.params.id;
      request.filter = this.filterText;

      if(this.idUsuario == null){
          this.comprobacion = true;
        this._anuncioservice
            .getAnunciosUsuarioLogado()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.anuncios = result.items;
                
            });
      }else{
        this._anuncioservice
            .getAnunciosUnUsuario(this.idUsuario)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.anuncios = result.items;
                
            });
      }

  //ngOnInit() {
  //    this._anuncioservice.getAll('', 0, 20)
  //        .subscribe(result =>
  //        this.anuncios = result.items);
  }

  delete(anuncio: AnuncioDto): void {
      abp.message.confirm(
          this.l('AnuncioDeleteWarningMessage', anuncio.id),
          undefined,
          (result: boolean) => {
              if (result) {
                  this._anuncioservice
                      .delete(anuncio.id)
                      .pipe(
                          finalize(() => {
                              abp.notify.success(this.l('SuccessfullyDeleted'));
                              this.refresh();
                          })
                      )
                      .subscribe(() => { });
              }
          }
      );
  }

  createAnuncio(): void {
      this.showCreateOrEditAnuncioDialog();
  }

  /*editAnuncio(anuncio: AnuncioDto): void {
      this.showCreateOrEditAnuncioDialog(anuncio.id);
  }*/

  showCreateOrEditAnuncioDialog(id?: number): void {
      let createOrEditAnuncioDialog;
      if (id === undefined || id <= 0) {
          createOrEditAnuncioDialog = this._dialog.open(CreateAnuncioDialogComponent);
      } /*else {
        //  createOrEditAnuncioDialog = this._dialog.open(EditAnuncioDialogComponent, {
        //      data: id
          });
      }*/
      
      createOrEditAnuncioDialog.afterClosed().subscribe(result => {
          if (result) {
              this.refresh();
          }
      });
  }

  abrirAnuncio(idAnuncio:number):void{
    this._dialog.open(AnunciosCompletosComponent, {data:idAnuncio});
  }


}

