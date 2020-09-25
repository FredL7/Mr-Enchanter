# Mr. Enchanter
Welcome mighty enchanter, to a new world where you will gain magical abilities to reach ultimate power! Your ascension to power will only be slowed down by all that curse mortal life; Sustenance, rent and having to recruit interns to do your paperwork.

Mr. Enchanter is a rogue-like deck building game where you manage your resources in order to complete rituals and gain power points. It is inspired by other card games such as [Magic the Gathering](https://magic.wizards.com/fr) and [Star Realms](https://www.starrealms.com/).

I made Mr. Enchanter during a two week break between school semeters as a challenge to complete a functional prototype in that time period. I did not work full-time on it but probably took around 40 to 50 hours to complete. I paid particular attention to applying the knowledge I learned as part of my Software engineering bachelor's degree, especially concerning programming patterns. The game features poor visual aesthetics since it was not my goal to create a pretty game. It is after all a prototype and functionnality was my primary focus.

## Notable architecture features
### MVC Pattern
I strongly followed the idea behind the MVC pattern by splitting my scripts into three categories, models, views and controllers. Controllers include keyboard and mouse events using Unity's EventSystem, and Unity buttons. Views control what how elements are seen on the screen and what information is display. That information comes from the various models.

### Card Effects
Card effects were modelled after the command pattern. I had no need to keep an history of the cards or effects played, but this helped abstract the effects and make it easier to handle and create them. I was able to create for instance a generic change gold effect and, using an effect factory (more on that below), define an add 5 gold effect, or a remove 50 gold effect. Using inheritance and interfaces, each card effect had an execute method whose implementation was left to each concrete effect classes. The advantage of this abstraction is that a card had a list of effects and whenever a card was played I simply had to loop through them and call the execute method on each effect without having to know what this particular card or its effects were. The effects had multiple uses, I could add them either as card's effect when played, but also as a card's cost with the only difference of sometimes having an Add effect versus a Substract effect. It made the game loop much simpler.

### Cards
Using the abstraction of effect, I was able to have a generic card class and use that as my only card object. Each concrete card was created by passing different parameters to its constructor. I played with the idea of using structs instead, but I found Unity's benefit that you could create new files of that type not advantageous as I fould have to create a file for each concrete card I wanted. I much prefered to leave the definition of the cards in a single Factory class (more on that below).

### Factories
Having all my cards as generic objects made it easy to create new ones. I used what I chose to call factories to serves as a card database. Different factories contained static accessor to cards and card effects. These defined all the cards and effects in the game and served as a directory for them as well.
