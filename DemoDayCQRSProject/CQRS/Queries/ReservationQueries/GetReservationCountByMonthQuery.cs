namespace DemoDayCQRSProject.CQRS.Queries.ReservationQueries
{
    public class GetReservationCountByMonthQuery
    {
        public int Year { get; set; }

        public GetReservationCountByMonthQuery(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public int Month { get; set; }
    }
}
