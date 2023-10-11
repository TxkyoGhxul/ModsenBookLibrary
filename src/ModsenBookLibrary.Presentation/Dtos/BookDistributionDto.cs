﻿using ModsenBookLibrary.Domain.Enums;

namespace ModsenBookLibrary.Presentation.Dtos;

public record BookDistributionDto(
    Guid UserId,
    Guid BookId,
    DateTime TakenAt,
    DateTime ShouldReturnAt,
    BookDistributionStatus Status);

public record CreateBookDistributionDto(Guid UserId, Guid BookId, DateTime ShouldReturnAt);

public record ReturnBookDto(Guid BookId);