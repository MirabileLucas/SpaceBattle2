# SpaceBattle

Groupe 2

Projet de Génie Logiciel - Master 1 Informatique - Luminy

## Présentation
Space Battle est un jeu de tir et de courses spatial en 2D inspiré du jeu de 1991 XPilot et développé à l'aide du moteur de jeu Unity. 
Dans ce projet, le jeu est développé pour mobile et doit pouvoir réunir diifférents joueurs distants sur différentes 
cartes en fonction du mode de jeu choisi.

### Contact
Rachel Glaise : rachel.glaise@etu.univ-amu.fr

Yannick Gosset : yannick.gosset@etu.univ-amu.fr

Lucas Mirabile : lucas.mirabile@etu.univ-amu.fr

Nicolas Tillier : nicolas.tillier@etu.univ-amu.fr

### Jeu
#### Modes de jeu
##### Entrainement
La première carte correspond au mode de jeu _Entrainement_ permettant d'essayer le jeu seul pour prendre en main les commandes et essayer 
les différents bonus.  
##### Match à mort
Mode de jeu en ligne prenant place sur une autre carte plus élaborée et peaufinée où les joueurs
#### Carburant
Dans le mode _Entrainement_, une jauge de carburant se situe en haut de l'écran. Elle se vide progressivement et lorsqu'elle est vide
le vaisseau est détruit.
#### Bonus
Il existe cinq types de bonus qui durent tous 15 secondes (modifiable dans _Scenes > Bonus > BonusX > Duration_ ou dans 
_Scenes > Assets\_Solo  > Bonus\_Solo_ ). Leur implémentation est fonctionnelle dans la carte _Entrainement_ mais pose des problèmes en réseaux.
##### Turbo
Représentation : Boule bleue
Multiplie la vitesse du vaisseau par le facteur choisi. (_Scenes > Bonus > BonusSpeed > Multiplier_)
##### Triple tirs
Représentation : Boule rouge
Lors du tir, trois missiles sont tirés dans des directions différentes.
##### Tir rapide
Représentation : Boule violet
Les tirs sont plus rapides mais la cadence de tir est conservée.
##### Tir perçant
Représentation : Boule jaune
Les tirs ne se détruisent plus au contact d'autres tirs et de vaisseaux, ils peuvent aussi traverser les obstacles.
##### Carburant 
_Présent seulement dans la première carte_
Représentation : Boule verte
Ravitaille le vaisseau en carburant.

## Installation
### Sur téléphone Android
#### Téléchargement
Les différentes versions du jeu sont disponibles dans le dépôt Github, dans le répertoire APK_SpaceBattle. La liste des versions et une courte description sont disponibles dans le fichier "_liste versions_".
 
#### Installation de l'APK
* Après le téléchargement de votre APK, branchez votre téléphone à votre ordinateur. Utilisez celui-ci en mode "_USB pour transfert de fichier_". 
* Ajoutez dans votre téléphone le fichier APK choisi.
* Sur votre téléphone, aller dans _Mes Fichiers_ et cherchez l'APK.
* En cliquant dessus, un message indiquant que l'installation est bloquée peut apparaître.
* Dans ce cas, cliquez sur paramètres et cocher "_Sources inconnues_".
* L'installation commence alors.
* A la fin, lancez le jeu.

_Remarque : L'installation pose problèmes sur certains téléphones sans explications_

### Pour le développeur

## Utilisation
### Commandes
En jeu, les deux commandes principales sont le déplacement qui s'effectue à l'aide du Joystick Virtuel en-bas à gauche de l'écran (plus vous le tirer plus la vitesse est élevée) et le tir qui se trouve à l'opposé (un tir continu est impossible).
### Créer une partie
Lors du lancement de l'application, le menu propose deux options. Pour créer une partie choisissez la première. Un nouvel écran s'ouvre proposant les différents paramètres à modifier pour créer une partie. 

A ce niveau du projet, seuls les options concernant le nombre de joueurs et le mode de jeu sont utilisables. 
Pour créer une partie en ligne, il faut donc choisir _DeatchMatch_, le nombre de joueurs max autorisé ainsi que le nom de la partie. Ensuite vous pouvez lancer.
Pour jouer seul, le mode de jeu est le seul paramètre utile, il faut choisir _Entrainement_ et _Lancer_.
### Rejoindre une partie
Pour rejoindre une partie, sélectionner dans le menu de départ le bouton _Rejoindre une partie_. Un nouvel écran s'affiche avec la liste de toutes les parties en cours. Sélectionnez en une pour la rejoindre.

### Paramètres
Permet de quitter l'application et de modifier le volume sonore. En jeu, cela permet aussi de quitter la partie en cours. 
## Architecture

## Guide de développement

## Points techniques

## Bugs et évolutions

## Conseils
