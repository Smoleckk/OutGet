import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LockerAddComponent } from './components/locker-add/locker-add.component';
import { LockerListComponent } from './components/locker-list/locker-list.component';
import { LoginComponent } from './components/login/login.component';
import { ShipmentAddComponent } from './components/shipment-add/shipment-add.component';
import { ShipmentEditComponent } from './components/shipment-edit/shipment-edit.component';
import { ShipmentsListComponent } from './components/shipments-list/shipments-list.component';
import { AuthGuard } from './shared/auth.guard';
import { RoleGuard } from './shared/role.guard';

const routes: Routes = [
  {
    path:'',
    component: ShipmentsListComponent,canActivate:[AuthGuard]
  },
  {
    path:'shipments',
    component: ShipmentsListComponent,canActivate:[AuthGuard]
  },
  {
    path:'shipments/add',
    component: ShipmentAddComponent,canActivate:[AuthGuard]
  },
  {
    path:'shipments/edit/:id',
    component: ShipmentEditComponent,canActivate:[AuthGuard]
  },
  {
    path:'lockers',
    component: LockerListComponent,canActivate:[RoleGuard]
  },
  {
    path:'lockers/add',
    component: LockerAddComponent,canActivate:[RoleGuard]
  },
  {
    path:'login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
