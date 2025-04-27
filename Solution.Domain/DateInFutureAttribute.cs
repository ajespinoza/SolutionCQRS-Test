using System.ComponentModel.DataAnnotations;

namespace Solution.Domain
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> _datetimeNowProvider;

        public DateInFutureAttribute() : this(() => DateTime.Now) { }
        public DateInFutureAttribute(Func<DateTime> datetimeNowProvider)
        {
            _datetimeNowProvider = datetimeNowProvider;
            ErrorMessage = "La fecha debe ser del futuro";
        }

        public override bool IsValid(object? value)
        {
            bool isValid = false;
            if(value is DateTime datetime)
            {
                isValid = datetime > _datetimeNowProvider();
            }
            return isValid;
        }
    }
}
