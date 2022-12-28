import { Component, OnInit } from '@angular/core';
import { Locker } from 'src/app/models/locker';
import { AuthService } from 'src/app/services/auth.service';
import { LockerService } from 'src/app/services/locker.service';

@Component({
  selector: 'app-locker-list',
  templateUrl: './locker-list.component.html',
  styleUrls: ['./locker-list.component.css']
})
export class LockerListComponent implements OnInit {
  lockers:Locker[]=[];
  displayadmin=false;

  constructor(private lockerService:LockerService, private authService:AuthService) { }

  ngOnInit(): void {
    this.lockerService.getAllLocker()
    .subscribe({
      next:(lockers)=>{
        this.lockers = lockers;
      },
      error:(respone)=>{
        console.log(respone);
      }
    })
    this.displayadmin = this.authService.HaveAccess();
  }

}
