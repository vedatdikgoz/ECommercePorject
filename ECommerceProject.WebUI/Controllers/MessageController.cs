using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopapp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Entities.Concrete;
using ECommerceProject.WebUI.Identity;
using ECommerceProject.WebUI.Models;

namespace ECommerceProject.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<User> _userManager;
        
        public MessageController(IMessageService messageService, UserManager<User> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult IncomingMessage()
        {
            var email = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.Email;

            var incomeMessage = _messageService.GetAll().Data.Count(I => I.Reciever == email).ToString();
            ViewBag.income=incomeMessage;

            var sentMessage = _messageService.GetAll().Data.Count(I => I.Sender == email).ToString();
            ViewBag.sent = sentMessage;

            return View(new MessageViewModel()
            {
                Messages = _messageService.GetAll().Data.Where(I=>I.Reciever==email).OrderByDescending(I=>I.SendDate).ToList()
            });
        }

        public IActionResult SentMessage()
        {
            var email = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.Email;

            var sentMessage = _messageService.GetAll().Data.Count(I => I.Sender == email).ToString();
            ViewBag.sent = sentMessage;

            var incomeMessage = _messageService.GetAll().Data.Count(I => I.Reciever == email).ToString();
            ViewBag.income = incomeMessage;

            return View(new MessageViewModel()
            {
                Messages = _messageService.GetAll().Data.Where(I => I.Sender == email).OrderByDescending(I => I.SendDate).ToList()
            });
        }


        public IActionResult MessageDetail(int id)
        {           
            var email = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.Email;

            var sentMessage = _messageService.GetAll().Data.Count(I => I.Sender == email).ToString();
            ViewBag.sent = sentMessage;

            var incomeMessage = _messageService.GetAll().Data.Count(I => I.Reciever == email).ToString();
            ViewBag.income = incomeMessage;

            var messages = _messageService.GetMessageDetail(id);
            return View(messages);
          
        }

        

        [HttpGet]
        public IActionResult NewMessage()
        {
            var email = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.Email;

            var sentMessage = _messageService.GetAll().Data.Count(I => I.Sender == email).ToString();
            ViewBag.sent = sentMessage;

            var incomeMessage = _messageService.GetAll().Data.Count(I => I.Reciever == email).ToString();
            ViewBag.income = incomeMessage;

            return View();
        }


        [HttpPost]
        public IActionResult NewMessage(MessageDetailModel model)
        {
            var email = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.Email;
            if (ModelState.IsValid)
            {
                var message = new Message()
                {
                    Sender=email,
                    Reciever = model.Reciever,
                    Subject = model.Subject,
                    Content=model.Content,
                    SendDate =model.SendDate=DateTime.Parse(DateTime.Now.ToShortDateString()),
                  
                };
                var result = _messageService.Add(message);
                if (result.Success)
                {
                    return RedirectToAction("IncomingMessage");
                }
                
                return View(model);
            }

            return View(model);
        }
    }
}
