﻿using System;

namespace EmployeeSelfService.Services.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}
