import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Locker } from 'src/app/models/locker';
import { Shipment } from 'src/app/models/shipment';
import { Usersname } from 'src/app/models/username';
import { LockerService } from 'src/app/services/locker.service';
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
    receiver:'',
    fromLockerName:'',
    toLockerName  :''
  };
  lockers:Locker[]=[];
usersname:Usersname[]=[];
  constructor(private shipmentsService: ShipmentsService,private router:Router,private lockerService:LockerService, ) {}

  ngOnInit(): void {    
    this.lockerService.getAllLocker()
    .subscribe({
      next:(lockers)=>{
        this.lockers = lockers;
        console.log(lockers);
      },
      error:(respone)=>{
        console.log(respone);
      }
    })
    this.shipmentsService.getUsers()
    .subscribe({
      next:(users)=>{
        this.usersname = users;
        console.log(this.usersname[0].name);
      },
      error:(respone)=>{
        console.log(respone);
      }
    })
  }

  addShipment() {
    this.shipmentsService.addShipment(this.addShipmentRequest).subscribe({
      next: (shipment) => {
        this.router.navigate(['shipments']);
      },
    });

  }
}
