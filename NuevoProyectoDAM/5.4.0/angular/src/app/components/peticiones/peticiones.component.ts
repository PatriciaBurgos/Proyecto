import { Component,  Injector, OnInit } from '@angular/core';
import { PeticionServiceProxy, PeticionDto, AuthenticateResultModel, PeticionDtoPagedResultDto, PublicacionGustadaServiceProxy } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreatePeticionDialogComponent } from './create-peticiones/create-peticion-dialog.component';
import { EditPeticionDialogComponent } from './edit-peticiones/edit-peticion-dialog.component';


class PagedPeticionRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
    selector: 'app-peticion',
    templateUrl: './peticiones.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class PeticionesComponent extends PagedListingComponentBase<PeticionDto> implements OnInit {

    peticiones: PeticionDto[] = [];
    estadoPositivo: boolean = true;
    urge: boolean = false;
       
    uLogado = this.appSession.user.userName;
    

    filterText = '';
    constructor(
        injector: Injector,
        private _peticioneservice: PeticionServiceProxy,
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
        //this.uLogado = this.appSession.user.userName;
        
        console.log("User:" + this.uLogado);

        this._peticioneservice
            .getPublicacionesPeticiones()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result   => {
                this.peticiones = result.items;
                console.log("User:" + this.uLogado);
            });


        }

 

    delete(peticion: PeticionDto): void {
        abp.message.confirm(
            this.l('PeticionDeleteWarningMessage', peticion.id),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._peticioneservice
                        .delete(peticion.id)
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

    createPeticion(): void {
        this.showCreateOrEditPeticionDialog();
    }

    editPeticion(peticion: PeticionDto): void {
        this.showCreateOrEditPeticionDialog(peticion.id);
    }

    showCreateOrEditPeticionDialog(id?: number): void {
        let createOrEditPeticionDialog;
        if (id === undefined || id <= 0) {
            createOrEditPeticionDialog = this._dialog.open(CreatePeticionDialogComponent);
        } else {
            createOrEditPeticionDialog = this._dialog.open(EditPeticionDialogComponent, {
                data: id
            });
        }
        
        createOrEditPeticionDialog.afterClosed().subscribe(result => {
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


    buscarTodas(){
        this.peticiones.splice(0);
        this._peticioneservice
            .getPublicacionesPeticiones()
            .pipe(
                finalize(() => {
                    
                })
            )
            .subscribe(result  => {
                this.peticiones = result.items;
                
            });
    }

    buscarCategoria(categ : string){
        this.peticiones.splice(0);
        console.log("Categ = " + categ);

        this._peticioneservice
        .busquedaPeticionesPorCategoria(categ)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.peticiones = result.items;
            
        });        
    }

    buscarCiudad(ciu : string){
        this.peticiones.splice(0);
        console.log("Ciu = " + ciu);

        this._peticioneservice
        .busquedaPeticionesPorCiudad(ciu)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.peticiones = result.items;
            
        });
        
    }

    buscarMunicipio(muni : string){
        this.peticiones.splice(0);
        console.log("Ciu = " + muni);

        this._peticioneservice
        .busquedaPeticionesPorMunicipio(muni)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.peticiones = result.items;
            
        });
        
    }

    esUrgente(urgent : string){

        if(urgent=="Si"){
            this.urge = true;
        }else{
            this.urge = false;
        }
        console.log("urge = " + this.urge);

        this.peticiones.splice(0);
        console.log("Ciu = " + this.urge);

        this._peticioneservice
        .busquedaPeticionesUrgentes(this.urge)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.peticiones = result.items;
            
        });
        
    }

    buscarUsuario(usu : string){
        this.peticiones.splice(0);
        console.log("usu = " + usu);

        this._peticioneservice
        .busquedaPeticionesPorUsuario(usu)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.peticiones = result.items;
            
        });
        
    }

    buscarHorarioIni(hor : number){
        this.peticiones.splice(0);
        console.log("hor = " + hor);

        this._peticioneservice
        .busquedaPeticionesHorarioInicio(hor)
        .pipe(
            finalize(() => {
                
            })
        )
        .subscribe(result  => {
            this.peticiones = result.items;
            
        });
        
    }

}
