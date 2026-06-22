namespace BreakTimer.Tests;

public class BreakTimerTests
{
    private readonly global::BreakTimer.BreakTimer _timer = new();

    [Fact]
    public void Update_WhenNotStarted_SetsIdleState()
    {
        _timer.Update();

        Assert.Equal(TimerState.Idle, _timer.State);
    }

    [Fact]
    public void Update_WhenMoreThanOneMinuteRemaining_SetsRunningState()
    {
        _timer.Start(DateTime.UtcNow.AddMinutes(5));

        _timer.Update();

        Assert.Equal(TimerState.Running, _timer.State);
    }

    [Fact]
    public void Update_WhenOneMinuteRemaining_SetsFinalMinuteState()
    {
        _timer.Start(DateTime.UtcNow.AddMinutes(1));

        _timer.Update();

        Assert.Equal(TimerState.FinalMinute, _timer.State);
    }

    [Fact]
    public void Update_WhenThirtySecondsRemaining_SetsFinalMinuteState()
    {
        _timer.Start(DateTime.UtcNow.AddSeconds(30));

        _timer.Update();

        Assert.Equal(TimerState.FinalMinute, _timer.State);
    }

    [Fact]
    public void Update_WhenLessThanTenSecondsRemaining_SetsCriticalState()
    {
        _timer.Start(DateTime.UtcNow.AddSeconds(9));

        _timer.Update();

        Assert.Equal(TimerState.Critical, _timer.State);
    }

    [Fact]
    public void Update_WhenTimeIsUp_SetsFinishedState()
    {
        _timer.Start(DateTime.UtcNow.AddSeconds(-1));

        _timer.Update();

        Assert.Equal(TimerState.Finished, _timer.State);
    }

    [Fact]
    public void Reset_ClearsTimerState()
    {
        _timer.Start(DateTime.UtcNow.AddMinutes(5));
        _timer.Update();

        _timer.Reset();

        Assert.Null(_timer.EndAt);
        Assert.Equal(TimerState.Idle, _timer.State);
    }

    [Fact]
    public void Update_WhenRunning_SetsGreenColor()
    {
        _timer.Start(DateTime.UtcNow.AddMinutes(5));

        _timer.Update();

        Assert.Equal("Green", _timer.Color);
    }

    [Fact]
    public void Update_WhenFinalMinute_SetsOrangeColor()
    {
        _timer.Start(DateTime.UtcNow.AddSeconds(30));

        _timer.Update();

        Assert.Equal("Orange", _timer.Color);
    }

    [Fact]
    public void Update_WhenCritical_SetsRedColorAndPlaysCountdownSound()
    {
        _timer.Start(DateTime.UtcNow.AddSeconds(5));

        _timer.Update();

        Assert.Equal("Red", _timer.Color);
        Assert.Equal(1, _timer.CountdownSoundCount);
    }

    [Fact]
    public void Update_WhenFinished_RingsBellAndShowsKoniecLabel()
    {
        _timer.Start(DateTime.UtcNow.AddSeconds(-1));

        _timer.Update();

        Assert.Equal("KONIEC", _timer.Label);
        Assert.Equal(1, _timer.BellCount);
    }

    [Fact]
    public void Update_WhenCriticalCalledTwice_IncrementsCountdownSoundCount()
    {
        _timer.Start(DateTime.UtcNow.AddSeconds(5));

        _timer.Update();
        _timer.Update();

        Assert.Equal(2, _timer.CountdownSoundCount);
    }
}
