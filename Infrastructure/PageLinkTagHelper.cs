using DallinCollinsAssignment5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Infrastructure
{
    //this will apply to the div element, and can be accessed by the phrase "page-model"
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        //factory for creating MVC core UrlHelper instances. Is class level
        private IUrlHelperFactory urlHelperFactory;

        //is the constructor for this class, allows us to set the above private variable to an IURLHelperFactory object
        public PageLinkTagHelper ( IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        //setting these attributes to the property called "ViewContext"
        [ViewContext] //saying that the variable is a viewcontext
        [HtmlAttributeNotBound] 
        public ViewContext ViewContext { get; set; }

        //sets the property PageModel as a PagingInfo object
        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }


        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();



        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        //need to override a method that is in the TagHelper class
        //means we take a method already in place and replace it with our information
        public override void Process(TagHelperContext context, TagHelperOutput output) //uses the method called "Process"
        {
            //takes urlHelperFactory variable from above, and passes the ViewContext
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            //tag name will be "div"
            TagBuilder result = new TagBuilder("div");

            //will build pages on the fly. i = page number. goes to the PagingInfo (PageModel) to get the total number of pages
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                //adds an a tag
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["pageNum"] = i;

                //adds href to the a tag. Looks at the action being passed (index, privacy, etc)
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);

                    //if i is equal to PageModel.CurrentPage, then do PageClassSelected. Otherwise, do PageClassNormal
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                //appends what number we're on to the html tag
                tag.InnerHtml.Append(i.ToString());

                //appends this new tag to the HTML we already have in the result property
                result.InnerHtml.AppendHtml(tag);
            }

            //outputs finished product of the html we just generated
            output.Content.AppendHtml(result.InnerHtml);
        }
        }
        }

