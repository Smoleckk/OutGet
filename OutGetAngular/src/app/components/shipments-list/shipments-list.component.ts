import { Component, OnInit } from '@angular/core';
import { Shipment } from 'src/app/models/shipment';
import { ShipmentsService } from 'src/app/services/shipments.service';

@Component({
  selector: 'app-shipments-list',
  templateUrl: './shipments-list.component.html',
  styleUrls: ['./shipments-list.component.css']
})
export class ShipmentsListComponent implements OnInit {
  shipments:Shipment[]=[];

  constructor(private shipmentsService:ShipmentsService) { }

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
  }

}
