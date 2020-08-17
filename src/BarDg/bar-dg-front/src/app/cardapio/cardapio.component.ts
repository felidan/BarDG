import { Component, OnInit } from '@angular/core';
import { Pedido } from '../Model/pedido';
import { ServicesService } from '../services.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'bdg-cardapio',
  templateUrl: './cardapio.component.html'
})
export class CardapioComponent implements OnInit {

  constructor(private service: ServicesService, private modalService: NgbModal, private router: Router) { }

  pedidos: Pedido[]
  pedidosComprados: Pedido[]

  ngOnInit(): void {
    this.service.getProdutos()
    .subscribe(pedidosData => {
      
      this.pedidos = pedidosData;
    });
  }

  eventoRecebido(event: Pedido){
    
    let remove: boolean = true;

    var pedito = this.pedidos.filter(x => x.id === event.id);

    if(event.acao == '-'){
      
      this.pedidosComprados.forEach((item, index) => {
        if(item.id == event.id && remove){
          this.pedidosComprados.splice(index, 1);
          remove = false
        } 
      });

    }
    else{
      if(this.pedidosComprados === undefined){
        this.pedidosComprados = pedito;
      }
      else{
        this.pedidosComprados.push(pedito[0]);
      }
    }

    this.calcularPromocao(this.pedidosComprados);
  }

  calcularPromocao(pedidosComprados: Pedido[]) {
    
    this.service.calcularPromocao(pedidosComprados)
    .subscribe(pedidosCalculados => {

      this.pedidosComprados = pedidosCalculados;

    });
  }

  totalPedido(){
    var total = 0;

    if(this.pedidosComprados !== undefined){
      this.pedidosComprados.forEach(x => {
        total += (x.preco - x.desconto)
      });
    }
    
    return total;
  }

  open(context: any){
    this.modalService.open(context);
  }

  fecharComanda(){
    this.router.navigate(['/nota-fiscal']);
  }
}
