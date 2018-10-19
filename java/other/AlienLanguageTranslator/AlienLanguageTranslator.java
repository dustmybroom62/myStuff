public class AlienLanguageTranslator {
    private char _a = 'a';
    private char _A = 'A';
    private char _z = 'z';
	private char _Z = 'Z';
	private char lim = 26;
    private int _offset = 3;
    
	public String DEFAULT_TRANSLATION = "EN";
	
	// Translates the language from default language
	public String translate(String languageTokens, int offset) {
	    String result = "";
	    for (int i = 0; i < languageTokens.length(); i++) {
			char base = 0;
	        char c = languageTokens.charAt(i);
	        if (_a <= c && c <= _z) {
	            base = _a;
	        } else if (_A <= c && c <= _Z) {
	            base = _A;
	        }
	        if (0 == base) {
	            result += Character.toString(c);
	        } else {
	            result += Character.toString( (char)(((c - base + offset + lim) % lim) + base) );
	        }
        }
        return result;
	}

	public String fromDefaultLanguage(String languageTokens) {
		return translate(languageTokens, _offset);
	}	
	// Translates the language to default language
	public String toDefaultLanguage(String languageTokens) {
	    return translate(languageTokens, _offset * -1);
	}
}

public class AlienLanguageTranslatorTest{
    public static void main(String args[]){
		AlienLanguageTranslator at = new AlienLanguageTranslator();
		String x = at.fromDefaultLanguage("To day");
		System.out.println("alien: " + x);
		System.out.println("default: " + at.toDefaultLanguage(x));
	}
}