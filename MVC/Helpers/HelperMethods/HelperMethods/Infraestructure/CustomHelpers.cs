using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods.Infraestructure
{
    public static class CustomHelpers
    {


        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list)
        {//tagbuilder-> generador de etiquetas
            TagBuilder tag = new TagBuilder("ul");
            foreach (string str in list)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(str);
                tag.InnerHtml += itemTag.ToString();
            }
            return new MvcHtmlString(tag.ToString());

        }

    }
}