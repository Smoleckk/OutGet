import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ShipmentsListComponent } from './components/shipments-list/shipments-list.component';
import { ShipmentAddComponent } from './components/shipment-add/shipment-add.component';
import { FormsModule } from '@angular/forms';
import { ShipmentEditComponent } from './components/shipment-edit/shipment-edit.component';
import { LoginComponent } from './components/login/login.component';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { LockerListComponent } from './components/locker-list/locker-list.component';
import { LockerAddComponent } from './components/locker-add/locker-add.component';


@NgModule({
  declarations: [
    AppComponent,
    ShipmentsListComponent,
    ShipmentAddComponent,
    ShipmentEditComponent,
    LoginComponent,
    LockerListComponent,
    LockerAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule
  ],
  providers: [{provide:HTTP_INTERCEPTORS,useClass:TokenInterceptorService,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
