import { LoginService } from './../../services/login.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserSignOnModel } from 'src/app/models/userSignOn.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {


  signOnForm: FormGroup;
  userLogin: UserSignOnModel;

  constructor(private formBuilder: FormBuilder, private loginService: LoginService){ }

  ngOnInit(): void {
    this.signOnForm = this.formBuilder.group({
      name: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required])
    });
  }

  async loginUser(){
    this.userLogin = {
      NombreUsuario: this.signOnForm.value.name,
      Password: this.signOnForm.value.password
    };
    try {
      const result = await this.loginService.loginUser(this.userLogin);

      if(result)
      {
        console.log("Usuario Logueado!!!");
      }

      else{
        console.log("Ha ocurrido un error");
        return;
      }

    } catch (error) {
      console.warn(error);
    }
  }

}
