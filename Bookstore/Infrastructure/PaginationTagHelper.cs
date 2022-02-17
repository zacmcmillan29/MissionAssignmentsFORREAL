using System;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bookstore.Infrastructure
{
    //GOAL --> GOAL: build a series of links as tag helpers! Dynamically creating links for us

    [HtmlTargetElement("div", Attributes = "page-stuff")]
    public class PaginationTagHelper : TagHelper
    {

        //these first two help us build the links to go to the right place!
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }


        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }



        //this is to track the numPages for the for loop down below in the override
        //different from ViewContext
        public PageInfo PageStuff { get; set; }


        //being received as home page!
        public string PageAction { get; set; }


        //override a default method/parent class
        //this is going to end up building dynamically the tags that link to the next pages!
        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div"); //for the OVERALL

            for (int i = 1; i <= PageStuff.TotalNumPages; i++)
            {
                TagBuilder tb = new TagBuilder("a"); //for each individual link

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i }); //this
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

                tho.Content.AppendHtml(final.InnerHtml);
            
        }
    }
}
