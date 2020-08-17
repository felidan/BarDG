import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Pedido } from 'src/app/Model/pedido';

@Component({
  selector: 'bdg-pedido',
  templateUrl: './pedido.component.html'
})
export class PedidoComponent implements OnInit {

  constructor() { }

  @Input() pedido: Pedido
  @Output() evento: EventEmitter<any> = new EventEmitter()

  ngOnInit(): void {

  }

  adicionar(){
    this.pedido.quantidade ++;
    this.pedido.acao = '+'
    this.evento.emit(this.pedido)
  }

  remover(){
    if(this.pedido.quantidade > 0){
      this.pedido.quantidade --;
      this.pedido.acao = '-'
      this.evento.emit(this.pedido)
    }
  }

  habilita(){
    if(this.pedido.id == 3 && this.pedido.quantidade >= 3){
      return 0
    }
    return 1
  }

}
