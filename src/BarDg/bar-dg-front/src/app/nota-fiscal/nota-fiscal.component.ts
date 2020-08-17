import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ServicesService } from '../services.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotaFiscal } from '../Model/nota-fiscal';

@Component({
  selector: 'bdg-nota-fiscal',
  templateUrl: './nota-fiscal.component.html'
})
export class NotaFiscalComponent implements OnInit {

  idComanda: number;
  notaFiscal: NotaFiscal

  constructor(private router: Router,
      private service: ServicesService,
      private spinner: NgxSpinnerService,
      private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.spinner.show();

    this.route.params.subscribe(param => {
      
      this.idComanda = param['idComanda']

      this.service.gerarNotaFiscal(this.idComanda)
      .subscribe(nota => {
  
        this.notaFiscal = nota;
        
        this.spinner.hide();
      });

    });
  }

  novaComanda(){
    this.router.navigate(['/cardapio']);
  }

}
