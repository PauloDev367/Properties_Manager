﻿using System.Text.Json;

namespace Api.ViewModels;

public class ErrorDetailsVM
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}
