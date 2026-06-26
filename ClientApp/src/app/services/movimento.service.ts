import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MovimentoLista } from '../models/movimento-lista.model';
import { MovimentoCreate } from '../models/movimento-create.model';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovimentoService {
  private readonly apiUrl = `${environment.apiUrl}/movimentos`;

  constructor(private http: HttpClient) {}

  listarMovimentos(): Observable<MovimentoLista[]> {
    return this.http.get<MovimentoLista[]>(this.apiUrl);
  }

  incluirMovimento(movimento: MovimentoCreate): Observable<MovimentoCreate> {
    return this.http.post<MovimentoCreate>(this.apiUrl, movimento);
  }
}