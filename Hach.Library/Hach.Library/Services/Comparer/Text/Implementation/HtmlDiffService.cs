using System;
using System.Collections.Generic;
using System.Linq;
using Hach.Library.Extensions;
using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Text.Implementation
{
    public class HtmlDiffService : IHtmlDiffService
    {
        public StringComparisonModel CompareStrings(string first, string second)
        {
            HtmlDiff.HtmlDiff diffHelper = new HtmlDiff.HtmlDiff(first, second);
            string diffString = diffHelper.Build();
            string delMarkup = "<del class='diffmod'>";
            string endDelMarkup = "</del>";
            bool furtherHits = true;
            IList<MatchModel> hits = new List<MatchModel>();
            string localDiffString = diffString;

            while (!localDiffString.IsNullOrEmpty() && furtherHits)
            {
                int startPosition = localDiffString.IndexOf(delMarkup, StringComparison.Ordinal);
                int endPosition = localDiffString.IndexOf(endDelMarkup, StringComparison.Ordinal);
                if (startPosition != -1 && endPosition != -1)
                {
                    if (endPosition > startPosition)
                    {
                        string match = localDiffString.Substring(startPosition,
                            endPosition - startPosition + endDelMarkup.Length);
                        hits.Add(new MatchModel()
                        {
                            Match = match,
                            MatchType = MatchTypes.Deletion,
                            Bounds = new Tuple<int, int>(startPosition, endPosition)
                        });
                    }
                    localDiffString = localDiffString.Substring(endPosition + delMarkup.Length);
                }
                else
                {
                    furtherHits = false;
                }
            }

            localDiffString = diffString;
            furtherHits = true;
            string insMarkup = "<ins class='diffmod'>";
            string endInsMarkup = "</ins>";

            while (!localDiffString.IsNullOrEmpty() && furtherHits)
            {
                int startPosition = localDiffString.IndexOf(insMarkup, StringComparison.Ordinal);
                int endPosition = localDiffString.IndexOf(endInsMarkup, StringComparison.Ordinal);
                if (startPosition != -1 && endPosition != -1)
                {
                    if (endPosition > startPosition)
                    {
                        string match = localDiffString.Substring(startPosition, endPosition - startPosition + endInsMarkup.Length);
                        hits.Add(new MatchModel()
                        {
                            Match = match,
                            MatchType = MatchTypes.Insertion,
                            Bounds = new Tuple<int, int>(startPosition, endPosition)
                        });
                    }
                    
                    localDiffString = localDiffString.Substring(endPosition + insMarkup.Length);
                }
                else
                {
                    furtherHits = false;
                }
            }

            return new StringComparisonModel()
            {
                IsStringDiffrent = hits.Any(),
                Input = second,
                Changes = hits
            };
        }
    }
}
