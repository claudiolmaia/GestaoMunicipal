import { ValidatorFn, AbstractControl } from '@angular/forms';
import { ValidationErrors } from '@angular/forms';
import { CustomValidators } from 'ngx-custom-validators';

export class CustomValidator {

    static cpfLength = 11;
    /**
     * Calcula o dígito verificador do CPF.
     */
    static buildDigit(arr: number[]): number {

        const isCpf = arr.length < CustomValidator.cpfLength;
        const digit = arr
            .map((val, idx) => val * ((!isCpf ? idx % 8 : idx) + 2))
            .reduce((total, current) => total + current) % CustomValidator.cpfLength;

        if (digit < 2 && isCpf) {
            return 0;
        }

        return CustomValidator.cpfLength - digit;
    }

    static cfpValidator (c: AbstractControl): ValidationErrors | null {
            let cpf = c.value;
           
            if (!/^([0-9])*$/.test(cpf)) {
                return { onlyNumber: true };
            }

            cpf = cpf.replace(/\D/g, '');

            if ([CustomValidator.cpfLength].indexOf(cpf.length) < 0) {
                return {length: true };
            }

            if (/^([0-9])\1*$/.test(cpf)) {
                return { equalDigits: true };
            }

            const cpfArr: number[] = cpf.split('').reverse().slice(2).map(x=>+x);
            cpfArr.unshift(CustomValidator.buildDigit(cpfArr));
            cpfArr.unshift(CustomValidator.buildDigit(cpfArr));

            if (cpf !== cpfArr.reverse().join('')) {
                return { digit: true };
            }

            return null;        
    }
}