import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Shipment } from '../models/shipment';
import { Usersname } from '../models/username';

@Injectable({
  providedIn: 'root'
})
export class ShipmentsService {
  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http:HttpClient) { }

  getAllShipments():Observable<Shipment[]>{
    return this.http.get<Shipment[]>(this.baseApiUrl+'/Shipment');
  }
  
  addShipment(addShipmentRequest:Shipment): Observable<Shipment>{
   return this.http.post<Shipment>(this.baseApiUrl+'/Shipment',addShipmentRequest )
  }

getShipment(id:string): Observable<Shipment>{
  return this.http.get<Shipment>(this.baseApiUrl+'/Shipment/'+id)
}
updateShipment(updateShipmentRequest:Shipment): Observable<Shipment>{
  return this.http.put<Shipment>(this.baseApiUrl+'/Shipment/',updateShipmentRequest );
}
getUsers():Observable<Usersname[]>{
  return this.http.get<Usersname[]>(this.baseApiUrl +'/User/users-name');
}
}
