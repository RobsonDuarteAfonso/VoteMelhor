import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { CommandResult } from './../../models/command-result.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StatesService {

  private readonly ApiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getStatesBR(): Observable<CommandResult> {
    return this.http.get<CommandResult>(this.ApiUrl + 'v1/public/states');
  }
}
