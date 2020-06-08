import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';

import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AbpModule } from '@abp/abp.module';

import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';

import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
import { TopBarComponent } from '@app/layout/topbar.component';
import { TopBarLanguageSwitchComponent } from '@app/layout/topbar-languageswitch.component';
import { SideBarUserAreaComponent } from '@app/layout/sidebar-user-area.component';
import { SideBarNavComponent } from '@app/layout/sidebar-nav.component';
import { SideBarFooterComponent } from '@app/layout/sidebar-footer.component';
import { RightSideBarComponent } from '@app/layout/right-sidebar.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import { RolesComponent } from '@app/components/roles/roles.component';
import { CreateRoleDialogComponent } from './components/roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './components/roles/edit-role/edit-role-dialog.component';
// users
import { UsersComponent } from '@app/components/users/users.component';
import { CreateUserDialogComponent } from '@app/components/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/components/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './components/users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './components/users/reset-password/reset-password.component';
// anuncios
import { AnunciosComponent } from '@app/components/anuncios/anuncios.component';
import { CreateAnuncioDialogComponent } from '@app/components/anuncios/create-anuncios/create-anuncio-dialog.component';
import { EditAnuncioDialogComponent } from '@app/components/anuncios/edit-anuncios/edit-anuncio-dialog.component';
import { AnuncioServiceProxy, UsuarioLogadoServiceProxy, ChatServiceProxy, PublicacionGustadaServiceProxy } from '@shared/service-proxies/service-proxies';
import { DesplegableCategoriaComponent } from './components/anuncios/desplegable-categoria/desplegable-categoria.component';
// peticiones
import { PeticionesComponent } from '@app/components/peticiones/peticiones.component';
import { CreatePeticionDialogComponent } from '@app/components/peticiones/create-peticiones/create-peticion-dialog.component';
import { EditPeticionDialogComponent } from '@app/components/peticiones/edit-peticiones/edit-peticion-dialog.component';
import { PeticionServiceProxy} from '@shared/service-proxies/service-proxies';
// perfil 
import { PerfilComponent } from './components/perfil/perfil.component';
import { UsuariosSeguidoresComponent } from './components/perfil/usuarios-seguidores/usuarios-seguidores.component';
import { UsuariosSeguidosComponent } from './components/perfil/usuarios-seguidos/usuarios-seguidos.component';
import { MostrarSeguidoresComponent } from './components/perfil/usuarios-seguidores/mostrar-seguidores/mostrar-seguidores.component';
import { MostrarSeguidosComponent } from './components/perfil/usuarios-seguidos/mostrar-seguidos/mostrar-seguidos.component';
import { MostrarAnunciosComponent } from './components/perfil/mostrar-anuncios/mostrar-anuncios.component';
import { MostrarPeticionesComponent } from './components/perfil/mostrar-peticiones/mostrar-peticiones.component';
import { AnunciosCompletosComponent } from './components/perfil/mostrar-anuncios/anuncios-completos/anuncios-completos.component';
import { PeticionesCompletasComponent } from './components/perfil/mostrar-peticiones/peticiones-completas/peticiones-completas.component';
// chats
import { ChatsComponent } from './components/chats/chats.component';
import { CreateChatDialogComponent } from './components/chats/create-chats/create-chat-dialog.component';
import { ChatsReducidosComponent } from './components/chats/chats-reducidos/chats-reducidos.component';
import { ChatsUsuariosComponent } from './components/chats/chats-usuarios/chats-usuarios.component';
// usuarios
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { FotoComponent } from './components/foto/foto.component';
// ajustes
import { AjustesComponent } from './components/ajustes/ajustes.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    TopBarComponent,
    TopBarLanguageSwitchComponent,
    SideBarUserAreaComponent,
    SideBarNavComponent,
    SideBarFooterComponent,
    RightSideBarComponent,
    // tenants
    TenantsComponent,
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    RolesComponent,
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    UsersComponent,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ChangePasswordComponent,
    ResetPasswordDialogComponent,
    // anuncios
    AnunciosComponent,
    CreateAnuncioDialogComponent,
    EditAnuncioDialogComponent,
    DesplegableCategoriaComponent,
    // peticiones
    PeticionesComponent,
    CreatePeticionDialogComponent,
    EditPeticionDialogComponent,
    // perfil
    PerfilComponent,
    UsuariosSeguidosComponent,
    UsuariosSeguidoresComponent,
    MostrarSeguidoresComponent,
    MostrarSeguidosComponent,
    MostrarAnunciosComponent,
    MostrarPeticionesComponent,
    AnunciosCompletosComponent,
    PeticionesCompletasComponent,
    // chats
    ChatsComponent,
    CreateChatDialogComponent,
    ChatsReducidosComponent,
    ChatsUsuariosComponent,
    //usuarios
    UsuariosComponent,
    FotoComponent,
    //ajustes
    AjustesComponent
    
    
    
  ],

  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forRoot(),
    AbpModule,
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule
  ],
  providers: [AnuncioServiceProxy, UsuarioLogadoServiceProxy, ChatServiceProxy, PeticionServiceProxy, PublicacionGustadaServiceProxy],
  entryComponents: [
    // tenants
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,
    // anuncios
    CreateAnuncioDialogComponent,
    EditAnuncioDialogComponent,
    // peticiones
    CreatePeticionDialogComponent,
    EditPeticionDialogComponent,
    // chats
    CreateChatDialogComponent,
    ChatsReducidosComponent,
    ChatsUsuariosComponent,
    //perfil
    MostrarSeguidoresComponent,
    MostrarSeguidosComponent,
    MostrarAnunciosComponent,
    MostrarPeticionesComponent,
    FotoComponent,
    AnunciosCompletosComponent,
    PeticionesCompletasComponent
  ],
})
export class AppModule {}
