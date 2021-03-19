import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginScreen } from './loginComponent/login.component';
import { AdminWindowComponent } from './admin-window/admin-window.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginScreen,
    AdminWindowComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
