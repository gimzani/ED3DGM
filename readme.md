# Elite Dangerous Galaxy Journal

I found the base code for this project here: [https://github.com/gbiobob/ED3D-Galaxy-Map](https://github.com/gbiobob/ED3D-Galaxy-Map)

MAD PROPS to gbiobob!!

## ok...  ...so what is it?

This came about because I wanted a way to visualize the area in the game that I frequent.  I wanted to be able to create a sort of 'journal' of stars where resources are good and where I had found interesting things.

I LOVE the galaxy map in the game, but I found that it was limited in what you could do with it - and WAY too sensitive.  I also wanted more information.  So I also found [https://www.edsm.net](https://www.edsm.net) - (elite dangerous star map) which is an awesome database of in-game data.  And it has a REST API!! :)

I knew that if I could pair the API with an awesome 3d map, I could build a local db of my own findings.

## Software Structure

This is an ASP.NET core 2.2 project that is serving a static page from the wwwroot folder.  It uses a Sqlite database for the local db.  I chose core because it has the potential to run on any OS, it can run standalone and it is a quick and easy way to manage the local db.

The wwwroot folder has the JavaScript app written in AngularJS - (ui and rest calls only).  The Galaxy map is all gbiobob!  (thanks, cat!)  ;)

## NO claims to release

This is an "as-is" project, so download it and play around with it all you like.  I have no real plans to support it, so fork it or improve and request a merge - whatever you like.

## How do I make it do the thing?

1. Clone the Repo
1. Make sure you have an internet connection - (api calls)
1. click the "runme.bat" file 

The runme bat file will open up a browser - (please, for the love of GOD use Chrome!) - then it will launch a local server running on port 7000.  If everything goes well, you will see the app launch in the browser with a few stars present.

The standalone build is for windows 10 x64.  If you have a mac, open the solution and republish for mac.  If you have Linux/Ubuntu, reread the last sentence and insert "linux" where "mac" is.

I've not tried this on Raspbian or Raspberry Pi - so if you do and get it to work, please tell me - (that would just be uber-sweet!)

## I ran it. What am I looking at?

The first section is a search-by-name.  Enter the name of a star-system and it will make a call to [https://www.edsm.net](https://www.edsm.net) for info about that star and display it in the box below.

If you do not have it in your journal, you can add it by hitting the 'add' button.  If you DO have it in your journal, you can click the star on the map and it will "auto-search" on that star name.

The box below it is a "radial search".  Select or type the name of a star-system and then hit 'search'.  The app will make a "radial search" to [https://www.edsm.net](https://www.edsm.net) based on the number box values below it.

R1 / R2 - where R1 is the radial center and R2 is the radial endpoint - (measured in light-years)

Please don't get stupid with the numbers.  I didn't spend too much time on the "error correcting" so you might crash the app.  (you have been warned)

The defaults are pretty good for finding "that star I visited the other day that was by that other star I always go to".

## Alright! Gimzani, just let me have the app!

Sure - feel free to clone the repo - fork the repo - whatever.

And if you are from Frontier - can you considering taking what I have and making it a REAL app or incorporate the "journal" idea into a future release?  It would really help.

And for the rest of you - I hope you enjoy it, expand it, have it crash and curse at it - whatever.  This was just a "toy" to me and helps keep me doing interstellar business.

-Gim