using SampleApplication2.Models;
using Microsoft.AspNetCore.Components;

namespace SampleApplication2.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
