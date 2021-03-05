using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LoggingEventType { Debug, Information, Warning, Error, Fatal };
public interface ILogger
{
    void Log(LogEntry entry);
}

public class LogEntry
{
    public readonly LoggingEventType Severity;
    public readonly string Message;
    public readonly Exception Exception;

    public LogEntry(string message, LoggingEventType severity, Exception exception = null)
    {
        if (message == null) throw new ArgumentNullException("message");
        if (message == string.Empty) throw new ArgumentException("empty", "message");

        this.Severity = severity;
        this.Message = message;
        this.Exception = exception;
    }
}

public static class LoggerExtensions
{
    public static void Log(this ILogger logger, string message)
    {
        logger.Log(new LogEntry(message, LoggingEventType.Information));
    }
    public static void Log(this ILogger logger, string message, LoggingEventType loggingEventType)
    {
        logger.Log(new LogEntry(message, loggingEventType));
    }

    public static void Log(this ILogger logger, string message, LoggingEventType loggingEventType, Exception exception)
    {
        logger.Log(new LogEntry(message, loggingEventType, exception));
    }

    public static void Log(this ILogger logger, Exception exception)
    {
        logger.Log(new LogEntry(exception.Message, LoggingEventType.Error, exception));
    }

    public static void Log(this ILogger logger, Exception exception, LoggingEventType loggingEventType)
    {
        logger.Log(new LogEntry(exception.Message, LoggingEventType.Information, exception));
    }

    // More methods here.
}
