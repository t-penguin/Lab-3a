using System;

class Program {

    static void Main() {
        Console.WriteLine("Testing Appointment Schedule...\n");

        Appointment app = new Appointment();

        //Testing for a free block of 10 mins in Period 3
        int testPeriod = 3;
        int testDuration = 10;
        int freeMinute = app.findFreeBlock(testPeriod, testDuration);
        Console.WriteLine($"\nEarliest available {testDuration}-minute block in Period {testPeriod}: {freeMinute}");

        //Testing for making an appointment of 15 mins from period 2 to 5 
        bool appointmentMade = app.makeAppointment(2, 5, 15);
        Console.WriteLine($"\nAppointment booking from Period 2 to 5 (15 min): {appointmentMade}");
    }
}