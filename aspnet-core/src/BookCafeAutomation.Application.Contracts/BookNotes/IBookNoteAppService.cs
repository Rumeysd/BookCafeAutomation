using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.BookNotes;

public interface IBookNoteAppService : ICrudAppService<
    BookNoteDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookNoteDto>
{
}