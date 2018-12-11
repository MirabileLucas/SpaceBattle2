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
##### Triple tir
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
Ayant priviligié le _Collab_ de Unity, nous n'avons pas travaillé via GitHub. 

**_ Méthode clé ou git_**

Après avoir récupéré le dossier du projet, vous pouvez lancer Unity. Une fenêtre blanche apparait, proposant d'ouvrir les derniers projets travaillés sur l'ordinateur. Au dessus de la liste des projets, cliquez sur _Open_ et choisissez le projet que vous venez de récupérer.
Ce projet se lance alors dans Unity. 

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
Le projet est composé de plusieurs fichiers triés mêlant des scripts, des _prefabs_, des images et des _GameObjects_. Le dossier _Scenes_ contient les cartes, et leur contenu, ainsi que les interfaces des menus. _Assets_Extern_ contient des projets récupérer sur le _Unity Store_ qui nous ont été utiles mais qui sont encore entier (peut être utile lors d'évolution possible, cependant certains _assets_ ont été récupérés partiellement et sont intégrés directement au projet.

Tous les éléments des menus sont dans le dossier _GUI_.

Pour plus de facilité lors de l'implémentation, nous avons dû dupliquer les éléments pour le solo, ceux-ci se trouvent dans _Elements_Solo_, tous les autres éléments sont utilisés pour le multi.

Le _prefab_ _Player 2_ est le joueur dans les modes multi, il est composé d'un vaisseau mais aussi de la caméra et des contrôles.

_Shot_ contient les _prefabs_ des quatre types de tirs implémentés.

## Points techniques
### Réseaux & MatchMaking
Pour permettre l'utilisation du matchmaking Unity, nous avons dû activer une option via l'interface web lié à notre projet posté sur le collab Unity. Pour y accéder via un projet collab :
* Onglet _Services_ (à coté de l'inspecteur)
* _Multiplayers_ (dans la liste des services)
* _Go to Dashboard_

### Spaceship
Ce script regroupe les fonctions liées au vaisseau comme le déplacement et les tirs. Le mouvement est décrit dans la fonction move(), elle même appelé dans _Update()_ qui est une fonction appelé à chaque nouvelle frame, et se base entièrement sur le _Joystick Virtuel_.

En ce qui concerne les tirs, la fonction est précédé de _[Command]_ qui indique que la fonction est appelé par le client mais exécuté par le serveur.

### Caméra et contrôles
La caméra possède différents objets car elle est unique pour chaque joueur et plusieurs caméras ne doivent pas se surposer, il en va de même pour les canvas qui contiennent les contrôles. Dans le cas contraire, on peut voir apparaitre des problèmes comme une caméra centrée sur le mauvais vaisseau ou des commandes qui ne sont pas accessibles (car en dessous des contrôles d'un autre joueurs).

### Player Start
Cette classe permet de faire descendre l'identité d'un joueur dans la hiérarchie des objets. En effet, en ligne, chaque objet doit avoir une identité (qui indique ainsi l'autorité) mais les enfants ne peuvent pas en avoir et ne connaissent pas l'identité de leur père, pour savoir s'ils ont le droit d'effectuer certaines actions, ils ont donc une variable booléenne qui le leur indique et qui est initialisée à la création du joueur. 

### GUI
Chaque panneau qui doit rester accessible lors des changements de scène possède deux classes liées :
*	une classe de définition et d'instanciation
* une classe qui rend une interface persistante (qui commence par DontDestroy)

Les panneaux _CreateMatch_ et _Join_Match_ possède en plus le moyen de crée un match (avec la fonction _CreateMatch()_ dans _CreateMatch.cs_) ou d'en rejoindre (avec la fonction _JoinMatch()_ dans _Join_Match.cs_)

## Problèmes et évolutions
### Problèmes
Dans le mode multijoueurs, même si les joueurs se retrouvent sur une même carte il reste un problème de synchronisation des tirs et des bonus.
En effet, en jeu, lorsque l'hôte tir tous les clients peuvent voir les tirs. Cependant, dans le cas où un client tir, seul celui-ci voit ses tirs (comme si les informations des clients n'étaient pas connues par le serveur malgré l'utilisation du _[Command]_ avec la fonction _shoot_). Ce problème implique que lorsqu'un joueur est "tué" par un autre, il n'est pas au courant et continue de jouer. Ainsi, le joueur qui l'a tué ne voit plus le vaisseau mais il peut toutefois voir les tirs venant de nulle part.

Un autre problème est la réapparition en multi-joueurs. Si l'on meurt il est impossible de réapparaitre. En tant que clients il faut forcément se déconnecter puis se reconnecter à la partie.

Du côté des bonus, leur apparition est propre aux joueurs. C'est à dire que chaque joueur à des bonus différents qui apparaissent à différents endroits de la carte. 

### Évolutions
Lors de l'élaboration du cahier des charges, de nombreuses fonctionnalités avait été discutées tel que :
* quatre modes de jeu (Entrainement, Match à mort, Grand prix, Capture de drapeaux)
* implémentation d'un harpon
* ajout de mines

Ceux-ci n'ont pas encore été réalisé.
L'implémentation d'une jauge de carburant a été effectuée dans la partie solo mais n'est pas encore présente dans le multi (ainsi que son bonus associé).


Au niveau du code, nous avons dupliqué énormément de code entre les fonctionnalités solo et multi. Une évolution serait de fusionner ces fichiers pour un projet plus propre (notamment à l'aide d'une interface Spaceship).


Une nouvelle organisation à l'aide de _Design Pattern_ serait envisageable, comme par exemple pour les bonus, les tirs, ...


Pour éviter de mettre fin à une partie si l'hôte se déconnecte, une migration d'hôte est envisageable (le composant NetworkMigrationManager peut être utile).


En ce qui concerne la jauge de carburant, elle est modifié à chaque déplacement et le code viens d'un asset externe. Le code en commentaire était une tentative pour faire changer cette jauge de couleur en dépassant un certain seuil. Cette version n'a pas fonctionné mais le code peut être utile.

## Trucs et astuces
La documentation Unity est très approfondie, il existe de nombreux tuto, forums et autres qui en parle. Il existe aussi le Unity Store qui fournit de nombreux éléments (certains gratuits), il est très intéressant de les utiliser.

L'utilisation de _prefab_ est très pratique mais un seul niveau d'enfant ne s'affiche dans la partie _Project_. Pour modifier les autres enfants, il faut glisser le prefab dans la hiérarchie, faire les modifications et les appliquer avec _Apply_ (en haut de l'inspecteur) puis le supprimer de la hiérarchie.

### Assets utilisés
#### Joystick Virtuel
https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631
#### Vaisseaux
https://assetstore.unity.com/packages/2d/textures-materials/simple-spaceships-81051
#### Graphismes spatiaux
https://assetstore.unity.com/packages/templates/systems/space-graphics-basic-pack-119857
#### Jauge de carburant
https://assetstore.unity.com/packages/tools/gui/simple-health-bar-free-95420
#### Exemple d'un jeu simple et récupération de graphisme
https://assetstore.unity.com/packages/templates/packs/space-shooter-free-107260

### Partage du projet
Pour le partage du projet, nous avons essayé d'utiliser GitHub mais suite à des problèmes nous avons préféré utiliser le _collab_ de Unity. Cependant, sa version gratuite n'accepte que trois "sièges". C'est à dire que seulement trois personnes peuvent collaborer sur un projet.

### Débuggage
Pour débugger, pensez à mettre les variables de vos scripts en public dans un premier temps pour pouvoir voir leur évolutions en temps réel lorsque vous lancer l'application via Unity.
Si vous avez un problème lié au réseau, vérifiez en priorité l'autorité de vos éléments. Pour cela, cliquez dessus dans la hiérarchie à gauche et elle s'affichera en bas de l'inspecteur.

### Liens utiles
#### Documentation C#
https://blog.rsuter.com/best-practices-for-writing-xml-documentation-phrases-in-c/

https://docs.microsoft.com/fr-fr/dotnet/csharp/codedoc
#### Documentation Unity
https://docs.unity3d.com/Manual/UnityManual.html
#### Tutoriel - Mini jeu en ligne
https://www.youtube.com/watch?v=UWF9tKcUWjg&list=PLUWxWDlz8PYL0H3j6BxR4DXcJGj4YP2T5
