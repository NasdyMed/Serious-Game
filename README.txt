TP Noté Serious Games

Equipe :
- Clément SZABO
- Mohamed NASDY
- Ismail AMIMER
- Théo CANTE

Projet testé sous Unity 2019.4.21f1 avec casque et manettes HTC Vive (plugin SteamVR)

Le projet se découpe en deux jeux :
	- Jeu "contrôle qualité de pneumatiques"
		- Consiste à faire apparaitre des pneus dans une benne, puis à les trier en fonction de leur état dans deux autres bennes (conforme et non conforme) en un minimum de temps
		- Seuls les temps des parties avec 100% de réussite sont enregistrés
		- Le nombre de pneus générés est de 10 par défaut, et peut être changé dans BoutonVert.cs (le calcul des scores est automatiquement adapté)
	
	- Jeu "manipulation d'une grue de levage"
		- Consiste à tenir à deux mains l'effecteur d'une grue d'atelier et lui faire suivre le chemin affiché en un minimum de temps
		- Lorsque l'effecteur sort de la trajectoire le score diminue
		- Le score, le nom et les temps sont enregistrés en mémoire persistente et conservés

Les données de scores sont persitantes, elles epuvent être effacées avec les fonctions PlayerPrefs.DeleteKey (commentées en temps normales) aux lignes 41 et 37 des scripts WriteName.cs et WriteNameTires.cs
