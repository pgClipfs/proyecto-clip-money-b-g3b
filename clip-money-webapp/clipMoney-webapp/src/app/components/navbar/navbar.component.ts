import { LoginService } from './../../services/login.service';
import { Component, OnInit } from '@angular/core';
import { UserSignOnModel } from 'src/app/models/userSignOn.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  user: UserSignOnModel;

  constructor(private userLoginService: LoginService) { }

  ngOnInit(): void {
    this.user = this.userLoginService.getCurrentUser();
  }

}
