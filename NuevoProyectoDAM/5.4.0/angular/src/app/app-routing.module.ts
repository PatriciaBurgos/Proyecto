import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './components/users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/components/roles/roles.component';
import { ChangePasswordComponent } from './components/users/change-password/change-password.component';
import { AnunciosComponent } from 'app/components/anuncios/anuncios.component';
import { PerfilComponent } from 'app/components/perfil/perfil.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent },
                    { path: 'anuncios', component: AnunciosComponent, data: { permission: 'Pages.Anuncios' } },
                    { path: 'perfil', component: PerfilComponent, data: { permission: 'Pages.Users' } }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
