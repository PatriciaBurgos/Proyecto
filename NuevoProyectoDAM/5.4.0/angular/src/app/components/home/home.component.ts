import { Component, Injector, AfterViewInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
    templateUrl: './home.component.html',
    animations: [appModuleAnimation()],
    styleUrls: ['./home.component.css']
})
export class HomeComponent extends AppComponentBase implements AfterViewInit {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
    ngAfterViewInit(): void {
        throw new Error("Method not implemented.");
    }

}
