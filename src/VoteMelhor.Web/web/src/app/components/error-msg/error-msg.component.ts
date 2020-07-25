import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { FormValidations } from '../form-validations';
// import { NgbdAlertCloseable } from './alert-closeable';

@Component({
  selector: 'app-error-msg',
  templateUrl: './error-msg.component.html',
  styleUrls: ['./error-msg.component.css']
})
export class ErrorMsgComponent implements OnInit {

  // @Input() msgError: string;
  // @Input() showError: boolean;

  @Input() control: FormControl;
  @Input() label: string;
  @Input() formGroup: FormGroup;

  constructor() { }

  ngOnInit(): void {
  }

  get errorMessage() {

    if (this.control != null) {

      for (const proppertyName in this.control.errors) {
        if (this.control.errors.hasOwnProperty(proppertyName) &&
          this.control.touched) {
          return FormValidations.getErrorMsg(this.label, proppertyName, this.control.errors[proppertyName]);
        }
      }
    }

    if (this.formGroup.errors != null) {
      return FormValidations.getErrorMsg(null, 'atLeastOne', null);
    }

    // return null;
  }

}
