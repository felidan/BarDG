import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { HttpClientModule } from '@angular/common/http';
import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AppRoutingModule } from './app-routing.module';
import { ServicesService } from './services.service';
import { AppComponent } from './app.component';
import { CardapioComponent } from './cardapio/cardapio.component';
import { PedidoComponent } from './pedido/pedido.component';
import { PromocoesComponent } from './promocoes/promocoes.component';
import { CarrinhoComprasComponent } from './carrinho-compras/carrinho-compras.component';
import { NotaFiscalComponent } from './nota-fiscal/nota-fiscal.component';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    CardapioComponent,
    PedidoComponent,
    PromocoesComponent,
    CarrinhoComprasComponent,
    NotaFiscalComponent
  ],
  exports: [
    PedidoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    NgxSpinnerModule,
    BrowserAnimationsModule
  ],
  providers: [ServicesService],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class AppModule { }
