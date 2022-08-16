// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.Text;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using MimeKit;

namespace ChernabogApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _sender;
        public readonly IConfiguration Configuration;

        public RegisterConfirmationModel(UserManager<IdentityUser> userManager, IEmailSender sender, IConfiguration configuration)
        {
            _userManager = userManager;
            _sender = sender;
            Configuration = configuration;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool DisplayConfirmAccountLink { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }
            returnUrl = returnUrl ?? Url.Content("~/");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            EmailConfirmationUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                protocol: Request.Scheme);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Configuration["Email:FromName"], Configuration["Email:FromEmail"]));
            message.To.Add(new MailboxAddress(user.UserName, Email));
            message.Subject = "Активация аккаунта";

            message.Body = new TextPart("plain")
            {
                Text = EmailConfirmationUrl
            };

            using (var client = new SmtpClient())
            {
                client.Connect(Configuration["Email:Server"], 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(Configuration["Email:User"], Configuration["Email:Password"]);

                client.Send(message);
                client.Disconnect(true);
            }

            return Page();
        }
    }
}
