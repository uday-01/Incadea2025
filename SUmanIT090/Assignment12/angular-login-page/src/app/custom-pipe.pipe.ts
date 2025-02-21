import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'maskEmail',
  pure :false
})
export class CustomPipePipe implements PipeTransform {

  transform(value: string | null): string {
    if (!value ) return '';

    const maskedPart = '***';
    
  
    if (value.includes('@')) {
      const [firstPart, domain] = value.split('@');
      return firstPart.charAt(0) + maskedPart + '@' + domain;
    }

    // If @ doesn't exist,  we will mask only the first part
    return value.charAt(0) + maskedPart;
  }
}
// this file contains the coode for the custom pipe that i have defined