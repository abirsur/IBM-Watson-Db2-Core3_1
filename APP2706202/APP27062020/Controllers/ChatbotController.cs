using APP27062020.Helpers;
using APP27062020.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APP27062020.Controllers
{
    public class ChatbotController : Controller
    {
        [HttpGet]
        public IActionResult Index(ChatViewModel chatViewModel = null)
        {
            return View("~/Views/Chatbot/index.cshtml", chatViewModel);
        }

        [HttpPost]
        public IActionResult SendMessage(UserQueryModel userQueryModel)
        {
            ChatViewModel chatViewModel = new ChatViewModel();
            string message = Request.Headers["MessageToSend"];
            var conversation = new List<ConversatioMessage>();
            conversation.Add(new ConversatioMessage { Message = userQueryModel.UserQuery, SendBy = "user" });
            string response = new WatsonChatbotHelper().MessageToCovid19Bot(userQueryModel.UserQuery);
            conversation.Add(new ConversatioMessage { SendBy = "IBM BOT", Message = response });
            chatViewModel.ChatHistory = conversation;
            return Index(chatViewModel);
        }


    }
}