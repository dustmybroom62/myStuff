import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Sample01Component } from './components/sample01/sample01.component';
import { Sample02Component } from './components/sample02/sample02.component';

@NgModule({
  declarations: [
    AppComponent,
    Sample01Component,
    Sample02Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
