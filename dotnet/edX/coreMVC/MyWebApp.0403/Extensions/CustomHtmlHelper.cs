using System;
using Microsoft.AspNetCore.Html;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class MyHtmlHelperExtensions
    {
        public static IHtmlContent ColorfulHeading(this IHtmlHelper htmlHelper, int level, string color, string content)
        {
            level = level < 1 ? 1 : level;
            level = level > 6 ? 6 : level;
            var tagName = $"h{level}";
            var tagBuilder = new TagBuilder(tagName);
            tagBuilder.Attributes.Add("style", $"color:{color ?? "green"}");
            tagBuilder.InnerHtml.Append(content ?? string.Empty);
            return tagBuilder;
        }

        public static IHtmlContent Calendar(this IHtmlHelper htmlHelper, DateTime dtTarget, string color=null) {
            DateTime dtCalStart = new DateTime(dtTarget.Year, dtTarget.Month, 1);
            DateTime dtCalEnd = dtCalStart.AddMonths(1).AddDays(-1);
            var tableBuilder = new TagBuilder("table");
            tableBuilder.Attributes.Add("border", "1");
            string[] columnNames = {"Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"};
            var headerBuilder = new TagBuilder("tr");
            var headerCellBuilder = new TagBuilder("th");
            headerCellBuilder.Attributes.Add("colspan", columnNames.Length.ToString());
            headerCellBuilder.InnerHtml.Append(dtCalStart.ToString("MMMM yyyy"));
            headerBuilder.InnerHtml.AppendHtml(headerCellBuilder);
            tableBuilder.InnerHtml.AppendHtml(headerBuilder);
            headerBuilder = new TagBuilder("tr");
            foreach (var cn in columnNames)
            {
                headerCellBuilder = new TagBuilder("th");
                headerCellBuilder.InnerHtml.Append(cn);
                headerBuilder.InnerHtml.AppendHtml(headerCellBuilder);
            }

            tableBuilder.InnerHtml.AppendHtml(headerBuilder);
            int dayStart = (int) dtCalStart.DayOfWeek;
            int dayEnd = dtCalEnd.Day;
            int colCount = columnNames.Length;
            int rowCount = (int) Math.Ceiling( (dayStart + dayEnd) / (double) colCount );
            DateTime dtCur = dtCalStart.AddDays(-1 * dayStart);
            DateTime dtCompare = dtTarget.Date;
            for (int r = 0; r < rowCount; r++)
            {
                var rowBuilder = new TagBuilder("tr");
                for (int c = 0; c < colCount; c++, dtCur = dtCur.AddDays(1))
                {
                    string content = null;
                    var cellBuilder = new TagBuilder("td");
                    cellBuilder.Attributes.Add("align", "center");
                    if (null != color && dtCur == dtCompare) {
                        cellBuilder.Attributes.Add("style", $"background:{color}");
                    } else if (dtCur.Month != dtCompare.Month) {
                        cellBuilder.Attributes.Add("style", "background:lightgrey");
                    }
                    content = dtCur.Day.ToString();
                    cellBuilder.InnerHtml.Append(content);
                    rowBuilder.InnerHtml.AppendHtml(cellBuilder);
                }
                tableBuilder.InnerHtml.AppendHtml(rowBuilder);
            }

            return tableBuilder;
        }

        public static IHtmlContent Table(this IHtmlHelper htmlHelper, string[] columnNames, string[,] content)
        {
            var tableBuilder = new TagBuilder("table");
            tableBuilder.Attributes.Add("border", "1");
            var headerBuilder = new TagBuilder("tr");
            foreach (var cn in columnNames)
            {
                var headerCellBuilder = new TagBuilder("th");
                headerCellBuilder.InnerHtml.Append(cn);
                headerBuilder.InnerHtml.AppendHtml(headerCellBuilder);
            }

            tableBuilder.InnerHtml.AppendHtml(headerBuilder);
            int colCount = columnNames.Length;
            int rowCount = content.Length / colCount;
            for (int r = 0; r < rowCount; r++)
            {
                var rowBuilder = new TagBuilder("tr");
                for (int c = 0; c < colCount; c++)
                {
                    var cellBuilder = new TagBuilder("td");
                    cellBuilder.InnerHtml.Append(content[r, c]);
                    rowBuilder.InnerHtml.AppendHtml(cellBuilder);
                }
                tableBuilder.InnerHtml.AppendHtml(rowBuilder);
            }

            return tableBuilder;
        }
    }
}
