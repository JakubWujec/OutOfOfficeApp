namespace OutOfOfficeWPF.ViewModels
{
    public class LeaveRequestItemViewModel : ViewModelBase
    {
        public string Comment { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Guid Id { get; set; }

        public LeaveRequestItemViewModel(string comment, DateOnly startDate, DateOnly endDate, Guid id)
        {
            this.Comment = comment;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"{this.Comment}";
        }
    }
}
