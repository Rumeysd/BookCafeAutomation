using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookCafeAutomation.BookReservations;

public class BookReservationAppService : CrudAppService<
    BookReservation,
    BookReservationDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookReservationDto>, IBookReservationAppService
{
    public BookReservationAppService(IRepository<BookReservation, Guid> repository)
        : base(repository)
    {
    }

    protected override async Task<IQueryable<BookReservation>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .Include(x => x.Book)
            .Include(x => x.Customer);
    }
}