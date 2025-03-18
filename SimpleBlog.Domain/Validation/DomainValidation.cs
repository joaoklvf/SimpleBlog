namespace SimpleBlog.Domain.Validation;

public class DomainValidation(string error) : Exception(error)
{
    public static void When(bool condition, string errorMessage)
    {
        if (condition)
            throw new DomainValidation(errorMessage);
    }
}
