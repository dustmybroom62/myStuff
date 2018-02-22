/**
 * Exercise 5 - TimeHelper (Time to Practice)
 */

public  class Main {
    public static void main(String args[]){
        TimeHelper timeHelper = new TimeHelper(3700);
        System.out.println("3700 inMinutes: " + timeHelper.inMinutes());
        System.out.println("3700 inHours: " + timeHelper.inHours());
        System.out.println(timeHelper);

        timeHelper = new TimeHelper(7320);
        System.out.println("7320 inMinutes: " + timeHelper.inMinutes());
        System.out.println("7320 inHours: " + timeHelper.inHours());
        System.out.println(timeHelper);

    }
}

///**
// * Exercise 4 - Calculator (Time to Practice)
// */
//
//public class Main {
//
//    public static void main(String[] args) {
//        Calculator basic = new Calculator();
//        basic.operate("+", 3);
//        basic.operate("-", 1);
//        basic.operate("*", 15);
//        basic.operate("/", 3);
//
//        Calculator advanced = new Calculator();
//        advanced.firstValue(10); //Assign 10 to result
//        advanced.operate("C"); //Reset result to 0
//        advanced.operate("cos", 0); //Assign cos(0) to result
//        advanced.operate("C"); //Reset result to 0
//        advanced.operate("sin", 1); //Assign sin(0) to result
//        advanced.operate("C"); //Reset result to 0
//        advanced.operate("tan", 0); //Assign tan(0) to result
//        advanced.operate("C"); //Reset result to 0
//        advanced.operate("!", 5); //Assign the value of 5! to result (120)
//        advanced.operate("C"); //Reset result to 0
//        advanced.operate("e"); //Assign the value of "e" to result
//        advanced.operate("+", 1.25);
//        advanced.operate("+", "pi"); //Add the value of pi to result
//
//
//        //Add at least 5 different operations and share your codeboard project in the forum.
//
//    }
//}

/**
 * Main class of the Java program.
 */

//public class Main {
//
//    public static void main(String[] args) {
//        Account alice = new Account("Alice", 100);
//        Account bob = new Account("Bob");
//
//        System.out.println(alice);
//        System.out.println(bob);
//
//        System.out.println(alice.nextAccount);
//        System.out.println(bob.nextAccount);
//        System.out.println(Account.nextAccount);
//
//        System.out.println(alice.withdraw(500));
//        System.out.println(alice.withdraw(50));
//        System.out.println(alice);
//
//    }
//}

/**
 * Exercise 3 - Fix It (Hands-on Work)
 */

//import java.util.Date;
//
//public class Main {
//
//    public static void main(String[] args) {
//        //Date(int year, int month, int date)
//        Date birthDate = new Date(1987,0,22); //Remember to subtract 1 to the month
//        Date expirationDate = new Date(2017,0,13);
//        long id = 1287564540101L;
//        Passport myPassport = new Passport(id, "Conny", "Smith", "Austrian", birthDate, expirationDate, 'F');
//        boolean passportExpired = myPassport.isExpired();
//
//        if (passportExpired == true) {
//            System.out.println("You need to renew your passport");
//        } else {
//            System.out.println("Your passport is still valid");
//        }
//    }
//}
