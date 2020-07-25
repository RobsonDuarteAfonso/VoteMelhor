import { CommandResult } from './../../models/command-result.model';
import { environment } from '../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { delay } from 'rxjs/operators';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SearchPoliticalService {

  private readonly ApiUrl = environment.apiUrl;

  headers = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

  constructor(private http: HttpClient) {
  }

  getSearchPolitical(criteria: any): Observable<CommandResult> {

    return this.http.post<CommandResult>(this.ApiUrl + 'v1/public/search',
      JSON.stringify(criteria),
      this.headers);
  }
}
