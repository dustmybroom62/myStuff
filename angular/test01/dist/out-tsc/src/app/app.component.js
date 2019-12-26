import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { LanguageService } from './services/language/language.service';
var AppComponent = /** @class */ (function () {
    function AppComponent(lang) {
        this.lang = lang;
        this.title = 'test01';
        var _lang = lang.getValues("section01");
        this.welcome = _lang.welcome;
        this.links = _lang.links;
        _lang = lang.getValues("section02");
        this.welcome2 = _lang.welcome;
        this.links2 = _lang.links;
    }
    AppComponent = tslib_1.__decorate([
        Component({
            selector: 'app-root',
            templateUrl: './app.component.html',
            styleUrls: ['./app.component.sass']
        }),
        tslib_1.__metadata("design:paramtypes", [LanguageService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map