using System;

namespace HolisticWare.Xamarin.Tools.NeekNoke.App.Console.DotNetTool
{
	public static class Settings
	{
        public static
            string
                                        Intro =
@"
                 _                       _                                     
                | |                     | |                                    
 _ __   ___  ___| | ________ _ __   ___ | | _____                              
| '_ \ / _ \/ _ | |/ |______| '_ \ / _ \| |/ / _ \                             
| | | |  __|  __|   <       | | | | (_) |   |  __/                             
|_| |_|\___|\___|_|\_\      |_| |_|\___/|_|\_\___|                             
                                                                               
                                                                               
 _   _       _____      _                     _                       _        
| \ | |     |  __ \    | |                   | |                     | |       
|  \| |_   _| |  \/ ___| |_   _ __   ___  ___| | ________ _ __   ___ | | _____ 
| . ` | | | | | __ / _ | __| | '_ \ / _ \/ _ | |/ |______| '_ \ / _ \| |/ / _ \
| |\  | |_| | |_\ |  __| |_  | |_) |  __|  __|   <       | |_) | (_) |   |  __/
\_| \_/\__,_|\____/\___|\__| | .__/ \___|\___|_|\_\      | .__/ \___/|_|\_\___|
                             | |                         | |                   
                             |_|                         |_|
neek-noke = NuGet peek-poke
"
+
@"
moljac AKA miljenko mel cvjetko 
https://github.com/moljac
"
;


        public static
            string
                                        Outro =
@"
to collect backups

    find ./ -name ""*bckp-ts-*""
or 
    find ./ -name ""*bckp-ts-$(date +""%Y%m%d)*""

to cleanup backups:

    rm $(find ./ -name ""*bckp-ts-*"")

or

    rm $(find ./ -name ""*bckp-ts-$(date +""%Y%m%d)*"")
";

    }
}

