import { Injectable, isDevMode } from '@angular/core';
import { languageData } from './assets/language.en.json';
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
    return _over.values[section];
  }

  public getSection(langData: any, name: string): any {
    // if dev, post langData to server to update overrides DB
    if (isDevMode()) {
      console.log("getSection: in Dev mode", langData);
    }

    // using languageData from static json file for now.
    // static json will be replaced by web service call for current language.
    const noResults = {values: []};
    let targetList = langData.sections.filter(e => e.name == name);
    if ( !targetList || 0 == targetList.length) {
      return noResults;
    }
    let target = targetList[0];
    let overList = languageData.sections.filter(e => e.name == name);
    if ( !overList || 0 == overList.length) {
      return target;
    }
    let over = overList[0];
    for (let field of target.values) {
      let sourceList = over.values.filter(e => e.name == field.name);
      if (sourceList && 0 != sourceList.length) {
        field.title = sourceList[0].title;
      }
    }
    //console.log("section:", result);
    return target;
  }
}
