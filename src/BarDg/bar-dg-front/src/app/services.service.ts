import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http"
import { Pedido } from './Model/pedido';
import { URL_API, SENHA_API, LOGIN_API } from 'src/environments/environment';
import { NotaFiscal } from './Model/nota-fiscal';
import { Login } from './Model/login';

@Injectable()
export class ServicesService {

    static token = ''

    constructor(private http: HttpClient){}

    private getHeaders(){

        return  {
            headers : new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${ServicesService.token}`
            })
        };
    }

    public loginApi(){
        var usuario = { login: LOGIN_API, senha: SENHA_API };
        return this.http.post<Login>(`${URL_API}/Login/Login`, JSON.stringify(usuario), this.getHeaders());
    }

    public getProdutos(){
        return this.http.get<Pedido[]>(`${URL_API}/Comanda/BuscarTodosPedidos`, this.getHeaders());
    }

    public calcularPromocao(pedidos: Pedido[]){
        return this.http.post<Pedido[]>(`${URL_API}/Promocao/AplicarPromocao`, JSON.stringify(pedidos), this.getHeaders());
    }

    public abrirComanda(){
        return this.http.get<number>(`${URL_API}/Comanda/AbrirComanda`, this.getHeaders())
    }

    public registrarComanda(pedidos: Pedido[]){
        return this.http.post<number>(`${URL_API}/Comanda/RegistrarComanda`, JSON.stringify(pedidos), this.getHeaders());
    }

    public limparComanda(idComanda: number){
        return this.http.delete<number>(`${URL_API}/Comanda/LimparComanda/${idComanda.toString()}`, this.getHeaders());
    }

    public gerarNotaFiscal(idComanda: number){
        return this.http.get<NotaFiscal>(`${URL_API}/Comanda/GerarNotaFiscal/${idComanda.toString()}`, this.getHeaders());
    }
}