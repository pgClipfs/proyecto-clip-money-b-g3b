import { OpenTurnModel } from './../../models/openTurnModel.model.ts';
import { OpenTurnService } from '../../services/openTurn.service';
import { TransferModel } from './../../models/transfer.model';
import { UserTokenModel } from './../../models/userTokenModel.model.ts';
import { AlertService } from './../../services/alert.service';
import { TransferMoneyModel } from './../../models/transferMoneyModel.model.ts';
import { UserTranserModel } from './../../models/UserTranser.model.ts';
import { WalletService } from './../../services/wallet.service';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-my-movements',
  templateUrl: './my-movements.component.html',
  styleUrls: ['./my-movements.component.scss']
})
export class MyMovementsComponent implements OnInit {

  active = 1;
  tranferMoney: TransferMoneyModel;
  openTurn: OpenTurnModel = null;
  transferForm: FormGroup;
  userTransfer: UserTranserModel = {NombreUsuario: '', Cvu: 0};
  user: UserTokenModel;
  isOk: boolean;
  montoGiro: number;
  funds: number;
  giro: boolean = false;

  @ViewChild("myModalInfo", {static: false}) myModalInfo: TemplateRef<any>;
  @ViewChild("myModalConf", {static: false}) myModalConf: TemplateRef<any>;

  constructor(private walletService: WalletService,
              private formBuilder: FormBuilder,
              private userLoginService: LoginService,
              private router: Router,
              private alert: AlertService,
              private modalService: NgbModal,
              private openTurnService: OpenTurnService) { }

  async ngOnInit() {
    this.transferForm = this.formBuilder.group({
      cvuNumber: new FormControl(null, [Validators.required]),
      mount: new FormControl(null),
      countOwner: new FormControl(null)
    });
    this.user = this.userLoginService.getCurrentUser();

    this.funds = await this.walletService.getFundByUserId(parseInt(this.user.Id));
    this.openTurn = await this.openTurnService.getOpenTurnByUserId(parseInt(this.user.Id));
    console.log(this.openTurn);
  }

  async transferMoney(){
    this.tranferMoney = {
      Cvu: this.transferForm.value.cvuNumber,
      Mount: this.transferForm.value.mount,
      OwnerUser: this.user.NombreUsuario
    }
    this.isOk = await this.walletService.transferToUser(this.tranferMoney);
    if(this.isOk === true)
    {
      this.alert.ShowConfirmation('Transferencia', 'Transferencia exitosa!', 'Ok', false, '');
      this.modalService.dismissAll();
      this.router.navigate(['lastMovements']);
    }
    else{
      this.alert.alertError("No ha podido realizarse la transferencia");
    }
  }

  async mostrarModalInfo(){
    const numberCvu = this.transferForm.value.cvuNumber == null ? 0: this.transferForm.value.cvuNumber;
    this.userTransfer = await this.walletService.getUserByCvu(numberCvu);
    if(this.userTransfer !== null)
    {
      this.modalService.open(this.myModalInfo).result.then(r => {
        if(r === 'save')
        {
          this.transferMoney();
        }
      });
    }
    else{
      this.alert.alertError("CVU inexistente");
    }
  }

  calcularMontoGiro(){
    if(this.funds > 0)
    {
      this.giro = true;
      this.montoGiro = Math.trunc(10/100 * this.funds);
      return '$' + (this.montoGiro).toString();
    }
    this.giro = false;
    return "No puede realizar la operacion su saldo es negativo"

  }

  girarAlDescubierto(){
    const OpenTurn: TransferModel = {
      Id_user: parseInt(this.user.Id),
      Transaction_type: 2002,
      Amount: Math.trunc(10/100 * this.funds)
    }
    this.walletService.OpenTurn(OpenTurn)
    this.alert.ShowConfirmation("Giro Bancario", "transaccion exitosa", "Ok", false, "");
    this.router.navigate(['lastMovements']);
  }

}
