import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import * as _lang from './assets/language.en.json';
import * as _over from './assets/language.en.1.json';
var LanguageService = /** @class */ (function () {
    // private merged: object;
    function LanguageService() {
        // this.merged = Object.assign(_lang.values, _over.values);
    }
    LanguageService.prototype.getValues = function (section) {
        return Object.assign(_lang.values[section], _over.values[section]);
    };
    LanguageService.prototype.getSection = function (section) {
        return section;
    };
    LanguageService = tslib_1.__decorate([
        Injectable({
            providedIn: 'root'
        }),
        tslib_1.__metadata("design:paramtypes", [])
    ], LanguageService);
    return LanguageService;
}());
export { LanguageService };
//# sourceMappingURL=language.service.js.map