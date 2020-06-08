import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
  UsuarioLogadoServiceProxy, UserDto
} from '@shared/service-proxies/service-proxies';


@Component({
  selector: 'app-ajustes',
  templateUrl: './ajustes.component.html',
  styleUrls: ['./ajustes.component.css']
})

export class AjustesComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  user: UserDto = new UserDto();
  

  constructor(
    injector: Injector,
    public _userService: UsuarioLogadoServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._userService.getUsuarioLogado().subscribe(result => {
      this.user = result;    
    });
  }


  save(): void {
    this.saving = true;

    this._userService
      .update(this.user)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        
      });
  }

  
}