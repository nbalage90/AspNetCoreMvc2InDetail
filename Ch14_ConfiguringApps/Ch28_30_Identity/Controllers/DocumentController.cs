﻿using Ch28_30_Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch28_30_Identity.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private ProtectedDocument[] docs = new ProtectedDocument[]
        {
            new ProtectedDocument { Title = "Q3 Budget", Author = "Alice", Editor = "Joe" },
            new ProtectedDocument { Title = "Project Plan", Author = "Bob", Editor = "Alice" },
        };
        private IAuthorizationService authService;

        public DocumentController(IAuthorizationService auth)
        {
            authService = auth;
        }

        public ViewResult Index() => View(docs);

        public async Task<IActionResult> Edit(string title)
        {
            ProtectedDocument doc = docs.FirstOrDefault(d => d.Title == title);
            AuthorizationResult authorized = await authService.AuthorizeAsync(User, doc, "AuthorsAndEditors");
            if (authorized.Succeeded)
            {
                return View("Index", doc);
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}
