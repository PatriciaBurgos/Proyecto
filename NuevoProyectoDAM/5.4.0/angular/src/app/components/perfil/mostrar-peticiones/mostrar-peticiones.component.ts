import { Component,  Injector, OnInit } from '@angular/core';
import { PeticionServiceProxy, PeticionDto, AuthenticateResultModel, PeticionDtoPagedResultDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreatePeticionDialogComponent } from 'app/components/peticiones/create-peticiones/create-peticion-dialog.component';
import { ActivatedRoute } from '@angular/router';
import { PeticionesCompletasComponent } from './peticiones-completas/peticiones-completas.component';


class PagedPeticionRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'app-mostrar-peticiones',
  templateUrl: './mostrar-peticiones.component.html'
})



export class MostrarPeticionesComponent extends PagedListingComponentBase<PeticionDto> {

  peticiones: PeticionDto[] = [];
  idUsuario : number;
  comprobacion : boolean = false;
  
  filterText = '';
  constructor(
      injector: Injector,
      private _peticioneservice: PeticionServiceProxy,
      private _dialog: MatDialog,
      private rutaActiva: ActivatedRoute
  ) {
      super(injector);
  }

  list(
      request: PagedPeticionRequestDto,
      pageNumber: number,
      finishedCallback: Function
  ): void {

    this.idUsuario = this.rutaActiva.snapshot.params.id;
    request.filter = this.filterText;

    if(this.idUsuario == null){
        this.comprobacion = true;
      this._peticioneservice
          .getPeticionesUsuarioLogado()
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.peticiones = result.items;
              
          });
    }else{
      this._peticioneservice
          .getPeticionesUnUsuario(this.idUsuario)
          .pipe(
              finalize(() => {
                  finishedCallback();
              })
          )
          .subscribe(result  => {
              this.peticiones = result.items;
              
          });
    }
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
      } 
      
      createOrEditPeticionDialog.afterClosed().subscribe(result => {
          if (result) {
              this.refresh();
          }
      });
  }

  abrirPeticion(idPeticion:number):void{
    this._dialog.open(PeticionesCompletasComponent, {data:idPeticion});
  }

}
