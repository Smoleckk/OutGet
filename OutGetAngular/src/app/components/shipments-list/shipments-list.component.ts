import { Component, OnInit } from '@angular/core';
import { Shipment } from 'src/app/models/shipment';
import { AuthService } from 'src/app/services/auth.service';
import { ShipmentsService } from 'src/app/services/shipments.service';

@Component({
  selector: 'app-shipments-list',
  templateUrl: './shipments-list.component.html',
  styleUrls: ['./shipments-list.component.css']
})
export class ShipmentsListComponent implements OnInit {
  shipments:Shipment[]=[];
  displayadmin=false;

  constructor(private shipmentsService:ShipmentsService, private authService:AuthService) { }

  ngOnInit(): void {
    this.shipmentsService.getAllShipments()
    .subscribe({
      next:(shipments)=>{
        this.shipments = shipments;
      },
      error:(respone)=>{
        console.log(respone);
      }
    })
    this.displayadmin = this.authService.HaveAccess();
  }

}
