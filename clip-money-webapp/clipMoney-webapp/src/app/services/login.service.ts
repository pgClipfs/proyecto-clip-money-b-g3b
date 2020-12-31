import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {environment as env} from '../../environments/environment';
import { UserSignOnModel } from '../models/userSignOn.model';
import jwt_decode from 'jwt-decode';
import { UserLoggedModel } from '../models/userLogged.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient){}

  async loginUser(userRegister: UserSignOnModel){
    return await this.http.post<UserLoggedModel>(`${env.apiUrl}/login/signon`, userRegister).toPromise();
    }

    setCurrentUser(token: string){
      localStorage.setItem('currentUser', token);
    }

    deleteCurrentUser(){
      localStorage.removeItem('currentUser');
    }

    getToken(){
      return localStorage.getItem('currentUser');
    }

    getCurrentUser(){
      const token = this.getToken();
      if (token !== null){

        const tokenDecode = jwt_decode(token);
        const currentUser: UserSignOnModel = {
          NombreUsuario: tokenDecode['user'],
          Password: ""
        };
        return currentUser;
      }
    }

}
