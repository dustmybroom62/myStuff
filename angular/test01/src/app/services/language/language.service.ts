import { Injectable } from '@angular/core';
import * as _lang from './assets/language.en.json';
import * as _over from './assets/language.en.1.json';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  // private merged: object;
  
  constructor() {
    // this.merged = Object.assign(_lang.values, _over.values);
   }

  public getValues(section: string): any {
    return Object.assign(_lang.values[section], _over.values[section]);
  }
}
