import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing'; // Import HttpClientTestingModule
import { BidService } from './bid.service';

describe('BidService', () => {
  let service: BidService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule], // Include HttpClientTestingModule
      providers: [BidService] // Provide the BidService
    });

    service = TestBed.inject(BidService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
