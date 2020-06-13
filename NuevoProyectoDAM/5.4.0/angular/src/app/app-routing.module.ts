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
import { ChatsComponent } from './components/chats/chats.component';
import { PeticionesComponent } from './components/peticiones/peticiones.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { ChatsUsuariosComponent } from './components/chats/chats-usuarios/chats-usuarios.component';
import { AjustesComponent } from './components/ajustes/ajustes.component';



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
                    //{ path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent },
                    { path: 'anuncios', component: AnunciosComponent, data: { permission: 'Pages.Anuncios' } },
                    { path: 'peticiones', component: PeticionesComponent, data: { permission: 'Pages.Peticiones' } },
                    { path: 'perfil', component: PerfilComponent, data: { permission: 'Pages.UsersNormales' } },
                    { path: 'perfil/:id', component: PerfilComponent, data: { permission: 'Pages.UsersNormales' } },
                    { path: 'chats', component: ChatsComponent, data: { permission: 'Pages.Chats' } },
                    { path: 'chats/:id', component: ChatsUsuariosComponent, data: { permission: 'Pages.Chats' } },
                    { path: 'ajustes', component: AjustesComponent, data: { permission: 'Pages.UsersNormales' } },
                    { path: 'usuarios', component: UsuariosComponent, data: { permission: 'Pages.UsersNormales' } }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
