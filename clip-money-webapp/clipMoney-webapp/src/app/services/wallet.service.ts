import { TransferMoneyModel } from './../models/transferMoneyModel.model.ts';
import { UserTranserModel } from './../models/UserTranser.model.ts';
import { TransferModel } from 'src/app/models/transfer.model';
import { Injectable } from '@angular/core';
import {environment as env} from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WalletService {

constructor(private http: HttpClient) { }

async postTransactionUserId(transaction: TransferModel){

  return await this.http.post<TransferModel>(`${env.apiUrl}/wallet/insert/user`, transaction).toPromise();
  }

async getFundByUserId(userId: number){
  return await this.http.get<number>(`${env.apiUrl}/wallet/funds/${userId}`).toPromise();
}

async getUserByCvu(cvuNumber: number){
  return await this.http.get<UserTranserModel>(`${env.apiUrl}/wallet/cvu/${cvuNumber}`).toPromise();
}

async transferToUser(trans: TransferMoneyModel){
  return await this.http.post<boolean>(`${env.apiUrl}/wallet/transfer/cvu`, trans).toPromise();
}

}
