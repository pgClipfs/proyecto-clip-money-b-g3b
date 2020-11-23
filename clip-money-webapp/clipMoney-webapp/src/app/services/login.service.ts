import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {environment as env} from '../../environments/environment';
import { UserSignOnModel } from '../models/userSignOn.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient){}

  async loginUser(userRegister: UserSignOnModel){
    return await this.http.post<string>(`${env.apiUrl}/login/signon`, userRegister).toPromise();
    }

}
