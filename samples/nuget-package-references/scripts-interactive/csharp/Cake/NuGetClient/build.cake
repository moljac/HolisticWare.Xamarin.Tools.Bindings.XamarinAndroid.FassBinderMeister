//  Cake.CoreCLR add to ./tools/ folder for debugging
#tool   nuget:?package=Cake.CoreCLR

// Debug Visualizer added
#addin  nuget:?package=HolisticWare.Core.Graphics.DebuggerVisualizer&prerelease

using System;

using Core.Graphics.DebuggerVisualizer;


            /*
            Install: 
                for Visual Studio Code - 
                    Debug Visualizer
                    hediet.debug-visualizer
            */

            /*
            moved to project:
            HolisticWare.Core.Graphics.DebuggerVisualizer.Legacy
            */
            Core.Graphics.DebuggerVisualizer.LinkedList<int> list = null;            
            list = new Core.Graphics.DebuggerVisualizer.LinkedList<int>();
            /* 
                1.  set breakpoint
                2.  open/view command pallete
                3.  in the Debug Visualizer window paste command that vizualizes
                    ```
                    list.Visualize()
                    ```
                    `Visualize()` is method that returns JSON string that vizualizes data
            */
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);

Information($"list.ToString() = {list.ToString()}");