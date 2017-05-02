using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AnaphoraCore.Models;
using Microsoft.AspNetCore.Mvc;
using AnaphoraCore.Services;

namespace AnaphoraCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.NounPhrases = "";
            ViewBag.PersonalPronouns = "";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Anaphora()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Anaphora(string sentence)
        {
            var anaphora = new Anaphora();

            if (sentence != String.Empty)
            {
                var analyze = await PosAnalyze(sentence);

                // Anaphora Resolution starts here
                // First we find if there is a Noun Phrase, and if there is, add each one to NP list.

                anaphora.ProperNouns = new List<string>();
                for (var i = 0; i < analyze.AllIndexesOf("(NNP").Count; i++)
                {
                    var remainingSentence = analyze.Substring(analyze.AllIndexesOf("(NNP")[i] + 4);
                    anaphora.ProperNouns.Add(remainingSentence.Substring(0, remainingSentence.IndexOf(")", StringComparison.Ordinal)));
                }

                anaphora.PluralCommonNouns = new List<string>();
                for (var i = 0; i < analyze.AllIndexesOf("(NNS").Count; i++)
                {
                    var remainingSentence = analyze.Substring(analyze.AllIndexesOf("(NNS")[i] + 4);
                    anaphora.PluralCommonNouns.Add(remainingSentence.Substring(0, remainingSentence.IndexOf(")", StringComparison.Ordinal)));
                }

                anaphora.SingularCommonNouns = new List<string>();
                for (var i = 0; i < analyze.AllIndexesOf("(NN ").Count; i++)
                {
                    var remainingSentence = analyze.Substring(analyze.AllIndexesOf("(NN ")[i] + 4);
                    anaphora.SingularCommonNouns.Add(remainingSentence.Substring(0, remainingSentence.IndexOf(")", StringComparison.Ordinal)));
                }

                anaphora.PersonalPronouns = new List<string>();
                for (var i = 0; i < analyze.AllIndexesOf("(PRP").Count; i++)
                {
                    var remainingSentence = analyze.Substring(analyze.AllIndexesOf("(PRP")[i] + 5);
                    anaphora.PersonalPronouns.Add(remainingSentence.Substring(0, remainingSentence.IndexOf(")", StringComparison.Ordinal)));
                }

                anaphora.PossessivePronouns = new List<string>();
                for (var i = 0; i < analyze.AllIndexesOf("(PRP$").Count; i++)
                {
                    var remainingSentence = analyze.Substring(analyze.AllIndexesOf("(PRP")[i] + 5);
                    anaphora.PersonalPronouns.Add(remainingSentence.Substring(0, remainingSentence.IndexOf(")", StringComparison.Ordinal)));
                }

                anaphora.Sentence = ViewBag.Sentence = sentence;
                anaphora.Analysis = ViewBag.Analyze = analyze;
            }
            

            return View("Index", anaphora);
        }

        public async Task<string> PosAnalyze(string sentence)
        {
            var client = new HttpClient();
            var queryString = string.Empty;

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "46afb44ec04a45c78e41c314dc8a156e");

            var uri = "https://westus.api.cognitive.microsoft.com/linguistics/v1.0/analyze?" + queryString;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{ \"language\": \"en\", \"analyzerIds\": [\"22a6b758-420f-4745-8a3c-46835a67c0d2\"], \"text\": \"\'" + sentence + "\'\" }");

            using (var content = new ByteArrayContent(byteData))
            {
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);
                var contents = await response.Content.ReadAsStringAsync();
                return contents;
            }

        }
    }
}
