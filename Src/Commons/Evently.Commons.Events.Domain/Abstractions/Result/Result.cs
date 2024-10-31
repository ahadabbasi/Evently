using System;
using System.Collections.Generic;
using System.Linq;

namespace Evently.Commons.Domain.Abstractions.Result;

public class Result
{
    protected Result(bool success, IEnumerable<Error> errors)
    {
        if(success && errors.Any() || !success && !errors.Any())
        {
            throw new Exception();
        }

        IsSuccess = success;

        Errors = errors;
    }

    public bool IsSuccess { get; protected set; }

    public IEnumerable<Error> Errors { get; protected set; }

    public static Result Success() => new Result(true, new Error[] { });

    public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, new Error[] { });

    public static Result Failure(IEnumerable<Error> errors) => new Result(false, errors);

    public static Result<TValue> Failure<TValue>(IEnumerable<Error> errors) => new Result<TValue>(default, true, errors);

    public static implicit operator Result(Error error) => Failure(new Error[] { error });

    public static implicit operator Result(Error[] errors) => Failure(errors);

    public static implicit operator Result(bool value) => value ? Success() : Error.None;
}

public class Result<TValue> : Result
{
    internal Result(TValue? value, bool success, IEnumerable<Error> errors) : base(success, errors)
    {
        if(success && value == null || !success && value != null)
        {
            throw new Exception();
        }

        Value = value!;
    }

    public TValue Value { get; protected set; }

    public static implicit operator Result<TValue>(TValue? value) =>
        value != null ? Success(value) : Failure<TValue>(new Error[] { Error.NullValue });

    public static implicit operator Result<TValue>(Error error) => Failure<TValue>(new Error[] { error });

    public static implicit operator Result<TValue>(Error[] errors) => Failure<TValue>(errors);
}
