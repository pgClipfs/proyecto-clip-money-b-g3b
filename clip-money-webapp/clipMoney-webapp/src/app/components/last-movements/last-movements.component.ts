import { UserTokenModel } from './../../models/userTokenModel.model.ts';
import { LoginService } from './../../services/login.service';
import { WalletService } from './../../services/wallet.service';
import { TransferService } from './../../services/transfer.service';
import { Component, OnInit } from '@angular/core';
import { TransferModel } from 'src/app/models/transfer.model';
import { TransferTypeModel } from 'src/app/models/transfertype.model';

@Component({
  selector: 'app-last-movements',
  templateUrl: './last-movements.component.html',
  styleUrls: ['./last-movements.component.scss']
})
export class LastMovementsComponent implements OnInit {

  listLastTransfers: Array<TransferModel>;
  funds: number;
  page = 1;
  totalMovements: number
  userLogged: UserTokenModel;


  constructor(private transferService: TransferService,
              private walletService: WalletService,
              private loginService: LoginService) { }

  async ngOnInit() {

    this.userLogged = this.loginService.getCurrentUser()
    this.listLastTransfers = await this.transferService.getTrasnferByUserId(parseInt(this.userLogged.Id));
    this.totalMovements = this.listLastTransfers.length <= 0 ? 0 : this.listLastTransfers.length;
    this.funds = await this.walletService.getFundByUserId(parseInt(this.userLogged.Id));


    this.listLastTransfers.slice(0, 10);
  }
}
