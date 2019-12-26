import { TestBed } from '@angular/core/testing';
import { LanguageService } from './language.service';
describe('LanguageService', function () {
    beforeEach(function () { return TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = TestBed.get(LanguageService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=language.service.spec.js.map