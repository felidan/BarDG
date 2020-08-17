import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CardapioComponent } from './cardapio/cardapio.component';
import { PedidoComponent } from './pedido/pedido.component';
import { HttpClientModule } from '@angular/common/http';
import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { ServicesService } from './services.service';
import { PromocoesComponent } from './promocoes/promocoes.component';
import { CarrinhoComprasComponent } from './carrinho-compras/carrinho-compras.component';
registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    CardapioComponent,
    PedidoComponent,
    PromocoesComponent,
    CarrinhoComprasComponent
  ],
  exports: [
    PedidoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ServicesService],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
