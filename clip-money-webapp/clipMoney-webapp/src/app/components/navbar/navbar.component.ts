import { LoginService } from './../../services/login.service';
import { Component, OnInit } from '@angular/core';
import { UserSignOnModel } from 'src/app/models/userSignOn.model';
import { Router } from '@angular/router';
import { UserTokenModel } from 'src/app/models/userTokenModel.model.ts';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  user: UserTokenModel;
  logged = false;
  constructor(private userLoginService: LoginService,
              private router: Router) { }

  async ngOnInit() {

    this.user = this.userLoginService.getCurrentUser();
  }

  logout(){
      localStorage.removeItem('currentUser');
      this.router.navigate(['login']);
      this.logged = false;
      this.ngOnInit();
    }

    }
