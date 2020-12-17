import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { KitchenComponent } from './kitchen/kitchen.component';

// an NgModule (aka module - so long as we distinguish from JS/TS module)
// can
// - declare components, directives, and pipes
// - export components etc, for other modules to import
// - import other ngmodules to get access to what they've exported
// - be the provider for services
// - bootstrap: specifically the root module should have this,
//     and put the root component in it.

@NgModule({
  declarations: [
    AppComponent,
    KitchenComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  exports: [],
  providers: [], // services that will share one instance
                 // within this module
  bootstrap: [AppComponent]
})
export class AppModule { }
