import { Component,  Injector, OnInit } from '@angular/core';
import { PeticionServiceProxy, PeticionDto, AuthenticateResultModel, PeticionDtoPagedResultDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { CreatePeticionDialogComponent } from 'app/components/peticiones/create-peticiones/create-peticion-dialog.component';


class PagedPeticionRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'app-mostrar-peticiones',
  templateUrl: './mostrar-peticiones.component.html'
})



export class MostrarPeticionesComponent extends PagedListingComponentBase<PeticionDto> {

  peticiones: PeticionDto[] = [];
  
  filterText = '';
  constructor(
      injector: Injector,
      private _peticioneservice: PeticionServiceProxy,
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

  //ngOnInit() {
  //    this._peticioneservice.getAll('', 0, 20)
  //        .subscribe(result =>
  //        this.peticiones = result.items);
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


}
