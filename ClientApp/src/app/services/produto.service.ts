import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../models/produto.model';
import { ProdutoCosif } from '../models/produto-cosif.model';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  private readonly apiUrl = `${environment.apiUrl}/produtos`;

  constructor(private http: HttpClient) {}

  listarProdutos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.apiUrl);
  }

  listarCosifsPorProduto(idProduto: string): Observable<ProdutoCosif[]> {
    return this.http.get<ProdutoCosif[]>(`${this.apiUrl}/${idProduto}/cosifs`);
  }
}