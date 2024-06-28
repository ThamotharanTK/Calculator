namespace Calculator.ViewModels
{
    public class EvaluateResultModel
    {
        public bool Succeeded { get; set; }
        public double? Result { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
