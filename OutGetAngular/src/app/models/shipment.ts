export interface Shipment{
    id?:number,
    name:string,
    state:string,
    receiver:string,
    fromLockerName:string,
    toLockerName:string
}