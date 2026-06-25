namespace CreateOrder;

public interface ActionResult { }

public class CreatedResult<T> : ActionResult
{
    public CreatedResult(T value)
    {
        Value = value;
    }

    public T Value { get; }
}

public class OkResult : ActionResult
{

}
