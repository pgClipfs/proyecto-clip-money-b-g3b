import { UserSignIn } from './../models/userSignIn.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {environment as env} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

constructor(private http: HttpClient) { }

  async registerUser(userRegister: UserSignIn){
  return await this.http.post<string>(`${env.apiUrl}/login/signin`, userRegister).toPromise();
  }
}
