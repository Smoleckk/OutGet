import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Locker } from 'src/app/models/locker';
import { LockerService } from 'src/app/services/locker.service';

@Component({
  selector: 'app-locker-add',
  templateUrl: './locker-add.component.html',
  styleUrls: ['./locker-add.component.css']
})
export class LockerAddComponent implements OnInit {
addLockerRequest:Locker={
  name:'',
  city:''
}
  constructor(private lockerService:LockerService,private router:Router) { }

  ngOnInit(): void {
  }
  addLocker() {
    this.lockerService.addLocker(this.addLockerRequest).subscribe({
      next: (locker) => {
        this.router.navigate(['lockers']);
      },
    });

  }
}
