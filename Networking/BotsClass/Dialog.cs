using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.BotsClass
{
    internal class Dialog
    {
        internal Dictionary<string, string> Answers { get; set; }

        internal Dialog()
        {
            Answers = new Dictionary<string, string>()
            {
                {"hi",                      "hi" },
                {"привет",                  "и тебе салют! :-)" },
                {"здравствуй",              "и тебе не хворать!" },
                {"Привет",                  "и тебе салют!" }
            };
        }
    }
}
