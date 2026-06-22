# Use Case: Timer przerwy

## Opis

Aplikacja odlicza czas do końca przerwy. Co sekundę wywoływana jest metoda `Update()`, która ustawia stan timera i aktualizuje interfejs użytkownika.

## Iteracja 1

Timer startuje z podanym czasem zakończenia i przechodzi między stanami na podstawie pozostałego czasu.

| Pozostały czas | Stan |
|----------------|------|
| brak `EndAt` | Idle |
| > 1 min | Running |
| od 10 s do 1 min włącznie | FinalMinute |
| > 0 s i < 10 s | Critical |
| <= 0 s | Finished |

## Iteracja 2

Każdy stan ma własne zachowanie interfejsu:

| Stan | Zachowanie |
|------|------------|
| Running | zielony kolor |
| FinalMinute | pomarańczowy kolor |
| Critical | czerwony kolor, odliczanie dźwiękowe |
| Finished | dzwonek, napis `KONIEC` |

## Implementacja

```cs
public enum TimerState
{
    Idle,
    Running,
    FinalMinute,
    Critical,
    Finished
}
```

```cs
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
```

## Zadanie

Masz działające testy i monolityczną metodę `Update`.

1. Uruchom testy i upewnij się, że przechodzą.
2. Obserwuj ból: każdy stan ma własne zachowanie, a cała logika jest skupiona w jednej metodzie.

## Pytania do dyskusji

- Co dzieje się z metodą `Update` po dodaniu kolejnego stanu?
- Czy przejścia między stanami i zachowanie UI powinny żyć w jednej metodzie?
- Jak testować zachowanie poszczególnych stanów w izolacji?
- Jak wydzielić stany do osobnych klas?

## Ból

- Każdy stan ma własne zachowanie
- Cała logika jest skupiona w jednej metodzie
- Dodanie nowego stanu wymaga modyfikacji `Update`
- Coraz więcej if-ów

## Wniosek

Wraz ze wzrostem liczby stanów rośnie złożoność metody `Update`.

Testy pozwalają bezpiecznie wydzielić stany do osobnych klas i zarządzać przejściami we wzorcu **State**.
