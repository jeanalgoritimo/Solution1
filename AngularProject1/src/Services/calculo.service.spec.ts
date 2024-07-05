import { HttpClient } from '@angular/common/http';
import { TestBed , async, inject } from '@angular/core/testing';
import { CalculoService } from './calculo.service';
 
import { HttpClientTestingModule } from '@angular/common/http/testing';


describe('CalculoService', () => {
  let service: CalculoService;
  let http: HttpClient;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalculoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
