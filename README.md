# Plot
Library for easy creation scenario-like texts.

Notes.
1. This library can be used for organizing plot (mostly for quest or text games, but other applications may be found). In your visualization engine (Unity, for example), you'll need to implement ILineProcessor to show user current text or other things. At runtime, you create instance of Player, providing it with ILineProcessor implementation and textfile containing scenario ('Script' in terms of library) 
2. This library has dependence on Newtonsoft.Json. At first I considered removing it, but decided it'll not give any significant advantages.
3. For creation of 'Script' file I use editor app providing means of graphical editing (like choice graph, flowcharts, etc). I'm not OSing it yet cause it will require little more work to become presentable.