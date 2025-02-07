﻿using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Commands.GameDeckCommands;

public class CreateDeckCommand : IRequest<int>
{
    public string? Name { get; init; }
    
    public GameType GameType { get; init; }
}
