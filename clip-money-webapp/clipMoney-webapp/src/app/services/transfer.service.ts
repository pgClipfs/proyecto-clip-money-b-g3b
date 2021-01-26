import { Injectable } from '@angular/core';
import { TransferModel } from '../models/transfer.model';
import {environment as env} from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TransferService {

constructor(private http: HttpClient) { }

async getTrasnferByUserId(userId: number){
  return await this.http.get<Array<TransferModel>>(`${env.apiUrl}/transfer/user/${userId}`).toPromise();
  }

}


