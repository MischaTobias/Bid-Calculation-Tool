import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BidFormComponent } from './bid-form.component';
import { BidService } from '../../services/bid.service';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('BidFormComponent', () => {
  let component: BidFormComponent;
  let fixture: ComponentFixture<BidFormComponent>;
  let service: BidService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BidFormComponent],
      imports: [
        BrowserModule,
        FormsModule,
        HttpClientTestingModule // Import HttpClientTestingModule
      ],
      providers: [BidService],
    })
    .compileComponents();

    fixture = TestBed.createComponent(BidFormComponent);
    component = fixture.componentInstance;
    service = TestBed.inject(BidService);
    fixture.detectChanges();
  });

  // 1. Initialization Test
  it('should create and initialize with default values', () => {
    expect(service).toBeTruthy();
    expect(component).toBeTruthy();
    expect(component.vehiclePrice).toBeUndefined();
    expect(component.vehicleType).toBeUndefined();
  });

  // 2. DOM Rendering Test
  it('should render the form correctly', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('label[for="price"]')?.textContent).toContain('Vehicle Price:');
    expect(compiled.querySelector('label[for="dropdown"]')?.textContent).toContain('Choose a vehicle type:');
  });

  // 3. Event Handling Test - Vehicle Price Change
  it('should call calculatePrice when vehicle price changes', () => {
    spyOn(component, 'calculatePrice');
    const input = fixture.nativeElement.querySelector('input');
    input.value = '10000';
    input.dispatchEvent(new Event('input'));
    input.dispatchEvent(new Event('change'));
    fixture.detectChanges();
    expect(component.calculatePrice).toHaveBeenCalled();
    expect(component.vehiclePrice).toBe(10000);
  });

  // 4. Event Handling Test - Vehicle Type Change
  it('should call calculatePrice when vehicle type changes', () => {
    // Arrange
    component.vehicleTypes = [
      { id: 1, name: 'Type 1' },
      { id: 2, name: 'Type 2' }
    ];
    fixture.detectChanges();  // Make sure the template is updated

    spyOn(component, 'calculatePrice');

    // Act
    const select: HTMLSelectElement = fixture.nativeElement.querySelector('select');
    select.value = select.options[1].value;  // Select the second option
    select.dispatchEvent(new Event('change'));

    fixture.detectChanges();  // Update the view to reflect the changes

    // Assert
    expect(component.calculatePrice).toHaveBeenCalled();
  });

  // 5. Conditional Rendering Test
  it('should display the bid details when bid is present', () => {
    component.bid = {
      fees: [{ name: 'Fee 1', value: 100 }, { name: 'Fee 2', value: 200 }],
      total: 10300
    };
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.list-container')).toBeTruthy();
    expect(compiled.querySelector('.total-text')?.textContent).toContain('Total: $10,300.00');
  });

  it('should not display the bid details when bid is not present', () => {
    component.bid = undefined;
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.list-container')).toBeNull();
  });
});
