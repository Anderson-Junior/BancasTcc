using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using GerenciamentoBancasTcc.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GerenciamentoBancasTcc.Controllers
{
    [Authorize(Roles = RolesHelper.ADMINISTRADOR)]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioController(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(GetUsers());
        }

        #region Usuários

        [HttpGet]
        public PartialViewResult PesquisarUsuarios()
        {
            return PartialView("_GridUsuarios", GetUsers());
        }

        [HttpGet]
        public async Task<ActionResult> EditarUsuario(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return View("NotFound");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> EditarUsuario(Usuario model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return View("NotFound");
            }

            user.Nome = model.Nome;
            user.Ativo = model.Ativo;

            try
            {              
                var result = await _userManager.UpdateAsync(user);

                ViewBag.Succeeded = result.Succeeded;
                ViewBag.StatusMessage = result.Succeeded
                    ? string.Format("Usuário {0} alterado com sucesso.", user.UserName)
                    : string.Join("<br />", result.Errors.Select(p => p.Description));
            }
            catch (Exception ex)
            {
                ViewBag.Succeeded = false;
                ViewBag.StatusMessage = GetErrorMessage(ex);
            }


            return View(user);
        }

        [HttpPost]
        public async Task<JsonResult> ExcluirUsuario(string alias)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(alias);
                var result = await _userManager.DeleteAsync(user);
                string message = string.Join("<br />", result.Errors.Select(p => p.Description));
                return Json(new { succeeded = result.Succeeded, message });
            }
            catch (Exception ex)
            {
                return Json(new { succeeded = false, message = GetErrorMessage(ex) });
            }
        }

        #endregion

        #region Associações de usuário & funções

        [HttpGet]
        public async Task<ActionResult> FuncoesUsuario(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            ViewBag.UserId = user.Id;
            ViewBag.UserName = user.UserName;

            return View(await _userManager.GetRolesAsync(user));
        }

        [HttpGet]
        public async Task<ActionResult> AdicionarFuncoesUsuario(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            ViewBag.UserId = user.Id;
            ViewBag.UserName = user.UserName;

            return View(GetAvailableRoles(id));
        }

        [HttpPost]
        public async Task<PartialViewResult> AdicionarFuncoesUsuario(string userId, string[] roles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            foreach (string role in roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return PartialView("_GridAdicionarFuncoesUsuario", GetAvailableRoles(userId));
        }

        [HttpPost]
        public async Task<PartialViewResult> RemoverFuncaoUsuario(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, role);
            return PartialView("_GridFuncoesUsuario", await _userManager.GetRolesAsync(user));
        }

        #endregion

        #region Helpers

        private IList<string> GetAvailableRoles(string userId)
        {
            return (from role in _context.Roles
                    where !_context.UserRoles.Any(x => x.UserId == userId && x.RoleId == role.Id)
                    select role.Name).ToList();
        }

        private IList<Usuario> GetUsers()
        {
            var users = _context.Users.OrderBy(p => p.UserName).ToList();
            var roles = _context.Roles.ToDictionary(x => x.Id, y => y.Name);

            foreach (var user in users)
            {
                foreach (var role in _context.UserRoles.Where(p => p.UserId == user.Id))
                {
                    user.UserRoles += roles[role.RoleId] + ';';
                }
            }

            return users;
        }

        private static string GetErrorMessage(Exception ex)
        {
            string message;

            if (ex.InnerException == null)
            {
                message = ex.Message;
            }
            else
            {
                message = ex.InnerException.Message;
            }

            return message;
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userManager.Dispose();
                _userManager.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
