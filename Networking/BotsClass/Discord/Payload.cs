using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking.BotsClass.Discord
{
    class Payload
    {
        public static string heartbeat = "{\"op\" : 1, \"d\" : null}";
        public static string identify = @"{
                                            ""op"" : 2,
                                            ""d"" : {
                                                    ""token"" : """",
                                                    ""properties"" : {
                                                                    ""$os"" : ""window"",
                                                                    ""$browser"" : ""c#"",
                                                                    ""$device"" : ""c#""
                                                                    }
                                                    }
                                            }";
    }

    
    
}
