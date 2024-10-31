namespace Evently.Commons.Domain.Abstractions.Result;

public record Error
{
    public static readonly Error None = string.Empty;

    public static readonly Error NullValue = "General.Null";

    public Error(string code) : this(code, null)
    { 
    }

    public Error(string code, string? description)
    {
        Code = code;

        Description = description;
    }

    public string Code { get; }

    public string? Description { get; }

    public static Error NotFound<TKey>(string code, TKey value) => (code, string.Format("The entity with the identifier `{0}` was not found", value));

    public static implicit operator Error(string code) => (code, null);

    public static implicit operator Error((string code, string? description) value) => new(value.code, value.description);
}
