namespace BreakTimer;

public class BreakTimer
{
    public DateTime? EndAt { get; private set; }

    public TimerState State { get; private set; }

    public string Color { get; private set; } = string.Empty;

    public string Label { get; private set; } = string.Empty;

    public int CountdownSoundCount { get; private set; }

    public int BellCount { get; private set; }

    public void Start(DateTime endAt)
    {
        EndAt = endAt;

        State = TimerState.Running;
    }

    public void Update()
    {
        if (EndAt == null)
        {
            State = TimerState.Idle;
            return;
        }

        var remaining = EndAt.Value - DateTime.UtcNow;

        if (remaining <= TimeSpan.Zero)
        {
            State = TimerState.Finished;
        }
        else if (remaining < TimeSpan.FromSeconds(10))
        {
            State = TimerState.Critical;
        }
        else if (remaining <= TimeSpan.FromMinutes(1))
        {
            State = TimerState.FinalMinute;
        }
        else
        {
            State = TimerState.Running;
        }

        if (State == TimerState.Running)
        {
            Color = "Green";
            Label = string.Empty;
        }
        else if (State == TimerState.FinalMinute)
        {
            Color = "Orange";
            Label = string.Empty;
        }
        else if (State == TimerState.Critical)
        {
            Color = "Red";
            Label = string.Empty;
            CountdownSoundCount++;
        }
        else if (State == TimerState.Finished)
        {
            Label = "KONIEC";
            BellCount++;
        }
    }

    public void Reset()
    {
        EndAt = null;
        State = TimerState.Idle;
        Color = string.Empty;
        Label = string.Empty;
        CountdownSoundCount = 0;
        BellCount = 0;
    }
}
