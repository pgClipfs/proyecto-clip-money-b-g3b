import { UserSignIn } from './../../models/userSignIn.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from 'src/app/services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  signInForm: FormGroup;
  userRegister: UserSignIn;

  constructor(private formBuilder: FormBuilder, private registerService: RegisterService) { }

  ngOnInit(): void {
    this.signInForm = this.formBuilder.group({
      name: new FormControl(null, [Validators.required]),
      surname: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required]),
      passwordRepeat: new FormControl(null, [Validators.required])

    });
  }


  async signIn(){

    this.userRegister = {
      Nombre: this.signInForm.value.name,
      Contraseña: this.signInForm.value.password
    };

    const result = await this.registerService.registerUser(this.userRegister);

    if(result != null)
    {

    }
  }


}
