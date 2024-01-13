﻿namespace GameSystem.Domain.Entities;

public class Rules: BaseAuditableEntity
{
    public int Players { get; init; }
    
    public WinningCondition WinningCondition { get; init; }
    
    public int CardsDrawnPerTurn { get; init; }
    
    public int CardsDrawnInitially { get; init; }
    
    public int CardsPlayedPerTurn { get; init; }

    public int CardsHandLimit { get; init; }
}
