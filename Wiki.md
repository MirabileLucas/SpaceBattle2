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
Mode de jeu en ligne prenant place sur une autre carte plus élaborée et peaufinée où les joueurs se retrouvent pour se détruire mutuellement en ayant à leur disposition des bonus éparpillés sur la carte. 
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
Pour créer une partie en ligne, il faut donc choisir _DeatchMatch_, le nombre de joueurs max autorisé ainsi que le nom de la partie. Ensuite vous pouvez lancer (vous êtes à la fois client et hôte).

Pour jouer seul, le mode de jeu est le seul paramètre utile, il faut choisir _Entrainement_ et _Lancer_.

### Rejoindre une partie
Pour rejoindre une partie, sélectionner dans le menu de départ le bouton _Rejoindre une partie_. Un nouvel écran s'affiche avec la liste de toutes les parties en cours. Sélectionnez en une pour la rejoindre (vous êtes client).

### Paramètres
Permet de quitter l'application et de modifier le volume sonore. En jeu, cela permet aussi de quitter la partie en cours. 

## Architecture & Guide de développement

## Points techniques

## Problèmes et évolutions
### Problèmes
Dans le mode multijoueurs, même si les joueurs se retrouvent sur une même carte il reste un problème de synchronisation des tirs et des bonus.
En effet, en jeu, lorsque l'hôte tir tous les clients peuvent voir les tirs. Cependant, dans le cas ou un client tir, seul celui-ci voit ses tirs (comme si les informations des clients n'étaient pas connu par le serveur malgré l'utilisation du _[Command]_ avec la fonction _shoot_). Ce problème implique que lorsqu'un joueur est "tué" par un autre, il n'est pas au courant et continue de jouer. Ainsi, le joueur qui l'a tué ne voit plus le vaisseau mais il peut toutefois voir les tirs venant de nulle part.

Un autre problème est la réapparition en multijoueurs. Si l'on meurt il est impossible de réapparaitre. En tant que clients il faut forcément se déconnecter puis se reconnecter à la partie.

Du côté des bonus, leur apparition est propre aux joueurs. C'est à dire que chaque joueur à des bonus différents qui apparaissent à différents endroits de la carte. 

### Évolutions
Lors de l'élaboration du cahier des charges, de nombreuses fonctionnalités avait été discutées tel que la création de 4 modes de jeu, de l'implémentation d'un harpon, etc. Ceux-ci n'ont pas encore été réalisé.
L'implémentation d'une jauge de carburant a été effectuée dans la partie solo mais n'est pas encore présente dans le multi (ainsi que son bonus associé).

Au niveau du code, nous avons dupliqué énormément de code entre les fonctionnalités solo et multi. Une évolution serait de fusionner ces fichiers pour un projet plus propre.

Une nouvelle organisation à l'aide de Design Patern serait envisageable, comme par exemple pour les bonus, les tirs, ...

## Trucs et astuces
La documentation Unity est très approfondie, il existe de nombreux tuto, forums et autres qui en parle. Il existe aussi le Unity Store qui fournit de nombreux éléments (certains gratuits), il est très intéressant de les utiliser.

### Assets utilisés
#### Joystick Virtuel
https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631
#### Vaisseaux
https://assetstore.unity.com/packages/2d/textures-materials/simple-spaceships-81051
#### Graphismes spatiaux
https://assetstore.unity.com/packages/templates/systems/space-graphics-basic-pack-119857
#### Exemple d'un jeu simple et récupération de graphisme
https://assetstore.unity.com/packages/templates/packs/space-shooter-free-107260

### Partage du projet
Pour le partage du projet, nous avons essayé d'utiliser GitHub mais suite à des problèmes nous avons préféré utiliser le _collab_ de Unity. Cependant, sa version gratuite n'accepte que trois "sièges". C'est à dire que seulement trois personnes peuvent collaborer sur un projet.

### Liens utiles
#### Documentation C#
https://blog.rsuter.com/best-practices-for-writing-xml-documentation-phrases-in-c/
https://docs.microsoft.com/fr-fr/dotnet/csharp/codedoc
#### Documentation Unity
https://docs.unity3d.com/Manual/UnityManual.html
#### Tutoriel - Mini jeu en ligne
https://www.youtube.com/watch?v=UWF9tKcUWjg&list=PLUWxWDlz8PYL0H3j6BxR4DXcJGj4YP2T5
