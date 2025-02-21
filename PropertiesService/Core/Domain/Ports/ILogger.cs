﻿using System;

namespace Domain.Ports;

public interface ILogger
{
    public void LogInfo(string message);
    public void LogError(string message, Exception ex);
}
