import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContaService {


  constructor(private http: HttpClient) { }
  baseURL = environment.apiUrl + 'conta/';

  get(): Observable<any> {
    return this.http.get<any>(this.baseURL);
  }

  delete(contaId): Observable<any> {
    return this.http.delete(`${this.baseURL}Delete`, contaId);

  }

  adicionar(model: any) {
    console.log('model', model);
    return this.http.post(`${this.baseURL}Adicionar`, model);
  }

}
