using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using CrudProductos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CrudProductos.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UsuarioAplicacion> _signInManager;
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly IUserStore<UsuarioAplicacion> _userStore;
        private readonly IUserEmailStore<UsuarioAplicacion> _emailStore;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<UsuarioAplicacion> userManager,
            IUserStore<UsuarioAplicacion> userStore,
            SignInManager<UsuarioAplicacion> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Correo Electrónico")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y máximo {1} caracteres.", MinimumLength = 4)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }


            [Required]
            [Display(Name = "Nombres")]
            public string Nombres { get; set; }

            [Required]
            [Display(Name = "Apellidos")]
            public string Apellidos { get; set; }

            [Required]
            [Display(Name = "Cédula")]
            [StringLength(10, MinimumLength = 10, ErrorMessage = "La cédula debe tener 10 dígitos")]
            public string Cedula { get; set; }

            [Required]
            [Display(Name = "Código de Vendedor")]
            public string CodigoVendedor { get; set; }

            [Required]
            [Display(Name = "Dirección")]
            public string Direccion { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Teléfono Celular")]
            public string Telefono { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                user.Nombres = Input.Nombres;
                user.Apellidos = Input.Apellidos;
                user.Cedula = Input.Cedula;
                user.CodigoVendedor = Input.CodigoVendedor;
                user.Direccion = Input.Direccion;

                user.PhoneNumber = Input.Telefono;

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuario vendedor creado exitosamente.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private UsuarioAplicacion CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UsuarioAplicacion>();
            }
            catch
            {
                throw new InvalidOperationException($"No se puede crear la instancia de '{nameof(UsuarioAplicacion)}'.");
            }
        }

        private IUserEmailStore<UsuarioAplicacion> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("Se requiere soporte de email.");
            }
            return (IUserEmailStore<UsuarioAplicacion>)_userStore;
        }
    }
}