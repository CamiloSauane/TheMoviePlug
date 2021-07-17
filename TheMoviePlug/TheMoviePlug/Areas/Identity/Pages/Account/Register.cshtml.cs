using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TheMoviePlug.Data;
using TheMoviePlug.Models;

namespace TheMoviePlug.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;

        }

        /// <summary>
        /// É utilizado para transportar os dados para a interface de registo
        /// </summary>
        [BindProperty]  // cria o efeito de memória entre a interface e o Model
        public InputModel Input { get; set; }

        /// <summary>
        /// Permite redirecionar o utilizador para o local de origem
        /// </summary>
        public string ReturnUrl { get; set; }

        
        // public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// Classe que recolhe e transporta os dados da página para o código
        /// </summary>
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public Utilizadores Utilizador { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, EmailConfirmed = false, LockoutEnabled = false, LockoutEnd = new DateTime(DateTime.Now.Year+10, 1, 1), DataRegisto = DateTime.Now };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (Input.Email.Contains("gestor.pt"))
                    {
                        await _userManager.AddToRoleAsync(user, "Gestor");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "Registado");
                    }

                    Input.Utilizador.Email = Input.Email;
                    Input.Utilizador.UserName = user.Id;
                    Input.Utilizador.Ativo = true;

                    try
                    {
                        _context.Add(Input.Utilizador);        // adicionar o Utilizador
                        
                        await _context.SaveChangesAsync();     // 'commit' da adição
                        return RedirectToPage("RegisterConfirmation");
                    }
                    catch (Exception)
                    {
                        await _userManager.DeleteAsync(user);
                        ModelState.AddModelError("", "Ocorreu um erro na criação do Utilizador.");
                    }

                    

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
