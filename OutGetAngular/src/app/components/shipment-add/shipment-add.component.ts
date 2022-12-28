import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Shipment } from 'src/app/models/shipment';
import { ShipmentsService } from 'src/app/services/shipments.service';

@Component({
  selector: 'app-shipment-add',
  templateUrl: './shipment-add.component.html',
  styleUrls: ['./shipment-add.component.css'],
})
export class ShipmentAddComponent implements OnInit {
  addShipmentRequest: Shipment = {
    name: '',
    state: 'Nadana',
  };

  constructor(private shipmentsService: ShipmentsService,private router:Router) {}

  ngOnInit(): void {}

  addShipment() {
    this.shipmentsService.addShipment(this.addShipmentRequest).subscribe({
      next: (shipment) => {
        this.router.navigate(['shipments']);
      },
    });
  }
}
