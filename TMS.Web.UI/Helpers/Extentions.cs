﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TMS.Entities;

namespace TMS.Web.UI.Helpers
{
  public static class Extentions
  {
    public static string Shorten(this string source, int maxLength)
    {
      return string.IsNullOrWhiteSpace(source)
        ? string.Empty
        : (source.Length > maxLength ? string.Format("{0}...", source.Substring(0, maxLength)) : source);
    }

    public static bool Contains(this string source, string target, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
    {
      if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target))
        return true;
      return source.IndexOf(target, stringComparison) >= 0;
    }

    public static string FormatDateTime(this DateTime? value, bool time = true)
    {
      if(time)
      return value.HasValue ? value.Value.ToString("dddd MMM, dd, yyyy HH:mm") : string.Empty;
      else
        return value.HasValue ? value.Value.ToString("dddd MMM, dd, yyyy") : string.Empty;
    }

    public static string PascalCaseToPrettyString<TEnum>(this HtmlHelper helper, TEnum s)
    {
      return PascalCaseToPrettyString(s.ToString());
    }

    public static string PascalCaseToPrettyString(this HtmlHelper helper, string s)
    {
      return PascalCaseToPrettyString(s);
    }

    public static string ToCurrencyString(this int? value)
    {
      //return string.Format(new CultureInfo("en-US"), "{0:C}", value);
      return value.HasValue ? Regex.Replace(string.Format("{0:C}", value), "[^0-9,\\.]", string.Empty) : string.Empty;
    }

    public static string Pluralise(this float? t, string s)
    {
      if (t.HasValue && t.Value > 0)
        return string.Format("{0} {1}{2}", t.Value, s, t.Value > 1 ? "s" : string.Empty);
      return string.Empty;
    }

    public static string ConvertToString(this int? t, string s)
    {
      if (!t.HasValue || t.Value <= default(int)) return string.Empty;
      TimeSpan ts = TimeSpan.FromMinutes(t.Value);
      return string.Format("{0} hours {1} minutes", ts.Hours, ts.Minutes);
    }

    public static IEnumerable<T> DistinctList<T>(this IEnumerable<T> source) where T: BaseEntity
    {
      List<T> uniques = new List<T>();
      foreach (T item in source)
      {
        if (uniques.All(x => x.Id != item.Id))
          uniques.Add(item);
      }
      return uniques;
    }

    //private static int? ConvertoString(this int? t, string m, int f, StringBuilder sb)
    //{
    //  if (t >= f)
    //  {
    //    var a = t/f;
    //    t = t%f;
    //    sb.AppendFormat("{0} {2}{1} ", a, a > 1 ? "s" : string.Empty, m);
    //  }
    //  else
    //  {
    //    //sb.AppendFormat("{0} {2}{1} ", t, t > 1 ? "s" : string.Empty, m);
    //    t = t%f;
    //  }
        
    //  return t;
    //}

    //public static string NumberToHours(this int? hours)
    //{
    //  if (!hours.HasValue)
    //    return string.Empty;
    //  StringBuilder sb = new StringBuilder();
    //  hours.ConvertoString("hour", 60, sb)
    //    .ConvertoString("minute", 60, sb);
    //  return sb.ToString();
    //}

    public static string NumberToDays(this int days)
    {
      return string.Empty;
      //StringBuilder sb = new StringBuilder();

      //(days.ConvertoString("year", 365, sb)
      //  .ConvertoString("month", 30, sb)*24).ConvertoString("day", 24, sb);

      //.ConvertoString("hour", 60, sb)
      //.ConvertoString("minute", 60, sb)
      //.ConvertoString("second", 60, sb);

      //return sb.ToString();

      //if (days >= 365)
      //{
      //  t = days/365;
      //  days = days%365;
      //  sb.AppendFormat("{0} year{1} ", t, t > 1 ? "s" : string.Empty);
      //}

      //if (days > 30)
      //{
      //  t = days/30;
      //  days = days%30;
      //  sb.AppendFormat("{0} month{1} ", t, t > 1 ? "s" : string.Empty);
      //}

      //if (days > 24)
      //{
      //  t = days/24;
      //  days = days%24;
      //  sb.AppendFormat("{0} day{1}", days, days > 1 ? "s" : string.Empty);
      //}

      //if (days > 60)
      //{
      //  t = days / 60;
      //  days = days % 60;
      //  sb.AppendFormat("{0} hour{1}", days, days > 1 ? "s" : string.Empty);
      //}

      //if (days > 60)
      //{
      //  t = days / 60;
      //  days = days % 60;
      //  sb.AppendFormat("{0} minute{1}", days, days > 1 ? "s" : string.Empty);
      //}

      //if (days > 60)
      //{
      //  t = days / 60;
      //  days = days % 60;
      //  sb.AppendFormat("{0} second{1}", days, days > 1 ? "s" : string.Empty);
      //}

      //return sb.ToString();
    }

    public static string TitleCase(this string s)
    {
      return string.IsNullOrWhiteSpace(s) ? string.Empty : String.Join(" ", s.Split(' ').Select(i => i.Substring(0, 1).ToUpper() + i.Substring(1).ToLower()).ToArray());
    }

    public static string PascalCaseToPrettyString(this string s)
    {
      return Regex.Replace(s, @"(\B[A-Z]|[0-9]+)", " $1");
    }

    private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
    {
      Type realModelType = modelMetadata.ModelType;

      Type underlyingType = Nullable.GetUnderlyingType(realModelType);
      if (underlyingType != null)
      {
        realModelType = underlyingType;
      }
      return realModelType;
    }

    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
    {
      ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
      Type enumType = GetNonNullableModelType(metadata);
      IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

      TypeConverter converter = TypeDescriptor.GetConverter(enumType);

      IEnumerable<SelectListItem> items =
        from value in values
        select new SelectListItem
        {
          Text = converter.ConvertToString(value).PascalCaseToPrettyString(),
          Value = value.ToString(),
          Selected = value.Equals(metadata.Model)
        };
      return htmlHelper.DropDownListFor(expression, items, "Select One...",
        new
        {
          @class = "form-control",
        });
    }

    public static MvcHtmlString LabelForPascal<TModel, TProp>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProp>> expression, string propName = null)
    {
      ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
      //Type enumType = GetNonNullableModelType(metadata);

      return htmlHelper.LabelFor(expression, string.IsNullOrWhiteSpace(propName) ? metadata.PropertyName.PascalCaseToPrettyString() : propName);
    }
  }
}