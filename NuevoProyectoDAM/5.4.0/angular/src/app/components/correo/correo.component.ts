import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange, MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {AnuncioServiceProxy, AnuncioCreateDto, UserDto, UsuarioLogadoServiceProxy} from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase } from '@shared/paged-listing-component-base';


@Component({
  selector: 'app-correo',
  templateUrl: './correo.component.html',
  styleUrls: ['./correo.component.css']
})


export class CorreoComponent  extends PagedListingComponentBase<UserDto> {
    saving = false;
    
    emisor : string = "";
    receptor : string = "";
    asunto : string = "";
    texto : string = "";
    contrasenia : string = "";

    constructor(
        injector: Injector,
        private _userService: UsuarioLogadoServiceProxy,
      private _dialog: MatDialog
    ) {
        super(injector);
    }

  
    list ():void{}
    delete ():void{}   
        
        

    save(): void {
        //this.saving = true;
        //const Correo_ = new ();
        //Correo_.init(this.anuncio);
        //console.log(Correo_);
        
        //Correo_.publicacionCategoria = this.categoria;
        
        this._userService 
            .enviarCorreo(this.emisor, this.contrasenia, this.receptor, this.asunto, this.texto)
            
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));    
                this.refresh();            
                
                
            });
    }

    
}
