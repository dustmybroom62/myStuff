import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
import { languageData } from './sample01.language.en.json';
import { LanguageService } from 'app/services/language/language.service';
var Sample01Component = /** @class */ (function () {
    function Sample01Component(langSvc) {
        this.langSvc = langSvc;
        this.fields = {
            field01: "field01",
            field02: "field02"
        };
    }
    Sample01Component.prototype.ngOnInit = function () {
        var section = this.langSvc.getSection(languageData.sections.sample01);
        this.fields.field01 = section.values.field01.title;
        // this.fields.field02 = section.values.field02.title;
    };
    Sample01Component = tslib_1.__decorate([
        Component({
            selector: 'app-sample01',
            templateUrl: './sample01.component.html',
            styleUrls: ['./sample01.component.sass']
        }),
        tslib_1.__metadata("design:paramtypes", [LanguageService])
    ], Sample01Component);
    return Sample01Component;
}());
export { Sample01Component };
//# sourceMappingURL=sample01.component.js.map