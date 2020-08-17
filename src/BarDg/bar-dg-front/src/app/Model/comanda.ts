import { Pedido } from './pedido';

export interface Comanda{
    pedidos: Pedido[],
    idComanda: number
}