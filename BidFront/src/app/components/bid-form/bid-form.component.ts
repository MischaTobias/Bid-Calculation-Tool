import { Component, OnInit } from '@angular/core';
import { BidService } from '../../services/bid.service';
import { VehicleType } from '../../interfaces/vehicleType';
import { Bid } from '../../interfaces/bid';

@Component({
  selector: 'app-bid-form',
  templateUrl: './bid-form.component.html',
  styleUrl: './bid-form.component.scss',
})
export class BidFormComponent implements OnInit {
  vehicleTypes: VehicleType[] | undefined;
  vehiclePrice: number | undefined;
  vehicleType: number | undefined;
  bid: Bid | undefined;

  constructor(readonly bidService: BidService) {}

  ngOnInit(): void {
    this.bidService.getVehicleTypes().subscribe(
      (data: VehicleType[]) => {
        this.vehicleTypes = data;
        console.log(this.vehicleTypes);
      },
      (error) => {
        console.error('Error fetching policy:', error);
      }
    );
  }

  calculatePrice(): void {
    if(this.vehiclePrice === undefined || this.vehicleType === undefined) return;

    this.bidService.getBid(this.vehiclePrice, this.vehicleType).subscribe(
      (data: Bid) => {
        this.bid = data;
        console.log(this.bid);
      },
      (error) => {
        console.error('Error fetching policy:', error);
      }
    );
  }
}
