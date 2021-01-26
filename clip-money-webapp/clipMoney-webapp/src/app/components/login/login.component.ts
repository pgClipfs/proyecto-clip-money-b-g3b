import { AlertService } from './../../services/alert.service';
import { LoginService } from './../../services/login.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserSignOnModel } from 'src/app/models/userSignOn.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {


  signOnForm: FormGroup;
  userLogin: UserSignOnModel;

  constructor(private formBuilder: FormBuilder,
              private loginService: LoginService,
              private alertService: AlertService,
              private router: Router){ }

  async ngOnInit() {
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
      const result = await this.loginService.loginUser(this.userLogin);

      if(result.Token != null)
      {
        this.loginService.setCurrentUser(result.Token)
        this.router.navigateByUrl('/home');
      }

      else{
        this.alertService.alertError("Ha ocurrido un error al intentar loguearse");
      }

  }

}
