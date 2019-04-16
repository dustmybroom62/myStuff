import { Component, OnInit } from '@angular/core';
import { languageData } from './sample01.language.en.json';
import { LanguageService } from 'app/services/language/language.service';

@Component({
  selector: 'app-sample01',
  templateUrl: './sample01.component.html',
  styleUrls: ['./sample01.component.sass']
})
export class Sample01Component implements OnInit {
  fields = {
    field01: "field01",
    field02: "field02"
  };

  constructor(private langSvc: LanguageService) { }

  ngOnInit() {
    const section = this.langSvc.getSection(languageData, "sample01");
    console.log("values: ", section.values);
    for (let field of section.values) {
      console.log("field.name", field.name);
      if (this.fields.hasOwnProperty(field.name)) {
        this.fields[field.name] = field.title;
      }
    }
  }

}
