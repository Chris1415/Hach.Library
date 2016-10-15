using Hach.Library.Extensions;
using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Text.Implementation
{
    public class ExactMatchService : IExactMatchService
    {
        public StringComparisonModel CompareStrings(string first, string second)
        {
            return new StringComparisonModel()
            {
                IsStringDiffrent = !first.Sha256().Equals(second.Sha256()),
                Input = second
            };
        }
    }
}
