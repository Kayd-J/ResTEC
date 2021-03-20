import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginScreen } from './loginComponent/login.component';
import { AdminWindowComponent } from './admin-window/admin-window.component';
import { WorkbenchComponent } from './workbench/workbench.component';
import { TestComponent } from './test/test.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginScreen,
    AdminWindowComponent,
    WorkbenchComponent,
    TestComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  entryComponents: [WorkbenchComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
