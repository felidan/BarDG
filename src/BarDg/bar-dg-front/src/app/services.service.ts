import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http"
import { Pedido } from './Model/pedido';
import { URL_API } from 'src/environments/environment';

@Injectable()
export class ServicesService {
    headers = {
        headers : new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJBUkRHIiwibmFtZWlkIjoiMSIsIm5iZiI6MTU5NzY2Nzk0MSwiZXhwIjoxNTk3NjY5NzQxLCJpYXQiOjE1OTc2Njc5NDF9.Cw-6TP1SdPbZ6pHVcrlj0YJoG2MAml0oThds1c4hMuM'
        })
    };

    constructor(private http: HttpClient){

    }

            // fron form
        // const param = new FormData();
        // param.append('', '')
        //return this.http.get<Pedido>(`${URL_API}/`)

        //from body
        //JSON.stringify(obj)
        //return this.http.post<Pedido>(`${URL_API}/`, JSON.stringify(obj))

        // get
        // return this.http.get(`${URL_API}/sdsdf?param=${1}`)

    public getProdutos(){
        return this.http.get<Pedido[]>(`${URL_API}/Comanda/BuscarTodosPedidos`, this.headers);
    }

    public calcularPromocao(pedidos: Pedido[]){
        return this.http.post<Pedido[]>(`${URL_API}/Promocao/AplicarPromocao`, JSON.stringify(pedidos), this.headers);
    }
}