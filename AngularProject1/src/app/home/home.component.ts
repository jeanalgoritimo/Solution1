import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { ParamtrosCalculo } from '../../Models/ParamtrosCalculo';
import { CalculoService } from '../../Services/calculo.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnDestroy {
  private destroy$ = new Subject<void>();
  CalcCard = false;
  ValorBruto = "";
  ValorLiquido: number | undefined;

  CalcForm = this.formBuilder.group({
    ValorInicial: ['', Validators.required],
    Prazo: ['', Validators.required],
   
  });
  constructor(private formBuilder: FormBuilder,
              private calculoService: CalculoService) {}

  onSubmitCalcForm(): void {
    if (this.CalcForm.value && this.CalcForm.valid) {
      this.calculoService
        .Calcular(this.CalcForm.value as ParamtrosCalculo)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: (response) => {
            if (response) {
               
              this.CalcForm.reset();
              this.CalcCard = true;
              this.ValorBruto = response.ValorBruto;
              this.ValorLiquido = response.ValorLiquido;
              
            }
          },
          error: (err) => { 
            console.log(err);
          },
        });
    }
  }
  
  ngOnChanges(changes: any) {

}

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}


