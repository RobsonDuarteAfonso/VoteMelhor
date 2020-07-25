import { FormGroup, ValidatorFn, ValidationErrors } from '@angular/forms';

export class FormValidations {

  static atLeastOne = () => {
    return (group: FormGroup) => {
      if (!Object.values(group.value).find(value => value !== null && value !== '')) {
        return { message: 'Please input at least one value' };
      }
      return null;
    };
  }


  static getErrorMsg(fieldName?: string, validatorName?: string, validatorValue?: any) {

    let config;

    if (fieldName != null) {
      config = {
        'required': `${fieldName} é obrigatório.`,
        'minlength': `${fieldName} precisa ter no mínimo ${validatorValue.requiredLength} caracteres.`,
        'maxlength': `${fieldName} precisa ter no máximo ${validatorValue.requiredLength} caracteres.`
      };
    } else {
      config = {
        'atLeastOne': 'É necessário informar um campo.'
      };

    }

    return config[validatorName];
  }
}
