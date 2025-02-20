class Appointment
{
    // 2D-Array for each minute in the school day stored as [period - 1, minute]
    // where 1 <= period <= 8 and 0 <= minute <= 59
    // False represents minutes that are free
    // True represents minutes that are reserved
    private bool[,] schedule = new bool[8, 60];

    // Constructor for intializing the schedule to be completely free
    public Appointment()
    {
        Random rand = new Random();

        for (int period = 0; period < 8; period++) // Goes through all 8 periods
      {
        int minute = 0;
        
        while (minute < 60) // Loops until 60 mins is reached
        {
            // This decides the length of the block randomly (1-21 in this case.)
            int blockLength = rand.Next(1,21);

               // Prevents from going over 60 mins
               if (minute + blockLength > 60 ) 
               {
                  blockLength = 60 - minute;
               }
             
               // Determines wether the block is true or false
               bool isReserved = rand.Next(2) == 1; // 50% 

               // Applies the next block
               for (int i = 0; i < blockLength; i++)
               {
                   schedule [period, minute + i] = isReserved;
               }
              
               // Moves the next block
               minute += blockLength;
            }
        }
    }

    // Returns true if a specific minute in a given period is available for
    // an appointment, otherwise returns false
    // PRE-CONDITIONS: 1 <= period <= 8, 0 <= minute <= 59
    private bool isMinuteFree(int period, int minute)
    {
        return !schedule[period -1, minute];
    }

    // Marks a consecutive block of duration minutes starting from startMinute
    // as reserved within a given period
    // PRE-CONDITIONS: 1 <= period <= 8, 0 <= startMinute <= 59, 1 <= duration <= 60
    private void reserveBlock(int period, int startMinute, int duration)
    {
        for (int i = startMinute; i < startMinute + duration; i++)
        {
            schedule[period - 1, i] = true;
        }
    }

    // Searches for the earliest available block of duration minutes in the
    // specific period. Return the starting minute of this block if found. If
    // no such block exists, return -1. Use isMinuteFree to check minute availability
    public int findFreeBlock(int period, int duration)
    {
        int startMinute = 0;
        bool found = false;
        while (!found && startMinute < 60 - duration)
        {
            // Skip iterations where the current starting minute is not free
            if (!isMinuteFree(period, startMinute))
            {
                startMinute++;
                continue;
            }

            // Check for continuous block of available minutes
            int lastMinuteChecked = startMinute;
            for (int currentMinute = startMinute; currentMinute < startMinute + duration; currentMinute++)
            {
                // End check if a not free minute is found
                // Move start minute to the next minute after the not free minute
                if (!isMinuteFree(period, currentMinute))
                {
                    startMinute = currentMinute + 1;
                    break;
                }

                // All minutes in the range are free
                if (currentMinute == startMinute + duration - 1)
                    found = true;
            }
        }

        if (found)
            return startMinute;

        return -1;
    }

    // Searches for the earliest available block of duration minutes within the
    // period range [startPeriod, endPeriod]. 
    // If an available block is found:
    // - Reserve it using reserveBlock
    // - Return true to indicate a successful booking
    // If no block is found, return false
    public bool makeAppointment(int startPeriod, int endPeriod, int duration)
    {
        for (int period = startPeriod; period <= endPeriod; period++)
        {
            int startMinute = findFreeBlock(period, duration);
            if (startMinute != -1)
            {
                reserveBlock(period, startMinute, duration);
                return true;
            }
        }
        return false;
    }
}
