using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bifrost_Website.modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bifrost_Website.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public string response { get; set; }

        public void OnGet()
        {
            HttpContext.Session.Remove("user_id");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Api_call api = new Api_call();
            idModal res = await api.Login(Username, Password);
            response = res.uid + "      .    " + res.cookie;
            if (res.uid == "false")
            {
                HttpContext.Session.SetString("user_id", res.uid);
                HttpContext.Session.SetString("cookie", res.uid);
                return RedirectToPage("./Index");
            } else
            {
                return Page();
            }
        }
    }
}
