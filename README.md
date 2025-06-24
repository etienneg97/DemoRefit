# DemoRefit

## Fonctionnalit�s principales
- Consommation d�API REST via des interfaces C# annot�es avec Refit.
- Injection de services Refit dans les composants Blazor.
- Exemple CRUD sur une ressource Book (livre).
- R�cup�ration de la date serveur via une API d�di�e.
- Gestion des param�tres de requ�te (tri, limite, filtres par identifiants).
- Utilisation d'un handler pour mettre la langue dans les appels API.

## Structure du projet
- Refit/IBookApiService.cs : Interface Refit pour les op�rations sur les livres.
- Refit/IDateApiService.cs : Interface Refit pour r�cup�rer la date serveur.
- Refit/RefitBootstrapper.cs : M�thodes d�enregistrement des clients Refit.
- Pages/BookPage.razor & .cs : Exemple d�utilisation des services Refit dans un composant Blazor.
- Parameters/BookParameters.cs : Mod�le pour les param�tres de requ�te.