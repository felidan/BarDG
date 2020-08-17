import { Component, OnInit } from '@angular/core';
import { Pedido } from '../Model/pedido';
import { ServicesService } from '../services.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { Comanda } from '../Model/comanda';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'bdg-cardapio',
  templateUrl: './cardapio.component.html'
})
export class CardapioComponent implements OnInit {

  constructor(private service: ServicesService, 
      private modalService: NgbModal, 
      private router: Router, 
      private spinner: NgxSpinnerService) { }

  pedidos: Pedido[]
  pedidosComprados: Pedido[]
  comanda: Comanda = { idComanda: 0, pedidos: []}

  ngOnInit(): void {

    this.spinner.show();

    this.service.getProdutos()
    .subscribe(pedidosData => {  
      this.pedidos = pedidosData;

      this.service.abrirComanda()
      .subscribe(idComanda => {
        this.comanda.idComanda = idComanda;

        this.spinner.hide();

      });

    });  
  }

  eventoRecebido(event: Pedido){
    
    let remove: boolean = true;

    var pedido = this.pedidos.filter(x => x.id === event.id);

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
        pedido[0].idComanda = this.comanda.idComanda;
        this.pedidosComprados = pedido;
      }
      else{
        pedido[0].idComanda = this.comanda.idComanda;
        this.pedidosComprados.push(pedido[0]);
      }
    }

    this.calcularPromocao(this.pedidosComprados);
  }

  calcularPromocao(pedidosComprados: Pedido[]) {
    
    this.spinner.show();

    this.service.calcularPromocao(pedidosComprados)
    .subscribe(pedidosCalculados => {

      this.pedidosComprados = pedidosCalculados;
      this.comanda.pedidos = this.pedidosComprados;
    
      this.spinner.hide();
    
      if(this.pedidosComprados.length == 0){
        
        this.spinner.show();
        
        this.limparComanda(this.comanda.idComanda);
        
        this.service.limparComanda(this.comanda.idComanda)
        .subscribe(x => { this.spinner.hide(); });
      }
      else{
        this.registrarComandaAtual(this.pedidosComprados);
      }
    });
  }
  
  eventoLimparComanda(){

    this.limparComanda(this.comanda.idComanda);

    this.spinner.show();

    this.service.getProdutos()
    .subscribe(pedidosData => {  
      this.pedidos = pedidosData;
      this.spinner.hide();
    });

    this.pedidosComprados = [];

    this.comanda.pedidos = [];
  }

  limparComanda(idComanda: number) {
 
    this.spinner.show();
    
    this.service.limparComanda(idComanda)
    .subscribe(x => { this.spinner.hide(); });

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

  registrarComandaAtual(pedidos: Pedido[]){
  
    this.spinner.show();

    this.service.registrarComanda(pedidos)
    .subscribe(idComanda => {
      this.comanda.idComanda = idComanda;

      this.spinner.hide();
    });

  }

  fecharComanda(){
    this.router.navigate(['/nota-fiscal', this.comanda.idComanda]);
  }
}
