import { WalletService } from './../../services/wallet.service';
import { TransferModel } from 'src/app/models/transfer.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-transfers',
  templateUrl: './transfers.component.html',
  styleUrls: ['./transfers.component.scss']
})
export class TransfersComponent implements OnInit {

  formTransaction: FormGroup;

  constructor(private formBuilder: FormBuilder,
              private walletService: WalletService,
              private router:Router) { }

  async ngOnInit() {

    this.formTransaction = this.formBuilder.group({
      IdUser: new FormControl(),
      TypeTransaction: new FormControl(),
      Amount: new FormControl()
    })
  }

  async ingresarDinero(){
    const newTransaction: TransferModel = {
      Id_user: 1,
      Transaction_type: 1,
      Amount: this.formTransaction.value.Amount
    }

    await this.walletService.postTransactionUserId(newTransaction);
    this.router.navigate(['lastMovements'])
  }

  async extraerDinero(){
    const newTransaction: TransferModel = {
      Id_user: 1,
      Transaction_type: 2,
      Amount: this.formTransaction.value.Amount
    }

    await this.walletService.postTransactionUserId(newTransaction);
    this.router.navigate(['lastMovements'])
  }

}
