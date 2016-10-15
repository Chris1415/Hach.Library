using System.Collections.Generic;
using System.Drawing;
using Hach.Library.Extensions;
using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Text.Implementation
{
    /// <summary>
    /// Longest Common Subsequence Service to determine diffrences between two strings
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public class LongestCommonSubsequenceService : ILongestCommonSubsequenceService
    {
        /// <summary>
        /// Calculates the Lcs Matrix of two given strings
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <returns>Lcs Matrix</returns>
        public int[,] CalculateLcsMatrix(string first, string second)
        {
            if (first.IsNullOrEmpty() || second.IsNullOrEmpty())
            {
                return null;
            }

            int lengthX = first.Length;
            int lengthY = second.Length;
            int[,] result = new int[lengthX, lengthY];

            CalculateLcsMatrixRecursive(first, second, ref result, 0, 0);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="result"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void CalculateLcsMatrixRecursive(string first, string second, ref int[,] result, int x, int y)
        {
            if (x >= first.Length || y >= second.Length)
            {
                return;
            }

            if (first[x].Equals(second[y]))
            {
                result[x, y] = 1;
                CalculateLcsMatrixRecursive(first, second, ref result, x + 1, y + 1);
            }
            else
            {
                result[x, y] = 0;
                CalculateLcsMatrixRecursive(first, second, ref result, x + 1, y);
                CalculateLcsMatrixRecursive(first, second, ref result, x, y + 1);
            }
        }

        /// <summary>
        /// Builds the string comparison model, based on the given strings and the Lcs matrix
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <param name="lcsMatrix">lcs matrix</param>
        /// <returns>string comparison model</returns>
        public StringComparisonModel BuildStringComparisonModel(string first, string second, int[,] lcsMatrix)
        {
            if (lcsMatrix == null)
            {
                return new StringComparisonModel()
                {
                    IsStringDiffrent = false,
                    Input = second
                };
            }
            IList<Point> backtrackingPath = new List<Point>();
            int xIndex = lcsMatrix.GetLength(0) - 1;
            int yIndex = lcsMatrix.GetLength(1) - 1;

            BackTrack(lcsMatrix, xIndex, yIndex, ref backtrackingPath, -1, new Point(-1, -1));
            BuildStringComparisonModelFromBackTrackingPath(backtrackingPath, first, second);
            return new StringComparisonModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="backtrackingPath"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private static StringComparisonModel BuildStringComparisonModelFromBackTrackingPath(IList<Point> backtrackingPath, string first, string second)
        {
            bool isDiffrent = false;
            string resultMarkup = string.Empty;
            for (int index = 0; index < backtrackingPath.Count; index++)
            {
                Point previous = index == 0 ? new Point(-1, -1) : backtrackingPath[index - 1];
                Point current = backtrackingPath[index];
                if (previous.X == -1)
                {
                    resultMarkup += second[current.Y];
                }

                if (current.X - previous.X == 1 && current.Y - previous.Y == 1)
                {
                    resultMarkup += second[current.Y];
                }
                else if (current.X - previous.X != 1 && current.Y - previous.Y == 1)
                {
                    //// Links
                    resultMarkup += "<p class='red'>" + first[current.X] + "</p>";
                    isDiffrent = true;
                }
                else if (current.X - previous.X == 1 && current.Y - previous.Y != 1)
                {
                    //// Oben
                    resultMarkup += "<p class='green'>" + second[current.Y] + "</p>";
                    isDiffrent = true;
                }
            }

            return new StringComparisonModel()
            {
                Input = resultMarkup,
                IsStringDiffrent = isDiffrent
            };
        }

        /// <summary>
        /// Back Track Helper to determine the Path through LCS Matrix
        /// </summary>
        /// <param name="lcsMatrix">lcs matrix</param>
        /// <param name="x">x index </param>
        /// <param name="y">y index </param>
        /// <param name="backtrackingPath">the reference backtracking path</param>
        /// <param name="currentValue">the current value</param>
        /// <returns>true if the current path is correct, other wise false</returns>
        private static bool BackTrack(int[,] lcsMatrix, int x, int y, ref IList<Point> backtrackingPath, int currentValue, Point crossPoint)
        {
            if (x < 0 || y < 0)
            {
                return currentValue == 1;
            }

            if (lcsMatrix[x, y] == 1)
            {
                if (BackTrack(lcsMatrix, x - 1, y - 1, ref backtrackingPath, 1, crossPoint))
                {
                    backtrackingPath.Add(new Point(x, y));
                    return true;
                };
            }

            if (crossPoint.X == -1 && crossPoint.Y == -1)
            {
                crossPoint.X = x;
                crossPoint.Y = y;
            }

            if (BackTrack(lcsMatrix, x - 1, y, ref backtrackingPath, 0, crossPoint))
            {
                backtrackingPath.Add(new Point(x, y));
                crossPoint.X = -1;
                crossPoint.Y = -1;
                return true;
            }

            if (crossPoint.X == x && crossPoint.Y == y)
            {
                if (BackTrack(lcsMatrix, x, y - 1, ref backtrackingPath, 0, crossPoint))
                {
                    backtrackingPath.Add(new Point(x, y));
                    crossPoint.X = -1;
                    crossPoint.Y = -1;
                    return true;
                }
            }



            return false;
        }

        /// <summary>
        /// Builds the string comparison model, based on the given strings
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <returns>string comparison model</returns>
        public StringComparisonModel BuildStringComparisonModel(string first, string second)
        {
            return BuildStringComparisonModel(first, second, CalculateLcsMatrix(first, second));
        }

        public StringComparisonModel CompareStrings(string first, string second)
        {
            return BuildStringComparisonModel(first, second);
        }
    }
}
