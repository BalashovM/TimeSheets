namespace TimeSheets.Infrastructure.Validation
{
    public static class ValidationMessages
    {
        public const string SheetAmountError = "Amount should be between 1 and 8 hours.";
        public const string RequestDateStartError = "Start date should be less than or eqaul to the end date.";
        public const string RequestDateEndError = "End date should be greather than or eqaul to the start date.";
        public const string InvalidValue = "Incorrect value";

    }
}
