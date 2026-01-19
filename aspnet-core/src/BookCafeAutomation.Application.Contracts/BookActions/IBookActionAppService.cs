using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookCafeAutomation.BookActions;

public interface IBookActionAppService : ICrudAppService<
    BookActionDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookActionDto>
{
}