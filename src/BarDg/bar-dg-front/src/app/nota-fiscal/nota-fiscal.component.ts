import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'bdg-nota-fiscal',
  templateUrl: './nota-fiscal.component.html'
})
export class NotaFiscalComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  novaComanda(){
    this.router.navigate(['/cardapio']);
  }

}
