using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='POST'>" +
                "<input type= 'text' name='name' />" +
                "<select name='language'>" +
                "<option value = ''>--Please choose a language--</option>" +
                "<option value = 'english'>English</option>" +
                "<option value = 'japanese'>Japanese</option>" +
                "<option value = 'spanish'>Spanish</option>" +
                "<option value = 'french'>French</option>" +
                "</select > " +
                "<input type= 'submit' value='Greet me!' />" +
                "</form>";


            return Content(html, "text/html");
            //return Redirect("/Hello/Goodbye");
        }

        //Hello
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name="World", string language= "english")
        {
            //if(string.IsNullOrEmpty(name))
            //name = "World";
            string greeting = CreateMessage(name, language);

            return Content(string.Format("<h1>{0}</h1>", greeting), "text/html");
        }

        //Handle request to /Hello/NAME (URL segment)
        //[Route("/Hello/{name}")]
        //public IActionResult Index2(string name)
        //{
        //    return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        //}

        //public IActionResult Goodbye()
        //{
        //    return Content("Goodbye");
        //}
        public static string CreateMessage(string name, string language)
        {
            string greeting = "";

            switch (language)
            {
                case "english":
                    greeting = "Hello";
                    break;
                case "french":
                    greeting = "Bonjour";
                    break;
                case "japanese":
                    greeting = "こんにちは";
                    break;
                case "spanish":
                    greeting = "Hola";
                    break;
            }

            string message = string.Format("<h1>{0} {1}</h1>", greeting, name);
            return message;
        }

    }
}
