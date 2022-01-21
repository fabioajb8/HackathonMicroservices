﻿namespace Hackathon.Application.DataTransferObjects
{
    public record EmployeeForUpdateDto
    {
        public string Name { get; init; } = string.Empty;

        public string? Email { get; init; }

        public string? NIF { get; init; }

        public string? Address { get; init; }
    }
}