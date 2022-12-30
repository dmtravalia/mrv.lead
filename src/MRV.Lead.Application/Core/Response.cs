using FluentValidation.Results;
using System.Collections.Generic;

namespace MRV.Lead.Application.Core;

public class Response
{
    private readonly List<ValidationFailure> _validationFailure = new List<ValidationFailure>();
    public bool IsValid => _validationFailure.Count == 0;
    public List<ValidationFailure> Error => _validationFailure;

    public Response AddError(ValidationFailure message)
    {
        _validationFailure.Add(message);
        return this;
    }

    public static Response AddError(List<ValidationFailure> errors)
    {
        var response = new Response();
        errors.ForEach(error => response.AddError(error));
        return response;
    }

    public static Response None() => new Response();
}