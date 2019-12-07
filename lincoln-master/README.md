# Project Lincoln - DX Lifecycle Takehome Assignment

The purpose of this test is to evaluate your skill as a fullstack software engineer. It should you about 2-3 hours to complete, although you may take more time if you want / need.

## Getting Started

1) Use the .NET Core LTS Version (2.1)
2) run `dotnet restore` to install all required packages
3) To  run the project, either use the VSCode Debugger task, or run `dotnet run`.
4) The Project should now be reachable @ http://localhost:5000

## Spec

You are tasked with building a directory that shows us our availability of games, and if that game supports mods, as well as some glance-over information about them.

When a user navigates to the landing page, it should display a list of all the available games. If the Game Cache is not available yet, it should show an indication that the service is still acquiring the data.

The order of the listing should be based of the `Order` Property, and secondarily on the Alphabetical Listing for where the Order appears multiple times. If the order is `0`, and the game does not support addons, move it to the end of the list.

Each Game Item should display the following:
- Game Icon
- Game Name
- If the Game supports addons

When a user clicks on the individual item, it should redirect the user to a page with the pattern `/{slug}`.

This page should display:
 - Boxart of the game
 - Name
 - TwitchID
 - Category Sections


 ## Technical

 ### GameCache.cs
 This is an In-Memory Cache object that contains all the game Data. You will need to write code that contacts the external URL and load the data. 

 ### HomeController.cs

 This will be your base controller

 ### Game.cs
 This is the base game model. You should find all required information in there. If not, please compare with the response from the json feed.

 ## Bonus, not required

 - Implement Search Functionality
 - Implement a timed refetch functionality
 - Provide details on your UI Design choices. 

## Notes:
You're welcome to replace Bootstrap & JQuery with whatever tools you prefer. We included them as a starting point to make the startup process as fast as possible.
