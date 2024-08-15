import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VehicleType } from '../interfaces/vehicleType';
import { environment } from '../../environments/environment';
import { Bid } from '../interfaces/bid';

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};

const httOptionsDataType = {
  headers: new HttpHeaders({ "Content-Type": "text/plain" }),
};

const httpOptionsEncoded = {
  headers: new HttpHeaders({ "Content-Type": "text/html; charset=UTF-8" }),
};

@Injectable({
  providedIn: 'root'
})
export class BidService {
  url: string = environment.url;

  constructor(readonly http: HttpClient) { }

  getVehicleTypes(): Observable<VehicleType[]> {
    const url = `${this.url}/vehicleType`;
    return this.http.get<VehicleType[]>(url);
  }

  getBid(vehiclePrice: number, vehicleTypeId: number): Observable<Bid> {
    const url = `${this.url}/bidCalculation`;
    const params = new HttpParams()
                    .set("vehiclePrice", vehiclePrice)
                    .set("vehicleTypeId", vehicleTypeId);

    return this.http.get<Bid>(url, { params });
  }
}
