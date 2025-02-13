class Appointment
{
    // 2D-Array for each minute in the school day stored as [period - 1, minute]
    // where 1 <= period <= 8 and 0 <= minute <= 59
    // False represents minutes that are free
    // True represents minutes that are reserved
    private bool[,] minutes = new bool[8, 60];


    // Returns true if a specific minute in a given period is available for
    // an appointment, otherwise returns false
    // PRE-CONDITIONS: 1 <= period <= 8, 0 <= minute <= 59
    private bool isMinuteFree(int period, int minute)
    {

    }

    // Marks a consecutive block of duration minutes starting from startMinute
    // as reserved within a given period
    // PRE-CONDITIONS: 1 <= period <= 8, 0 <= startMinute <= 59, 1 <= duration <= 60
    private void reserveBlock(int period, int startMinute, int duration)
    {

    }

    // Searches for the earliest available block of duration minutes in the
    // specific period. Return the starting minute of this block if found. If
    // no such block exists, return -1. Use isMinuteFree to check minute availability
    public int findFreeBlock(int period, int duration)
    {

    }

    // Searches for the earliest available block of duration minutes within the
    // period range [startPeriod, endPeriod]. 
    // If an available block is found:
    // - Reserve it using reserveBlock
    // - Return true to indicate a successful booking
    // If no block is found, return false
    public bool makeAppointment(int startPeriod, int endPeriod, int duration)
    {
        
    }
}