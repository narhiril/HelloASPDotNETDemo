using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace HelloASPDotNET.Controllers
{
    public class HelloController : Controller
    {

        [HttpGet]
        [Route("/helloworld")]
        public IActionResult Index()
        {
            string html = "<h1>Hello World!</h1>";
            return Content(html, "text/html");
        }

        [HttpGet]
        [Route("/hello")]
        public IActionResult InputPrompt()
        {
            string htmltext = "<form method=\"POST\" action=\"/hello\">" +
                                "<label for=\"nameinput\">Enter Your Name:</label>" +
                                "<input type=\"text\" name=\"nameinput\" id=\"nameinput\">" +
                                "<label for=\"langinput\">Select Language</label>" +
                                "<select name=\"langinput\" id=\"langinput\" required=\"true\" style=\"font-family: Arial Unicode MS;\">" +
                                    "<option lang=\"en\" selected value=\"en\">English</option>" +
                                    "<option lang=\"es\" value=\"es\">Español</option>" +
                                    "<option lang=\"de\" value=\"de\">Deutsch</option>" +
                                    "<option lang=\"fr\" value=\"fr\">Français</option>" +
                                    "<option lang=\"ja\" value=\"ja\">日本</option>" +
                                    "<option lang=\"zh\" value=\"zh\">简体中文</option>" +
                                    "<option value=\"sjn\">Sindarin</option>" +
                                "<input type=\"submit\" value=\"Greet me!\">" +
                              "</form>";

            return Content(htmltext, "text/html");

        }

        [HttpPost("welcome")]
        [Route("/hello/{nameinput?}")]
        public IActionResult Welcome(string nameinput = "fellow traveller", string langinput = "en")
        {
            string greeting = CreateMessage(nameinput, langinput);
            return Content($"<h1>{greeting}</h1>", "text/html");
        }

        public enum LanguageOptions
        {
            en,
            de,
            fr,
            es,
            ja,
            sjn,
            zh
        }

        public static string CreateMessage(LanguageOptions language)
        {
            return language switch
                {
                LanguageOptions.de => "Hallo",
                LanguageOptions.fr => "Bonjour",
                LanguageOptions.es => "Hola",
                LanguageOptions.ja => "こんにちは",
                LanguageOptions.zh => "你好",
                LanguageOptions.en => "Hello",
                LanguageOptions.sjn => "Mae govannen",
                _ => "Hi"
                };
        }

        public static string CreateMessage(string name, string languageRawInput)
        {
            LanguageOptions selected = LanguageOptions.en;
            Enum.TryParse(languageRawInput, out selected);
            return $"{CreateMessage(selected)}, {name}!";
        }
    }
}
