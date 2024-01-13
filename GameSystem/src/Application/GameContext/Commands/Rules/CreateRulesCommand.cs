﻿using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Commands.Rules;

public class CreateRulesCommand : IRequest<int>
{
    public int Players { get; init; }
    
    public WinningCondition WinningCondition { get; init; }
    
    public int CardsDrawnPerTurn { get; init; }
    
    public int CardsDrawnInitially { get; init; }
    
    public int CardsPlayedPerTurn { get; init; }

    public int CardsHandLimit { get; init; }
}
