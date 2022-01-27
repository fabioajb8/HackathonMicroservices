﻿namespace Hackathon.Application.Interfaces.Logger
{
   public interface ILoggerManager
    {
        void LogTrace(string message);

        void LogDebug(string message);

        void LogInformation(string message);

        void LogWarning(string message);

        void LogError(string message);

    }
}