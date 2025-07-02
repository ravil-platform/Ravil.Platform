using ClosedXML.Excel;
using Domain.Entities.Histories.Enums;

namespace Persistence.Entities.Histories.Repositories;

public class ActionHistoriesRepository : Repository<ActionHistories>, IActionHistoriesRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }

    internal ActionHistoriesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<byte[]> ExportDataToExcel()
    {
        // دریافت داده‌ها از جدول ActionHistories
        var actionHistories = await ApplicationDbContext.ActionHistories.ToListAsync();

        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("ActionHistories");

        // Header
        worksheet.Cell(1, 1).Value = "user_id";
        worksheet.Cell(1, 2).Value = "job_id";
        worksheet.Cell(1, 3).Value = "rated";
        worksheet.Cell(1, 4).Value = "timestamp";

        worksheet.Cell(1, 5).Value = "shared";
        worksheet.Cell(1, 6).Value = "liked";
        worksheet.Cell(1, 7).Value = "bookmarked";

        int row = 2;
        int index = 1;

        foreach (var action in actionHistories)
        {
            var userPhoneNumber = await ApplicationDbContext.ApplicationUser.AsNoTracking()
                .Where(u => u.Id == action.UserId)
                .Select(u => u.UserName).SingleOrDefaultAsync();

            if (userPhoneNumber == null) continue;

            worksheet.Cell(row, 1).Value = userPhoneNumber;
            worksheet.Cell(row, 2).Value = action.JobId;
            worksheet.Cell(row, 3).Value = Strings.RandomRateGenerator();
            worksheet.Cell(row, 4).Value = action.Time;

            int shared = 0;
            int liked = 0;
            int bookmarked = 0;

            if (ActionType.JobPageView.GetEnumDisplayName() == action.ActionType)
            {
                shared = 0;
                liked = 1;
                bookmarked = 0;
            }
            else if (ActionType.ShareAction.GetEnumDisplayName() == action.ActionType 
                     || ActionType.ClickOnCall.GetEnumDisplayName() == action.ActionType)
            {
                shared = 1;
                liked = 0;
                bookmarked = 0;
            }
            else if (ActionType.MarkAction.GetEnumDisplayName() == action.ActionType)
            {
                shared = 0;
                liked = 0;
                bookmarked = 1;
            }

            worksheet.Cell(row, 5).Value = shared;
            worksheet.Cell(row, 6).Value = liked;
            worksheet.Cell(row, 7).Value = bookmarked;
            row++;
        }

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
}
