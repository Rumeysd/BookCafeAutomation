using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.BookReservations;

public interface IBookReservationAppService : ICrudAppService<
    BookReservationDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookReservationDto>
{
}