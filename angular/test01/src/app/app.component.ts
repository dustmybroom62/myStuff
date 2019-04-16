import { Component } from '@angular/core';
import { LanguageService } from './services/language/language.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'test01';
  welcome; welcome2;
  links; links2;
  constructor(private lang: LanguageService ) {
    let _lang = lang.getValues("section01");
    this.welcome = _lang.welcome;
    this.links = _lang.links;

    _lang = lang.getValues("section02");
    this.welcome2 = _lang.welcome;
    this.links2 = _lang.links;

  }
}
