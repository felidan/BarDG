import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CardapioComponent } from './cardapio/cardapio.component';
import { NotaFiscalComponent } from './nota-fiscal/nota-fiscal.component';


const routes: Routes = [
  { path: '', redirectTo: '/cardapio', pathMatch: 'full'},
  { path: 'cardapio', component: CardapioComponent},
  { path: 'nota-fiscal/:idComanda', component: NotaFiscalComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
