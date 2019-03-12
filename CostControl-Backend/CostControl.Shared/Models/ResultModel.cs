using CostControl.Shared.Enums;

namespace CostControl.Shared.Models
{
    public class ResultModel
    {
        public EResultStatus Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
