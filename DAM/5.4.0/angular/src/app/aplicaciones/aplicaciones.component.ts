import { Component,  Injector } from '@angular/core';
import {AplicacionServiceProxy, AplicacionDto, AuthenticateResultModel, AplicacionDtoPagedResultDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
//import { CreateaplicacionDialogComponent } from './create-aplicacion/create-aplicacion-dialog.component';
//import { EditaplicacionDialogComponent } from './edit-aplicacion/edit-aplicacion-dialog.component';

class PagedRolesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-aplicaciones',
    templateUrl: './aplicaciones.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class AplicacionesComponent extends PagedListingComponentBase<AplicacionDto> {

    aplicaciones: AplicacionDto[] = [];
    filterText = '';
    constructor(
        injector: Injector,
        private _aplicacioneservice: AplicacionServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    list(
        request: PagedRolesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.filter = this.filterText;

        this._aplicacioneservice
            .getNombreAplicacion()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.aplicaciones = result.items;
            });

    //ngOnInit() {
    //    this._aplicacioneservice.getAll('', 0, 20)
    //        .subscribe(result =>
    //        this.aplicaciones = result.items);
    }

    delete(aplicacion: AplicacionDto): void {
        abp.message.confirm(
            this.l('RoleDeleteWarningMessage', aplicacion.nombre),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._aplicacioneservice
                        .delete(aplicacion.id)
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

    createaplicacion(): void {
        this.showCreateOrEditaplicacionDialog();
    }

    editaplicacion(aplicacion: AplicacionDto): void {
        this.showCreateOrEditaplicacionDialog(aplicacion.id);
    }

    showCreateOrEditaplicacionDialog(id?: number): void {
       /* let createOrEditaplicacionDialog;
        if (id === undefined || id <= 0) {
            createOrEditaplicacionDialog = this._dialog.open(CreateaplicacionDialogComponent);
        } else {
            createOrEditaplicacionDialog = this._dialog.open(EditaplicacionDialogComponent, {
                data: id
            });
        }

        createOrEditaplicacionDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });*/
    }


}
