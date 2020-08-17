import { Component, OnInit, Input } from '@angular/core';
import { Pedido } from '../Model/pedido';

@Component({
  selector: 'bdg-carrinho-compras',
  templateUrl: './carrinho-compras.component.html'
})
export class CarrinhoComprasComponent implements OnInit {

  constructor() { }

  @Input() pedidosComprados: Pedido[];

  ngOnInit(): void {
  }

}
