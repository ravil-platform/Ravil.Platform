namespace Persistence.Entities.Histories.Repositories
{
    public interface IActionHistoriesRepository : IRepository<ActionHistories>
    {
        /// <summary>
        /// generate an excel file from action histories table
        /// </summary>
        /// <returns>excel file</returns>
        Task<byte[]> ExportDataToExcel();
    }
}
