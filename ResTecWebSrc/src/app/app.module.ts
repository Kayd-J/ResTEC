import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginScreen } from './loginComponent/login.component';
import { AdminWindowComponent } from './admin-window/admin-window.component';
import { WorkbenchComponent } from './workbench/workbench.component';
import { ActionRequiredComponent } from './action-required/action-required.component';
import { CheffOwnedComponent } from './cheff-owned/cheff-owned.component';
import { UpdateTableComponent } from './update-table/update-table.component';
import { CreateComponent } from './create/create.component';
import { CreateMenuComponent } from './create-menu/create-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginScreen,
    AdminWindowComponent,
    WorkbenchComponent,
    ActionRequiredComponent,
    CheffOwnedComponent,
    UpdateTableComponent,
    CreateComponent,
    CreateMenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  entryComponents: [WorkbenchComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
