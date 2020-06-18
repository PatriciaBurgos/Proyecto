import { Component,  Injector, OnInit } from '@angular/core';
import { AnuncioServiceProxy, AnuncioDto, AuthenticateResultModel, AnuncioDtoPagedResultDto, PublicacionGustadaServiceProxy } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreateAnuncioDialogComponent } from './create-anuncios/create-anuncio-dialog.component';

class PagedAnuncioRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    selector: 'app-anuncio',
    templateUrl: './anuncios.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
    ,
    styleUrls: ['./anuncios.component.css']
})


export class AnunciosComponent extends PagedListingComponentBase<AnuncioDto> {

    anuncios: AnuncioDto[] = [];
    
    filterText = '';
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

    editAnuncio(anuncio: AnuncioDto): void {
        this.showCreateOrEditAnuncioDialog(anuncio.id);
    }

    showCreateOrEditAnuncioDialog(id?: number): void {
        let createOrEditAnuncioDialog;
        if (id === undefined || id <= 0) {
            createOrEditAnuncioDialog = this._dialog.open(CreateAnuncioDialogComponent);
        } 
        
        createOrEditAnuncioDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
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
        //this.refresh();
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

    buscarTodas(){
        this.anuncios.splice(0);
        this._anuncioservice
            .getPublicacionesAnuncios()
            .pipe(
                finalize(() => {
                    
                })
            )
            .subscribe(result  => {
                this.anuncios = result.items;
                
            });
    }

    buscarCategoria(categ : string){
        this.anuncios.splice(0);
        console.log("Categ = " + categ);

        this._anuncioservice
        .busquedaAnunciosPorCategoria(categ)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.anuncios = result.items;
            
        });        
    }

    buscarCiudad(ciu : string){
        this.anuncios.splice(0);
        console.log("Ciu = " + ciu);

        this._anuncioservice
        .busquedaAnunciosPorCiudad(ciu)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.anuncios = result.items;
            
        });
        
    }

    buscarMunicipio(muni : string){
        this.anuncios.splice(0);
        console.log("Ciu = " + muni);

        this._anuncioservice
        .busquedaAnunciosPorMunicipio(muni)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.anuncios = result.items;
            
        });
        
    }

    buscarUsuario(name : string){
        this.anuncios.splice(0);
        console.log("name = " + name);

        this._anuncioservice
        .busquedaAnunciosPorUsuario(name)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.anuncios = result.items;
            
        });
        
    }

    buscarHorarioIni(hor : number){
        this.anuncios.splice(0);
        console.log("hora = " + hor);

        this._anuncioservice
        .busquedaAnunciosPorHorarioInicio(hor)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.anuncios = result.items;
            
        });
        
    }

}
