﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TrainingCentersCRM.Infrastructure
{
    public class ExtendedSelectListItem : SelectListItem
    {
        public object HtmlAttributes { get; set; }
    }

    public static class CustomHtmlHelpers
    {
        public static MvcHtmlString DropDownListWithOptions(this HtmlHelper htmlHelper, string name, IEnumerable<ExtendedSelectListItem> selectList, object htmlAttributes = null)
        {
            var select = new TagBuilder("select");

            var options = "";

            foreach (var item in selectList)
            {
                options += ListItemToOption(item);
            }

            select.MergeAttribute("id", name);
            select.MergeAttribute("name", name);
            select.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            select.InnerHtml = options;

            return new MvcHtmlString(select.ToString(TagRenderMode.Normal));
        }

        internal static string ListItemToOption(ExtendedSelectListItem item)
        {
            TagBuilder builder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
            {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                builder.Attributes["selected"] = "selected";
            }
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(item.HtmlAttributes));
            return HttpUtility.HtmlDecode(builder.ToString(TagRenderMode.Normal));
        }
    }
}