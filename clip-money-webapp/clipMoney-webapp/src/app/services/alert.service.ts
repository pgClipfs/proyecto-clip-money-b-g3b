import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

constructor() { }

async alertError(error: string){
  const res = await Swal.fire({
    html: error,
    reverseButtons: true,
    confirmButtonColor: 'theme_color{"primary"}',
    confirmButtonText: 'Ok',
    showCancelButton: false,
    cancelButtonColor: 'theme_color{"warning"}',
    customClass: {
      popup: 'popup-modal',
      cancelButton: 'popup-showCancel-btn',
      confirmButton: 'popup-showConfirm-btn',
      content: 'popup-content',
      title: 'popup-title',
      icon: 'popup-icon'
    }
  });
  return res.value;

}

async ShowConfirmation(title: string, text: string, textButtonConfirm: string, showCancelButton: boolean, textButtonCancel: string){
  const res = await Swal.fire({
    title: title,
    html: text,
    reverseButtons: true,
    confirmButtonColor: '#005D83',
    confirmButtonText: textButtonConfirm,
    showCancelButton: showCancelButton,
    cancelButtonColor: '#F9B047',
    cancelButtonText: textButtonCancel,
    customClass: {
      popup: 'popup-modal',
      cancelButton: 'popup-showCancel-btn',
      confirmButton: 'popup-showConfirm-btn',
      content: 'popup-content',
      title: 'popup-title'
    },

  });
  return res.value;
}

}
