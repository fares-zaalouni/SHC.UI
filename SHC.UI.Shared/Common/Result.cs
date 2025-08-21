using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.Shared.Common;

public class Result<T>
{
    public bool IsSuccess { get; }
    public ErrorDetail? Error { get; }
    public T? Value { get; }

    private Result(T value)
    {
        IsSuccess = true;
        Value = value;
    }
    private Result(ErrorDetail error)
    {
        IsSuccess = false;
        Error = error;
    }

    public static Result<T> Success(T value) =>
        new Result<T>(value);

    public static Result<T> Failure(ErrorDetail error) =>
        new Result<T>(error);
}
