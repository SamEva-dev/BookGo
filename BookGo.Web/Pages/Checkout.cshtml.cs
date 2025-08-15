using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookGo.Web.Pages;

public class CheckoutModel : PageModel
{
    [FromQuery] public Guid BookingId { get; set; }
    public void OnGet() { }
}