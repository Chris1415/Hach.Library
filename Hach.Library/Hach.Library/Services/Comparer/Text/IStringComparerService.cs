using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Text
{
    public interface IStringComparerService
    {
        StringComparisonModel CompareStrings(string first, string second);
    }
}
