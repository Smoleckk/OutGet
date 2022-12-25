import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipmentAddComponent } from './components/shipment-add/shipment-add.component';
import { ShipmentEditComponent } from './components/shipment-edit/shipment-edit.component';
import { ShipmentsListComponent } from './components/shipments-list/shipments-list.component';

const routes: Routes = [
  {
    path:'',
    component: ShipmentsListComponent
  },
  {
    path:'shipments',
    component: ShipmentsListComponent
  },
  {
    path:'shipments/add',
    component: ShipmentAddComponent
  },
  {
    path:'shipments/edit/:id',
    component: ShipmentEditComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
