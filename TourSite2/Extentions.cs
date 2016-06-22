using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TourSite2
{
    public static class Extentions
    {
        public struct DDLStruct
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static IOrderedQueryable<TSource> CustomOrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, string orderBy)
        {
            if (string.Equals(orderBy, "desc"))
                return source.OrderByDescending(keySelector);
            else
                return source.OrderBy(keySelector);
        }

        public static IList<DDLStruct> ToDDL<TSource, TPropertyId, TPropertyName>(this IEnumerable<TSource> source,
                   Func<TSource, TPropertyId> Id, Func<TSource, TPropertyName> Name, bool IsAllExist = false,
                   int AllValue = 0, bool IsAllInTop = true, IEnumerable<TSource> sourceToEndOfList = null, string IsAllName = "All")
        {
            IList<DDLStruct> result = new List<DDLStruct>();

            IEnumerable<DDLStruct> values = null;
            if (IsAllExist && IsAllInTop)
                result.Add(new DDLStruct { Id = AllValue, Name = IsAllName });

            values = result.Union(source.Select(s => new DDLStruct
            {
                Id = Id(s).ChangeType<TPropertyId, int>(),
                Name = Name(s).ChangeType<TPropertyName, string>()
            }));

            if (sourceToEndOfList != null)
                values = values.Union(sourceToEndOfList.Select(s => new DDLStruct
                {
                    Id = Id(s).ChangeType<TPropertyId, int>(),
                    Name = Name(s).ChangeType<TPropertyName, string>()
                }));
            result = values.ToList();
            if (IsAllExist && !IsAllInTop)
                result.Add(new DDLStruct { Id = AllValue, Name = IsAllName });

            return result;
        }

        public static string ToDDLContent<TSource, TPropertyId, TPropertyName>(this IEnumerable<TSource> source,
   Func<TSource, TPropertyId> Id, Func<TSource, TPropertyName> Name, bool IsAllExist = false,
           int AllValue = 0, bool IsAllInTop = true, IEnumerable<TSource> sourceToEndOfList = null, string IsAllName = "All")
        {
            StringBuilder sb = new StringBuilder();
            if (source.Count() > 0)
            {
                sb.Append(source.ToDDL(Id, Name, IsAllExist, AllValue, IsAllInTop, sourceToEndOfList, IsAllName).Select(s => string.Format("<option value=\"{0}\">{1}</option>", s.Id, s.Name)).GetMessages(""));
            }
            return sb.ToString();
        }

        public static string GetMessages(this  IEnumerable<string> messages, string separator = "; ", string EndWith = "")
        {
            string message = string.Empty;
            switch (messages.Count())
            {
                case 0:
                    break;
                case 1:
                    message = messages.First();
                    break;

                default:
                    message = messages.Select(s => s).Aggregate((x, y) => x + EndWith + separator + y);
                    break;
            }
            return message + EndWith;
        }

        public static SelectList ToSelectList<TSource, TPropertyId, TPropertyName>(this IEnumerable<TSource> source,
           Func<TSource, TPropertyId> Id, Func<TSource, TPropertyName> Name, bool IsAllExist = false,
           int AllValue = 0, bool IsAllInTop = true, IEnumerable<TSource> sourceToEndOfList = null, string IsAllName = "All")
        {
            return new SelectList(source.ToDDL(Id, Name, IsAllExist, AllValue, IsAllInTop, sourceToEndOfList, IsAllName), "Id", "Name");
        }

        public static TReturned ChangeType<TSource, TReturned>(this TSource source)
        {
            return (TReturned)Convert.ChangeType(source, typeof(TReturned));
        }
    }
}