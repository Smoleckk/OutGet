import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Shipment } from 'src/app/models/shipment';
import { AuthService } from 'src/app/services/auth.service';
import { ShipmentsService } from 'src/app/services/shipments.service';

@Component({
  selector: 'app-shipment-edit',
  templateUrl: './shipment-edit.component.html',
  styleUrls: ['./shipment-edit.component.css'],
})
export class ShipmentEditComponent implements OnInit {
  shipmentDetails: Shipment = {
    name: '',
    state: '',
  };
  displayadmin=false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private shipmentsService: ShipmentsService,
    private authService:AuthService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.shipmentsService.getShipment(id).subscribe({
            next: (response) => {
              this.shipmentDetails = response;
            },
          });
        }
      },
    });
    this.displayadmin = this.authService.HaveAccess();

  }

  updateShipment() {
    this.shipmentsService.updateShipment(this.shipmentDetails).subscribe({
      next: (response) => {
        this.router.navigate(['shipments']);
      },
    });
  }
}
