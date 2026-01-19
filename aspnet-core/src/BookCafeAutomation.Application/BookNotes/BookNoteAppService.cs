using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookCafeAutomation.BookNotes;

public class BookNoteAppService : CrudAppService<
    BookNote,
    BookNoteDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookNoteDto>, IBookNoteAppService
{
    public BookNoteAppService(IRepository<BookNote, Guid> repository)
        : base(repository)
    {
    }

    protected override async Task<IQueryable<BookNote>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .Include(x => x.Book); 
    }
}