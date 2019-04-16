import { Component, OnInit } from '@angular/core';
import { languageData } from './sample02.language.en.json';
import { LanguageService } from 'app/services/language/language.service';

@Component({
  selector: 'app-sample02',
  templateUrl: './sample02.component.html',
  styleUrls: ['./sample02.component.sass']
})
export class Sample02Component implements OnInit {
  fields = {
    field01: "field01",
    field02: "field02"
  };

  constructor(private langSvc: LanguageService) { }

  ngOnInit() {
    const section = this.langSvc.getSection(languageData, "sample02");
    console.log("values: ", section.values);
    for (let field of section.values) {
      console.log("field.name", field.name);
      if (this.fields.hasOwnProperty(field.name)) {
        this.fields[field.name] = field.title;
      }
    }
  }

}
