using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the time in hh:mm:ss format:");
        string inputTime = Console.ReadLine();

        if (IsValidTimeFormat(inputTime))
        {
            string binaryTime = ConvertToBinaryTime(inputTime);
            Console.WriteLine($"Binary Time: {binaryTime}");
        }
        else
        {
            Console.WriteLine("Invalid time format. Please enter time in hh:mm:ss format.");
        }
    }

    static bool IsValidTimeFormat(string time)
    {
        string[] timeParts = time.Split(':');
        if (timeParts.Length == 3)
        {
            int hours, minutes, seconds;
            if (int.TryParse(timeParts[0], out hours) &&
                int.TryParse(timeParts[1], out minutes) &&
                int.TryParse(timeParts[2], out seconds))
            {
                return hours >= 0 && hours < 24 &&
                       minutes >= 0 && minutes < 60 &&
                       seconds >= 0 && seconds < 60;
            }
        }

        return false;
    }

    static string ConvertToBinaryTime(string inputTime)
    {
        string[] timeParts = inputTime.Split(':');
        int hours = int.Parse(timeParts[0]);
        int minutes = int.Parse(timeParts[1]);
        int seconds = int.Parse(timeParts[2]);

        string binaryHours = ToBinaryString(hours, 5);
        string binaryMinutes = ToBinaryString(minutes, 6);
        string binarySeconds = ToBinaryString(seconds, 6);

        return $"{binaryHours}:{binaryMinutes}:{binarySeconds}";
    }

    static string ToBinaryString(int value, int length)
    {
        return Convert.ToString(value, 2).PadLeft(length, '0');
    }
}
