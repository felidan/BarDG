import { Pedido } from './pedido';

export interface NotaFiscal{
    idComanda: number,
    pedidos: Pedido[],
    totalSemDesconto: number,
    totalComDesconto: number
}