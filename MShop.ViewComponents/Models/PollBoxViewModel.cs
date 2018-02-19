using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MShop.ViewComponents.Models
{
    public class PollBoxViewModel
    {
        public string Question { get; set; }
        public List<SelectListItem> OptionTexts { get; set; }
        public List<PollOptionViewModel> Options { get; set; }
        public int TotalVotes { get; set; }
    }
}
