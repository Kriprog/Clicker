namespace Blazorclicker;
using System.Timers;
using System;

public class CounterService
{
    private int _count;
    private readonly Timer _timer;

        public CounterService()
    {
        _count = 0;
        _timer = new Timer(1000); // Timer set for 1 second intervals
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = true; // The timer will continue to run every second
        _timer.Start(); // Start the timer
    }

    public int Count => _count;

    public void IncrementCount()
    {
        _count++;
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        IncrementCount();
    }
}
