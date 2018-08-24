import java.util.Scanner;

public class TripPlanner {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);
        doGreeting(input);
        printSeperator();
        doTravelTimeAndBudget(input);
        printSeperator();
        doTimeDifference(input);
        printSeperator();
        doCountryArea(input);
        printSeperator();
    }

    private static void doCountryArea(Scanner input) {
        System.out.print("What is the square area of your destination country in km2? ");
        double km2 = input.nextDouble();
        double mi2 = .3861 * km2;
        System.out.println("In miles2 that is " + fmtNum(mi2));
    }

    private static void doTimeDifference(Scanner input) {
        System.out.print("What is the time difference, in hours, between your home and your destination? ");
        int dt = input.nextInt();
        int dtNoon = (12 + dt) % 24;
        int dtMid = (0 + dt) % 24;
        System.out.println("That means that when it is midnight at home it will be " + dtMid + ":00 in your travel destination");
        System.out.println("and when it is noon at home it will be " + dtNoon + ":00");
    }

    private static void printSeperator() {
        System.out.println("***********");
        System.out.println();
    }

    private static double fmtNum(double num) {
        double shiftOne = 100 * num;
        return ((int) shiftOne) / 100.0;
    }

    private static void doTravelTimeAndBudget(Scanner input) {
        System.out.print("How many days are you going to spend travelling? ");
        double days = input.nextDouble();
        System.out.print("How much money, in USD, are you planning to spend on your trip? ");
        double usd = input.nextDouble();
        System.out.print("What is the three letter currency symbol for your travel destination? ");
        String destCurrency = input.next();
        System.out.print("How many " + destCurrency + " are there in 1 USD? ");
        double xchRate = input.nextDouble();
        double hours = 24 * days;
        double minutes = 60 * hours;
        double usdPerDay = usd / days;
        double xch = usd * xchRate;
        double xchPerDay = xch / days;
        System.out.println();
        System.out.println("If you are travelling for " + days + " days" +
            " that is the same as " + hours + " hours" +
            " or " + minutes + " minutes.");
        System.out.println("If you are going to spend $" + usd + " USD" +
            " that means per day you can spend up to $" + fmtNum(usdPerDay) + " USD.");
        System.out.println("Your total budget in " + destCurrency + " is " + xch + " " + destCurrency +
            ", which per day is " + fmtNum(xchPerDay) + " " + destCurrency);
    }

    private static void doGreeting(Scanner input) {
        System.out.println("Welcome to Vacation Planner!");
        System.out.print("What is your name? ");
        String name = input.nextLine();
        System.out.print("Nice to meet you " + name);
        System.out.print(", where are you travelling to? ");
        String destination = input.nextLine();
        System.out.println("Great! " + destination + " sounds like a great trip.");
    }
}
