# THE PRICE IS RIGHT (Code Louisville project)

## Description  
In the Price is Right, there are certain games that offer a better chance of winning than others.  There are 46 seasons of the hit game show.  I analyzed the statistcs since 2000.  I stopped at 2000 because there are many games available now that were not played in the earlier years of the show.  

This data will show three things:  
* Which year that had the greatest winning percentage?  
* What game has had the highest winning percentage?  
* Which spinner in the showcase showdown was most successful?  
  
  
## Packages you will need:
* requests  
* numpy  
* sqlite3
* matplotlib
  
    
## How results were analyzed:  
The following functionality has been added to this site:
  
* Game data for each game/season was saved in CSV format:  
  (https://github.com/koryvette/priceisright)  
* Showcase data was save in CSV format:  
  (https://raw.githubusercontent.com/koryvette/python/master/project/Showcase_spin.csv)  
* CSV file was imported to a dataframe using Pandas/python.  
* A database was created called priceisright.db.  
* The "output" CSV file in Python was used to create a table called Games in the priceisright.db.  
* The "Showcase_spin" CSV file in Python was used to create a table called Showcase in the priceisright.db.  
* SQL was used to get the total wins, losses, and total games played by season.  
* SQL was also used to total the wins, losses and total times played by each game per season.
* Finally, SQL was also used to total the number of wins for each spinner in the Showcase Showdown.

* Results from the three SQL queries were graphed using Matplotlib.  
*   
*  




