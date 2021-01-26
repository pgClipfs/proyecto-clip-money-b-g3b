import { OpenTurnModel } from '../models/openTurnModel.model.ts';
import { Injectable } from '@angular/core';
import {environment as env} from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OpenTurnService {

  constructor(private http: HttpClient) { }

  async getOpenTurnByUserId(userId: number){
    return await this.http.get<OpenTurnModel>(`${env.apiUrl}/openturn/user/${userId}`).toPromise();
    }

  }
